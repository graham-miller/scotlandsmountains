import { connect } from "react-redux";
import React, { Component } from "react";
import { zoomIn, zoomOut, setBaseLayer } from "./actions";
import FloatingActionButton from "material-ui/FloatingActionButton";
import Popover from "material-ui/Popover";
import ZoomIn from "material-ui/svg-icons/content/add";
import ZoomOut from "material-ui/svg-icons/content/remove";
import Layers from "material-ui/svg-icons/maps/layers";
// import Fullscreen from "material-ui/svg-icons/navigation/fullscreen";
// import FullscreenExit from "material-ui/svg-icons/navigation/fullscreen-exit";

class ToolbarComponent extends Component {

    constructor(props) {
        super(props);

        this.state = {
            canZoomIn: true,
            canZoomOut: true,
            layersOpen: false,
            baseLayer: this.props.baseLayers[0]
        };
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

    handleZoomEnd = () => {
        if (this.props.map) {
            this.setState({
                canZoomIn: this.props.map.getZoom() < this.props.map.getMaxZoom(),
                canZoomOut: this.props.map.getZoom() > this.props.map.getMinZoom()
            });
        }
    }

    handleLayerAdd = () => {
        if (this.props.map) {
            this.setState({ baseLayer: this.props.map.currentBaseLayer });
        }
    }

    currentBaseLayerIs = (index) => {
        const queriedBaseLayer = this.props.baseLayers[index];
        if (this.props.map) {
            return this.props.map.currentBaseLayer.name === queriedBaseLayer.name;
        }
        return false;
    }

    setBaseLayer = (index) => {
        this.handleCloseLayers(); 
        const newBaseLayer = this.props.baseLayers[index];
        if (this.props.map) {
            this.props.dispatch(setBaseLayer(newBaseLayer));
        }
        this.setState({ baseLayer: newBaseLayer });
    }

    handleOpenLayers = (event) => {
        event.preventDefault();
        this.setState({
            layersOpen: true,
            anchorEl: event.currentTarget,
        });
    };

    handleCloseLayers = () => {
        this.setState({
            layersOpen: false,
        });
    };

    render() {

        return (
            <div id="map-toolbar">

                {/*<div>
                    <FloatingActionButton
                        secondary={true} mini={true}
                        disabled={!this.state.canZoomIn}
                        onTouchTap={() => this.props.dispatch(zoomIn())}>
                        <Fullscreen />
                    </FloatingActionButton>
                </div>*/}

                <div>
                    <FloatingActionButton
                        secondary={true} mini={true}
                        disabled={!this.state.canZoomIn}
                        onTouchTap={() => this.props.dispatch(zoomIn())}>
                        <ZoomIn />
                    </FloatingActionButton>
                </div>

                <div>
                    <FloatingActionButton
                        secondary={true} mini={true}
                        disabled={!this.state.canZoomOut}
                        onTouchTap={() => this.props.dispatch(zoomOut())}>
                        <ZoomOut />
                    </FloatingActionButton>
                </div>

                <div>
                    <FloatingActionButton
                        secondary={true} mini={true}
                        onTouchTap={(event) => this.handleOpenLayers(event)}>
                        <Layers />
                    </FloatingActionButton>
                </div>

                <Popover
                    open={this.state.layersOpen}
                    anchorEl={this.state.anchorEl}
                    anchorOrigin={{horizontal:"middle",vertical:"center"}}
                    targetOrigin={{horizontal:"right",vertical:"center"}}
                    onRequestClose={this.handleCloseLayers}>
                    <div>
                        {
                            this.props.baseLayers.map((baseLayer, index) =>
                                <div key={index} style={{margin:"10px"}}>
                                    <FloatingActionButton
                                        secondary={true} mini={true}
                                        disabled={this.currentBaseLayerIs(index)}
                                        onTouchTap={() => this.setBaseLayer(index)}
                                        children={baseLayer.label}>
                                    </FloatingActionButton>
                                </div>
                            )
                        }
                    </div>
                </Popover>

            </div >
        );
    }
}

const mapStateToProps = (state) => {
    return { map: state.map };
};

const Toolbar = connect(mapStateToProps)(ToolbarComponent);

export default Toolbar;
