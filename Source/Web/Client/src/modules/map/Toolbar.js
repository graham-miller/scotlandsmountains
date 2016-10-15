import React, { Component } from 'react';

import MdAddCircleOutline from 'react-icons/md/add-circle-outline';
import MdRemoveCircleOutline from 'react-icons/md/remove-circle-outline';
import MdRefresh from 'react-icons/md/refresh';
import MdMap from 'react-icons/lib/md/map';
import MdSatellite from 'react-icons/lib/md/satellite';

class Toolbar extends Component {

    render() {
        return (
            <div className="map btn-group" role="group" aria-label="Button group with nested dropdown" >
                
                <button type="button" className="btn btn-secondary"
                    disabled={!this.props.canZoomIn}
                    onClick={this.props.zoomIn}>
                    <MdAddCircleOutline />
                </button>
                
                <button type="button" className="btn btn-secondary"
                    disabled={!this.props.canZoomOut}
                    onClick={this.props.zoomOut}>
                    <MdRemoveCircleOutline />
                </button>

                <button type="button" className="btn btn-secondary"><MdRefresh /></button>

                <button type="button" className="btn btn-secondary"
                    disabled={true}
                    ><MdMap /></button>

                <button type="button" className="btn btn-secondary"><MdSatellite /></button>
                
            </div>
        );
    }
}

export default Toolbar;
