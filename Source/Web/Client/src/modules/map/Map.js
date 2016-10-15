import React, { Component } from 'react';

import { createMap, destroyMap } from '../../actions/map';

import mapFactory from './mapFactory';
import Toolbar from './Toolbar';

import './Map.scss';

class Map extends Component {

    constructor(props) {
        super(props);

        this.state = {
            mapElementId: 'map'
        };

        this.handleWindowResize = this.handleWindowResize.bind(this);
    }

    handleWindowResize() {
        this.props.map.resize();
    }
    
    shouldComponentUpdate(nextProps, nextState) {
        return false;
    }

    componentDidMount() {
        this.props.dispatch(createMap(mapFactory(this.state.mapElementId)));
        window.addEventListener('resize', this.handleWindowResize);
    }

    componentWillUnmount() {
        window.removeEventListener('resize', this.handleWindowResize);
        this.props.dispatch(destroyMap());
    }

    render() {
        return (
            <div style={{position:'relative'}}>
                <Toolbar />
                <div id={this.state.mapElementId} ></div>
            </div>
        );
    }
}

export default Map;
