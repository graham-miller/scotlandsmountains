import React, { Component } from "react";

import Title from "./Title";
import Map from "../map/Map";
import Routes from "./Routes";
import Footer from "../footer/Footer";

import "./App.scss";

class App extends Component {
    render() {
        return (
            <div id='app'>
                <Title />
                <div className='container-fluid' style={{paddingTop: "70px", marginBottom: "40px"}}>
                    <div className='row'>
                        <div className='col-md-4'><Routes /></div>
                        <div className='col-md-8'><Map /></div>
                    </div>
                </div>
                <Footer />
            </div>
        );
    }
}

export default App;
