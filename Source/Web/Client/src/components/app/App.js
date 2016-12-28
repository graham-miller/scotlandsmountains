import React, { Component } from "react";

import Title from "./Title";
import Map from "../map/Map";
import TitleRoutes from "./TitleRoutes";
import ContentRoutes from "./ContentRoutes";
import Footer from "./Footer";

import "./App.scss";

class App extends Component {

    render() {
        return (
            <div id="app-component">
                <Title />
                <main>
                    <div id="map-section">
                        <div id="page-title">
                            <TitleRoutes />
                        </div>
                        <div id="map-container">
                            <Map />
                        </div>
                    </div>
                    <div id="content-section">
                        <ContentRoutes />
                    </div>
                    <Footer />
                </main>
            </div>
        );
    }
}

export default App;
