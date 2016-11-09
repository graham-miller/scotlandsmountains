import React, { Component } from "react";
import { connect } from "react-redux";

import { create, destroy } from "../../actions/map";
import Toolbar from "./Toolbar";
import FullHeight from "../common/FullHeight";

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
            <div style={{position:"relative"}}>
                <FullHeight allowance='85' handleResize={this.resizeMap}>
                    <div id='map' style={{height: "100%"}} />
                </FullHeight>
                <Toolbar/>
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
