import React, { Component } from "react";

import Title from "./Title";
import Footer from "./Footer";
import Routes from "./Routes";

import "./App.scss";

class App extends Component {

    render() {
        return (
            <div id="app-component">
                <Title />
                <main>
                    <Routes/>
                    <Footer/>
                </main>
            </div>
        );
    }
}

export default App;
