import React from 'react';
import ReactDOM from 'react-dom';
import buildMap from './MapFactory';

class MapComponent extends React.Component {

    componentDidMount() {
        this.map = buildMap(ReactDOM.findDOMNode(this)); 
    }

    componentWillUnmount() {
        this.map = null;
    }
    
    render() {
        return (
            <div id='map'></div>
        );
    }
}

export default MapComponent;