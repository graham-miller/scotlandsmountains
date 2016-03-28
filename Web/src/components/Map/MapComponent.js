'use strict';

import React from 'react';
import ReactDOM from 'react-dom';

import ToolBarComponent from './ToolBarComponent';
import SearchBarComponent from './SearchBarComponent';
import buildMap from './MapFactory';
import { history } from '../../scripts/history.js';
import { parse, stringify } from 'query-string';

const defaultCenter = [57.353201,-4.011214];
const defaultZoom = 7;
let programaticallyUpdatedHash = false;

class MapComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            showSearch: false,
            view: 'Map'
        };

        this.toggleSearch = this.toggleSearch.bind(this)
        this.zoomIn = this.zoomIn.bind(this)
        this.zoomOut = this.zoomOut.bind(this)
        this.reset = this.reset.bind(this)
        this.setBaseLayer = this.setBaseLayer.bind(this)
        this.updateQueryString = this.updateQueryString.bind(this)
    }

    componentDidMount() {

        let center = defaultCenter;
        let zoom = defaultZoom;

        if (window.location.href.indexOf('?') > -1) {
            let queryString = window.location.href.substr(window.location.href.indexOf('?'));
            var query = parse(queryString);
            if(query.hasOwnProperty('map') && query.hasOwnProperty('lat') && query.hasOwnProperty('lng') && query.hasOwnProperty('zoom')){
                center = [query.lat, query.lng];
                zoom = query.zoom;
            }
        }        
            
        this.map = buildMap(ReactDOM.findDOMNode(this.refs.map), center, zoom);
        this.map.on('moveend zoomend', this.updateQueryString);
        history.listen((location) => {
            if(programaticallyUpdatedHash) {
                programaticallyUpdatedHash = false;
            } else {
                let query = location.query;
                if(query.hasOwnProperty('map') && query.hasOwnProperty('lat') && query.hasOwnProperty('lng') && query.hasOwnProperty('zoom')){
                    this.map.setView([query.lat, query.lng], query.zoom);
                }
            }
        })
        this.updateQueryString();
    }

    componentWillUnmount() {
        this.map.off('moveend zoomend');
        this.map = null;
    }

    updateQueryString() {
        const center = this.map.getCenter();
        const lat = Math.round(center.lat * 1000000) / 1000000
        const lng = Math.round(center.lng * 1000000) / 1000000
        programaticallyUpdatedHash = true;
        history.push({ query: {
            map: 'road',
            lat: lat,
            lng: lng,
            zoom: this.map.getZoom()
        }});
    }

    toggleSearch() { this.setState({ showSearch: !this.state.showSearch }); }

    zoomIn() { this.map.zoomIn(); }

    zoomOut() { this.map.zoomOut(); }

    reset() { this.map.reset(defaultCenter, defaultZoom); }

    setBaseLayer(layer) { this.map.setBaseLayer(layer); }

    render() {

        let searchBar = this.state.showSearch ? <SearchBarComponent /> : null;

        return (
            <div id="map-component">
                <div id="map" ref="map"></div>
                <div id="map-control">
                    <ToolBarComponent
                        toggleSearch={this.toggleSearch}
                        zoomIn={this.zoomIn}
                        zoomOut={this.zoomOut}
                        reset={this.reset}
                        setBaseLayer={this.setBaseLayer} />
                    {searchBar}
                </div>
            </div>
        );
    }
}

export default MapComponent;