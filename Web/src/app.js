'use strict';

import './styles/index.less';
import 'normalize-css';

import React from 'react';
import ReactDOM from 'react-dom';
import { Router, Route, IndexRoute, Link } from 'react-router'
import { routerHistory } from './scripts/history';

import AppComponent from './components/AppComponent';
import AppBarComponent from './components/AppBarComponent';
import MapComponent from './components/MapComponent';
import AboutComponent from './components/AboutComponent';
import FooterComponent from './components/FooterComponent';

import injectTapEventPlugin from 'react-tap-event-plugin';

// Needed by material-ui for onTouchTap event.
// Can go away when react 1.0 release, check this repo:
// https://github.com/zilverline/react-tap-event-plugin
injectTapEventPlugin();

ReactDOM.render((
    <Router history={routerHistory}>
        <Route path="/" component={AppComponent}>
            <IndexRoute component={null} />
            <Route path="about" component={AboutComponent} />
        </Route>
    </Router>), document.getElementById('app-container'));