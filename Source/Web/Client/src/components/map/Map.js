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
    return {
        map : state.map,
        mountains: state.list.value,
        status: state.list.status,
        lastUpdated: state.list.lastUpdated
    };
};

const Map = connect(mapStateToProps)(MapComponent);

export default Map;
