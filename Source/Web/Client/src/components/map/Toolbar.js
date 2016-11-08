import { connect } from 'react-redux'
import React, { Component } from 'react';

import MdAddCircleOutline from 'react-icons/md/add-circle-outline';
import MdRemoveCircleOutline from 'react-icons/md/remove-circle-outline';
import MdMap from 'react-icons/lib/md/map';
import MdSatellite from 'react-icons/lib/md/satellite';

import { zoomIn, zoomOut, setBaseLayer } from '../../actions/map';

import MapLayers from '../../map/MapLayers';

class ToolbarComponent extends Component {

    constructor(props) {
        super(props);

        this.state = {
            canZoomIn: true,
            canZoomOut: true,
            baseLayer: MapLayers[0]
        };

        this.currentBaseLayerIs = this.currentBaseLayerIs.bind(this);
        this.handleZoomEnd = this.handleZoomEnd.bind(this);
        this.handleLayerAdd = this.handleLayerAdd.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        if (!this.props.map && nextProps.map) {
            nextProps.map.on('zoomend', this.handleZoomEnd);
            nextProps.map.on('layeradd', this.handleLayerAdd);
        }
        if (this.props.map && !nextProps.map) {
            nextProps.map.off('zoomend', this.handleZoomEnd);
            nextProps.map.off('layeradd', this.handleLayerAdd);
        }
    }

    handleZoomEnd() {
        if (this.props.map) {
            this.setState({
                canZoomIn: this.props.map.getZoom() < this.props.map.getMaxZoom(),
                canZoomOut: this.props.map.getZoom() > this.props.map.getMinZoom()
            });
        }
    }

    handleLayerAdd() {
        if (this.props.map) {
            this.setState({baseLayer: this.props.map.currentBaseLayer});
        }
    }

    currentBaseLayerIs(queriedBaseLayer) {
        debugger;
        if (this.props.map) {
            return this.props.map.currentBaseLayer === queriedBaseLayer;
        }
        return false;
    }

    render() {

        return (
            <div className="map btn-group" role="group" aria-label="Button group with nested dropdown">
                
                <button type="button" className="btn btn-secondary"
                    disabled={!this.state.canZoomIn}
                    onClick={() => this.props.dispatch(zoomIn())}>
                    <MdAddCircleOutline />
                </button>
                
                <button type="button" className="btn btn-secondary"
                    disabled={!this.state.canZoomOut}
                    onClick={() => this.props.dispatch(zoomOut())}>
                    <MdRemoveCircleOutline />
                </button>

                <button type="button" className="btn btn-secondary"
                    disabled={this.state.baseLayer === MapLayers[0]}
                    onClick={() => this.props.dispatch(setBaseLayer(MapLayers[0]))}>
                    <MdMap />
                </button>

                <button type="button" className="btn btn-secondary"
                    disabled={this.state.baseLayer === MapLayers[1]}
                    onClick={() => this.props.dispatch(setBaseLayer(MapLayers[1]))}>
                    <MdSatellite />
                </button>
                
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {map: state.map};
}

const Toolbar = connect(mapStateToProps)(ToolbarComponent);

export default Toolbar;
