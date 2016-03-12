'use strict';

import React from 'react';
import ReactDOM from 'react-dom';

import buildMap from './MapFactory';

const center = [56.964957, -4.659999];
const zoom = 2;

class MapComponent extends React.Component {

    componentDidMount() {
        this.map = buildMap(ReactDOM.findDOMNode(this), center, zoom); 
    }

    componentWillUnmount() {
        this.map = null;
    }

    render() {

        return (
            <div id="map-component">Map</div>
        );
    }
}

export default MapComponent;