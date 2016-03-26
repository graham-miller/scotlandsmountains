'use strict';

import './styles/App.scss';
import 'normalize.css';

import React from 'react';
import ReactDOM from 'react-dom';
import { Router, Route, IndexRoute, Link, hashHistory } from 'react-router'

import AppBarComponent from './components/AppBar/AppBarComponent.js'
import MapComponent from './components/Map/MapComponent.js'
import AboutComponent from './components/About/AboutComponent.js'
import FooterComponent from './components/Footer/FooterComponent.js'

// Needed for onTouchTap, can be removed when react 1.0 is released https://github.com/zilverline/react-tap-event-plugin
import injectTapEventPlugin from 'react-tap-event-plugin';
injectTapEventPlugin();

class App extends React.Component {

    render() {
        var mapIsActive = this.props.children == null;
        var contentClassName = this.props.children == null ? 'hidden' : 'visible';

        return (
            <div id="app-component">
                <AppBarComponent />
                <div id="below-app-bar-outer">
                    <div id="below-app-bar-inner">
                        <div id="map-container-outer">
                            <div id="map-container-inner">
                                <MapComponent />
                            </div>
                            {mapIsActive ? <FooterComponent showHandle={true} /> : null }
                        </div>
                        <div id="content-container-outer" className={mapIsActive ? 'active' : 'visible'}>
                            <div id="content-container-inner">
                                {this.props.children}
                            </div>
                            {mapIsActive ? null : <FooterComponent showHandle={false} /> }
                        </div>
                    </div>
                </div>                
            </div>
        );
    }
}

ReactDOM.render((
    <Router history={hashHistory}>
        <Route path="/" component={App}>
            <IndexRoute component={null} />
            <Route path="about" component={AboutComponent} />
        </Route>
    </Router>), document.getElementById('app-container'));