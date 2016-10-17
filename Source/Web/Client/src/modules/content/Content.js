import React, { Component } from 'react';
import { Router, Redirect, Route, browserHistory } from 'react-router';
import MountainsContainer from './MountainsContainer';
import SearchContainer from './SearchContainer';

class Content extends Component {

    render() {
        return (
            <Router history={browserHistory}>
                <Redirect from="/" to="/mountains/munros" />
                <Route path="/mountains/:table" component={MountainsContainer} />
                <Route path="/search" component={SearchContainer} />
            </Router>
        );
    }
}

export default Content;
