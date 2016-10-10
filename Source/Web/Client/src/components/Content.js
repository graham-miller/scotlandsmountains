import React, { Component } from 'react';
import { Router, Route, browserHistory } from 'react-router'
import Home from './Home'
import Search from './Search'

class Content extends Component {

    render() {
        return (
            <Router history={browserHistory}>
                <Route path="/" component={Home} />
                <Route path="/search" component={Search} />
            </Router>
        );
    }
}

export default Content;
