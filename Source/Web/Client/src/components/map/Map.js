import React, { Component } from "react";
import { connect } from "react-redux";

import { create, destroy } from "./actions";
import Toolbar from "./Toolbar";

import "./Map.scss";

class MapComponent extends Component {

    componentDidMount() {
        this.props.dispatch(create("map"));
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.lastUpdated !== this.props.lastUpdated) {
            this.props.map.displayMountains(nextProps.mountains);
        }
    }

    componentWillUnmount() {    
        this.props.dispatch(destroy());
    }
    
    render() {

        return (
            <div className="full-height">
                <Toolbar />
                <div id="map" />
            </div>
        );
    }
}

const mapStateToProps = (state) => {

    // show mountains from most recently updated map source
    var mapSources = [
        (state) => state.list,
        (state) => state.mountain//,
        //(state) => state.search
    ];

    let latest = 0;

    for (var index = 1; index < mapSources.length; index++) {
        if (mapSources[index](state).lastUpdated != null) {
            if (mapSources[latest](state).lastUpdated == null) {
                latest = index;
            } else {
                if (mapSources[index](state).lastUpdated > mapSources[latest](state).lastUpdated) {
                    latest = index;
                }
            }
        }
    }

    const source = mapSources[latest](state);

    return {
        map : state.map,
        mountains: source.value,
        status: source.status,
        lastUpdated: source.lastUpdated
    };
};

const Map = connect(mapStateToProps)(MapComponent);

export default Map;
