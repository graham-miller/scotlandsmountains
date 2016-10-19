import React, { Component } from 'react';
import { Router, Redirect, Route, browserHistory } from 'react-router';
import MountainsContainer from '../mountains/MountainsContainer';
import MountainContainer from '../mountain/MountainContainer';
import SearchContainer from '../search/SearchContainer';

class Routes extends Component {

    render() {
        return (
            <Router history={browserHistory}>
                <Redirect from='/' to='/mountains/munros' />
                <Route path='/mountains/:table' component={MountainsContainer} />
                <Route path='/mountain/:id/:name' component={MountainContainer} />
                <Route path='/search' component={SearchContainer} />
            </Router>
        );
    }
}

export default Routes;
