import React, { Component } from 'react';
import { Router, Route, browserHistory } from 'react-router'
import Home from './Home'
import Search from './Search'
import About from './About'

class Content extends Component {

    render() {
        return (
            <Router history={browserHistory}>
                <Route path="/" component={Home} />
                <Route path="/search" component={Search} />
                <Route path="/about" component={About} />
            </Router>
        );
    }
}

export default Content;
