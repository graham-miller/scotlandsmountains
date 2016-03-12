'use strict';

import './styles/App.scss';
import 'normalize.css';

import React from 'react';
import ReactDOM from 'react-dom';

import AppBarComponent from './components/AppBar/AppBarComponent.js'
import MapComponent from './components/Map/MapComponent.js'
import FooterComponent from './components/Footer/FooterComponent.js'

class App extends React.Component {

    render() {
        return (
            <div id="app-component">
                <AppBarComponent />
                <MapComponent />
                <FooterComponent />
            </div>
        );
    }
}

ReactDOM.render(<App/>, document.getElementById('app-container'));