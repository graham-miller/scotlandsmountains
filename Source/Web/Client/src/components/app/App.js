import React, { Component } from "react";

import Title from "./Title";
import Footer from "./Footer";
import Map from "../map/Map";

class App extends Component {

    render() {
        const { map, content } = this.props;
        return (
            <div id="app">

                <Title/>

                <div id="map-section">
                    <div id="map-title">
                        {map}
                    </div>
                    <Map/>
                </div>

                <div id="content-section">
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
