'use strict';

import './styles/app.less';
import 'normalize-css';

import React from 'react';
import ReactDOM from 'react-dom';
import { Router, Route, IndexRoute, Link } from 'react-router'
import { routerHistory } from './components/layout/history';

import AppComponent from './components/layout/AppComponent';
import AboutComponent from './components/content/AboutComponent';
import LegalComponent from './components/content/LegalComponent';
import injectTapEventPlugin from 'react-tap-event-plugin';

// Needed by material-ui for onTouchTap event.
// Can go away when react 1.0 release, check this repo:
// https://github.com/zilverline/react-tap-event-plugin
injectTapEventPlugin();

ReactDOM.render((
    <Router history={routerHistory}>
        <Route path="/" component={AppComponent}>
            <IndexRoute component={null} />
            <Route path="/about" component={AboutComponent} />
            <Route path="/legal" component={LegalComponent} />
            <Route path="/legal/:activeDoc" component={LegalComponent} />
        </Route>
    </Router>), document.getElementById('app-container'));