import React, { Component } from 'react';

class MapElement extends Component {

    constructor(props) {
        super(props);
        this.state = {mapElementId: 'map'};
    }
    
    shouldComponentUpdate(nextProps, nextState) {
        return false;
    }

    componentDidMount() {
        this.props.createMap(this.state.mapElementId);
        window.addEventListener('resize', this.props.resizeMap);
    }

    componentWillUnmount() {
        window.removeEventListener('resize', this.props.resizeMap);
        this.props.destroyMap();
    }

    render() {
        return (<div id={this.state.mapElementId}></div>);
    }
}

export default MapElement;
