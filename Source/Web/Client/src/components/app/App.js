import React, { Component } from "react";

import Header from "./Header";
import Footer from "./Footer";
import Map from "../map/Map";

class App extends Component {

    render() {

        const { map, content } = this.props;

        const mapSection = map == null ? null : (
            <div id="map-section">
                <div id="map-title">
                    {map}
                </div>
                <Map/>
            </div>
        );

        return (
            <div id="app">

                <Header/>

                {mapSection}

                <div id="content-section" className={map == null ? "without-map" : ""}>
                    <div id="content-wrapper">
                        {content}
                    </div>
                </div>

                <Footer/>

            </div>
        );
    }
}

export default App;
