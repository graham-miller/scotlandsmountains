import { connect } from 'react-redux'
import React, { Component } from 'react';

import MdAddCircleOutline from 'react-icons/md/add-circle-outline';
import MdRemoveCircleOutline from 'react-icons/md/remove-circle-outline';
import MdRefresh from 'react-icons/md/refresh';
import MdMap from 'react-icons/lib/md/map';
import MdSatellite from 'react-icons/lib/md/satellite';

import { zoomIn, zoomOut, setBaseLayer, reset } from '../../actions/map';

import MapLayers from '../../factories/MapLayers';

class ToolbarComponent extends Component {

    render() {

        return (
            <div className="map btn-group" role="group" aria-label="Button group with nested dropdown" >
                
                <button type="button" className="btn btn-secondary"
                    disabled={!this.props.canZoomIn}
                    onClick={() => this.props.dispatch(zoomIn())}>
                    <MdAddCircleOutline />
                </button>
                
                <button type="button" className="btn btn-secondary"
                    disabled={!this.props.canZoomOut}
                    onClick={() => this.props.dispatch(zoomOut())}>
                    <MdRemoveCircleOutline />
                </button>

                <button type="button" className="btn btn-secondary"
                    onClick={() => this.props.dispatch(reset())}>
                    <MdRefresh />
                </button>

                <button type="button" className="btn btn-secondary"
                    disabled={this.props.baseLayer === MapLayers.Map}
                    onClick={() => this.props.dispatch(setBaseLayer(MapLayers.Map))}>
                    <MdMap />
                </button>

                <button type="button" className="btn btn-secondary"
                    disabled={this.props.baseLayer === MapLayers.Aerial}
                    onClick={() => this.props.dispatch(setBaseLayer(MapLayers.Aerial))}>
                    <MdSatellite />
                </button>
                
            </div>
        );
    }
}

const mapStateToProps = (state) => {

    return {
        canZoomIn: state.map.canZoomIn,
        canZoomOut: state.map.canZoomOut,
        baseLayer: state.map.baseLayer
    }

}

const Toolbar = connect(mapStateToProps)(ToolbarComponent)

export default Toolbar;
