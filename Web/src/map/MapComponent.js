'use strict';

import React from 'react';
import ReactDOM from 'react-dom';
import MapStore from './MapStore';
import MapActions from './MapActions';

class MapComponent extends React.Component {

    componentDidMount() {
        MapActions.createMap(ReactDOM.findDOMNode(this));
    }

    componentWillUnmount() {
        MapActions.destroyMap();
    }

    render() {
        return (
            <div id='map'></div>
        );
    }
}

export default MapComponent;