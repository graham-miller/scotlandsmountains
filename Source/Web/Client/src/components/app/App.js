import React, { Component } from "react";
import { connect } from "react-redux";

import { fetchStaticData } from "../../state/staticData";
import Splash from "./Splash";
import Header from "./Header";
import Footer from "./Footer";
import Notification from "./Notification";
import Map from "../map/Map";

class AppComponent extends Component {

    componentDidMount() {
        this.props.dispatch(fetchStaticData());
    }

    render() {

        const staticData = this.props.staticData;
        if (staticData.status.error || !staticData.value) {
            return (
                <div>
                    <Splash/>
                    <Notification />
                </div>
            );
        }

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
                <Notification />
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        staticData: state.staticData
    };
};

const App = connect(mapStateToProps)(AppComponent);

export default App;
