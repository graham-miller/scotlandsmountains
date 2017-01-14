import React, { Component } from "react";

import Map from "../map/Map";

import "./MapWrapper.scss";

class MapWrapper extends Component {

    render() {
        const { title, content } = this.props;
        return (
            <div id="map-wrapper">
                <div id="map-section">
                    <div id="page-title">
                        {title}
                    </div>
                    <div id="map-container">
                        <Map />
                    </div>
                </div>
                <div id="content-section">
                    {content}
                </div>
            </div>
        );
    }
}

export default MapWrapper;
