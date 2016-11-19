import React, { Component } from "react";
import { connect } from "react-redux";
import $ from "jquery";

import { create, destroy } from "../../actions/map";
import Toolbar from "./Toolbar";

import "./Map.scss";

class MapComponent extends Component {

    constructor(props) {
        super(props);

        this.onWindowResize = this.onWindowResize.bind(this);
    }

    onWindowResize() {
    }

    componentDidMount() {
        this.props.dispatch(create("map"));
        $(window).on("resize", this.onWindowResize);
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.lastUpdated !== this.props.lastUpdated) {
            this.props.map.displayMountains(nextProps.mountains);
        }
    }

    componentWillUnmount() {    
        $(window).on("resize", this.onWindowResize);
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
        mountains: state.mountains.items,
        status: state.mountains.status,
        lastUpdated: state.mountains.lastUpdated
    };
};

const Map = connect(mapStateToProps)(MapComponent);

export default Map;
