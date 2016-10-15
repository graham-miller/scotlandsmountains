import React, { Component } from 'react';

import mapFactory from './mapFactory';
import Toolbar from './Toolbar';
import MapElement from './MapElement';

import './Map.scss';

class Map extends Component {

    constructor(props) {
        super(props);

        this.state = {
            map: null,
            canZoomIn: true,
            canZoomOut: true
        };

        this.createMap = this.createMap.bind(this);
        this.zoomIn = this.zoomIn.bind(this);
        this.zoomOut = this.zoomOut.bind(this);
        this.onZoomEnd = this.onZoomEnd.bind(this);
        this.resizeMap = this.resizeMap.bind(this);
        this.destroyMap = this.destroyMap.bind(this);
    }
    
    createMap(elementId) {
        var map = mapFactory(elementId);
        map.on('zoomend', this.onZoomEnd);

        this.setState({map: map});
    }

    zoomIn() {
        this.state.map.zoomIn();
    }
    
    zoomOut() {
        this.state.map.zoomOut();
    }
    
    onZoomEnd() {
        this.setState({
            canZoomIn: this.state.map.getZoom() < this.state.map.getMaxZoom(),
            canZoomOut: this.state.map.getZoom() > this.state.map.getMinZoom()
        });
    }

    resizeMap() {
        this.state.map.resize();
    }
    
    destroyMap() {
        this.state.map.off('zoomend', this.onZoomEnd);
        this.setState({map: null});
    }
    
    render() {
        return (
            <div style={{position:'relative'}}>
                <Toolbar
                    canZoomIn={this.state.canZoomIn}
                    canZoomOut={this.state.canZoomOut}
                    zoomIn={this.handleZoomIn}
                    zoomOut={this.handleZoomOut} />
                <MapElement
                    createMap={this.createMap}
                    destroyMap={this.destroyMap}
                    resizeMap={this.resizeMap} />
            </div>
        );
    }
}

export default Map;