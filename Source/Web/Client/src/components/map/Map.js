import React, { Component } from "react";
import { connect } from "react-redux";
import createBaseLayers from "./baseLayerFactory";
import { create, destroy } from "./actions";
import Toolbar from "./Toolbar";

class MapComponent extends Component {

    componentDidMount() {
        var baseLayers = createBaseLayers({
            mapBoxApiKey: this.props.staticData.value.apiKeys.mapBox,
            bingMapsApiKey:  this.props.staticData.value.apiKeys.bingMaps
        });
        this.setState({baseLayers: baseLayers});
        this.props.dispatch(create("map", baseLayers[0]));
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.lastUpdated !== this.props.lastUpdated && this.props.map != null) {
            this.props.map.displayMountains(nextProps.mountains);
        }
    }

    componentWillUnmount() {    
        this.props.dispatch(destroy());
    }
    
    render() {

        const toolbar = (this.state || {}).baseLayers
            ? <Toolbar baseLayers={this.state.baseLayers}/>
            : null;
            
        return (
            <div id="map-wrapper">
                {toolbar}
                <div id="map" />
            </div>
        );
    }
}

const mapStateToProps = (state) => {

    // show mountains from most recently updated map source
    const isAfter = function (date) {
        if (date == null) { return false; }
        if (arguments.length > 1) {
            for (var i = 1; i < arguments.length; i++) {
                let compareTo = arguments[i];
                if (compareTo != null && compareTo > date) {
                    return false;
                }
            }
        }
        return true;
    };

    let listLastUpdated = state.list.lastUpdated;
    let mountainLastUpdated = state.mountain.lastUpdated;
    let searchLastUpdated = state.search.lastUpdated;
    let mountains = [];
    let lastUpdated = null;
    
    if (isAfter(listLastUpdated, mountainLastUpdated, searchLastUpdated)) {
        mountains = state.list.value;
        lastUpdated = state.list.lastUpdated;
    }

    if (isAfter(mountainLastUpdated, listLastUpdated, searchLastUpdated)) {
        mountains = state.mountain.value;
        lastUpdated = state.mountain.lastUpdated;
    }

    if (isAfter(searchLastUpdated, listLastUpdated, mountainLastUpdated)) {
        mountains = state.search.value.results;
        lastUpdated = state.search.lastUpdated;
    }

    return {
        staticData: state.staticData,
        map: state.map,
        mountains: mountains,
        lastUpdated: lastUpdated
    };
};

const Map = connect(mapStateToProps)(MapComponent);

export default Map;
