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
    let listLastUpdated = state.list.lastUpdated;
    let mountainLastUpdated = state.mountain.lastUpdated;
    let searchLastUpdated = state.search.lastUpdated;

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

    if (isAfter(listLastUpdated, mountainLastUpdated, searchLastUpdated)) {
        return {
            map : state.map,
            mountains: state.list.value,
            lastUpdated: state.list.lastUpdated
        };
    }

    if (isAfter(mountainLastUpdated, listLastUpdated, searchLastUpdated)) {
        return {
            map : state.map,
            mountains: state.mountain.value,
            lastUpdated: state.mountain.lastUpdated
        };
    }

    if (isAfter(searchLastUpdated, listLastUpdated, mountainLastUpdated)) {
        return {
            map : state.map,
            mountains: state.search.value.results,
            lastUpdated: state.search.lastUpdated
        };
    }

    return {
        map : state.map,
        mountains: [],
        lastUpdated: null
    };
};

const Map = connect(mapStateToProps)(MapComponent);

export default Map;
