import React, { Component } from 'react';

import Toolbar from './Toolbar';
import Map from './Map';
import './MapModule.scss';

class MapModule extends Component {

    constructor(props) {
        super(props);

        this.handleZoomIn = this.handleZoomIn.bind(this);
        this.handleZoomOut = this.handleZoomOut.bind(this);
        this.handleReset = this.handleReset.bind(this);
        this.handleSelectMap = this.handleSelectMap.bind(this);
        this.handleSelectAerial = this.handleSelectAerial.bind(this);
    }
        
    handleZoomIn () { alert('zoomIn'); }
    handleZoomOut () { alert('zoomOut'); }
    handleReset () { }
    handleSelectMap () { }
    handleSelectAerial () { }

    render() {
        return (
            <div style={{position:'relative'}}>
                <Toolbar />
                <Map />
            </div>
        );
    }
}

export default MapModule;
