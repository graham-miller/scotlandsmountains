import { connect } from "react-redux";
import React, { Component } from "react";

import { zoomIn, zoomOut, setBaseLayer } from "./actions";

import MapLayers from "../../map/MapLayers";

import FloatingActionButton from "material-ui/FloatingActionButton";

import ZoomIn from "material-ui/svg-icons/content/add";
import ZoomOut from "material-ui/svg-icons/content/remove";
import Satellite from "material-ui/svg-icons/maps/satellite";
import Map from "material-ui/svg-icons/maps/map";

import "./Toolbar.scss";

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
            nextProps.map.on("zoomend", this.handleZoomEnd);
            nextProps.map.on("layeradd", this.handleLayerAdd);
        }
        if (this.props.map && !nextProps.map) {
            nextProps.map.off("zoomend", this.handleZoomEnd);
            nextProps.map.off("layeradd", this.handleLayerAdd);
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
            <div id="map-toolbar">

                <div>
                    <FloatingActionButton
                        secondary={true}  mini={true}
                        disabled={!this.state.canZoomIn}
                        onTouchTap={() => this.props.dispatch(zoomIn())}>
                        <ZoomIn />
                    </FloatingActionButton>            
                </div>

                <div>
                    <FloatingActionButton
                        secondary={true}  mini={true}
                        disabled={!this.state.canZoomOut}
                        onTouchTap={() => this.props.dispatch(zoomOut())}>
                        <ZoomOut />
                    </FloatingActionButton>
                </div>

                <div>
                    <FloatingActionButton
                        secondary={true}  mini={true}
                        disabled={this.state.baseLayer === MapLayers[0]}
                        onTouchTap={() => this.props.dispatch(setBaseLayer(MapLayers[0]))}>
                        <Map />
                    </FloatingActionButton>
                </div>

                <div>
                    <FloatingActionButton
                        secondary={true}  mini={true}
                        disabled={this.state.baseLayer === MapLayers[1]}
                        onTouchTap={() => this.props.dispatch(setBaseLayer(MapLayers[1]))}>
                        <Satellite />
                    </FloatingActionButton>
                </div>

            </div>
        );

        // return (
        //     <div id="map-toolbar">
                
        //         <button type="button"
        //             disabled={!this.state.canZoomIn}
        //             onClick={() => this.props.dispatch(zoomIn())}>
        //             <MdAddCircleOutline />
        //         </button>
                
        //         <button type="button"
        //             disabled={!this.state.canZoomOut}
        //             onClick={() => this.props.dispatch(zoomOut())}>
        //             <MdRemoveCircleOutline />
        //         </button>

        //         <button type="button"
        //             disabled={this.state.baseLayer === MapLayers[0]}
        //             onClick={() => this.props.dispatch(setBaseLayer(MapLayers[0]))}>
        //             <MdMap />
        //         </button>

        //         <button type="button"
        //             disabled={this.state.baseLayer === MapLayers[1]}
        //             onClick={() => this.props.dispatch(setBaseLayer(MapLayers[1]))}>
        //             <MdSatellite />
        //         </button>
                
        //     </div>
        // );
    }
}

const mapStateToProps = (state) => {
    return {map: state.map};
};

const Toolbar = connect(mapStateToProps)(ToolbarComponent);

export default Toolbar;
