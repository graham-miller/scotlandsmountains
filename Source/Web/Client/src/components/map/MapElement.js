import React, { Component } from 'react';

class MapElement extends Component {

    constructor(props) {
        super(props);
        this.mapElementId = 'map';
    }
    
    shouldComponentUpdate(nextProps, nextState) {
        return false;
    }

    componentDidMount() {
        this.props.createMap(this.mapElementId);
    }

    componentWillUnmount() {
        this.props.destroyMap();
    }

    render() {
        return (<div id={this.mapElementId} style={{height: '100%'}}></div>);
    }
}

export default MapElement;
