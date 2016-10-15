import React, { Component } from 'react';
import { Router, Route, browserHistory } from 'react-router';
import MountainsContainer from './MountainsContainer';
import Search from './Search';

class Content extends Component {

    render() {
        return (
            <Router history={browserHistory}>
                <Route path="/" component={MountainsContainer} />
                <Route path="/search" component={Search} />
            </Router>
        );
    }
}

export default Content;
