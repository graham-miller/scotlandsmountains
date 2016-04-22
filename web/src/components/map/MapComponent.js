'use strict';

import React from 'react';
import ReactDOM from 'react-dom';
import ToolBarComponent from './ToolBarComponent';
import SearchBarComponent from './SearchBarComponent';
import buildMap from './Factory';

class MapComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = { showSearch: false };

        this.toggleSearch = this.toggleSearch.bind(this)
        this.zoomIn = this.zoomIn.bind(this)
        this.zoomOut = this.zoomOut.bind(this)
        this.reset = this.reset.bind(this)
        this.setBaseLayer = this.setBaseLayer.bind(this)
        this.shouldComponentUpdate = this.shouldComponentUpdate.bind(this)
    }

    componentDidMount() {
        this.map = buildMap(ReactDOM.findDOMNode(this.refs.map), this.props.isActive);
    }
    
    shouldComponentUpdate (nextProps, nextState) {
        if ((!this.props.isActive) && nextProps.isActive) {
            this.map.updateHash();
            this.map.invalidateSize();
        }
        return true;
    }
    
    componentWillUnmount() {
        this.map = null;
    }

    toggleSearch() { this.setState({ showSearch: !this.state.showSearch }); }

    zoomIn() { this.map.zoomIn(); }

    zoomOut() { this.map.zoomOut(); }

    reset() { this.map.reset(); }

    setBaseLayer(layer) { this.map.setBaseLayer(layer); }

    render() {

        let searchBar = this.state.showSearch ? <SearchBarComponent /> : null;

        return (
            <div style={{height: '100%'}}>
                <div ref="map" style={{height: '100%'}}></div>
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