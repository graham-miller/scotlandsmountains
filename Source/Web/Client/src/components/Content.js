import React, { Component } from 'react';
import { Router, Route, Link, browserHistory } from 'react-router'
import Search from './Search'
import About from './About'

class Content extends Component {

    render() {
        return (
            <Router history={browserHistory}>
                <Route path="/" component={Search}>
                    {/*
                    <Route path="/about" component={About}/>
                    <Route path="users" component={Users}>
                    <Route path="/user/:userId" component={User}/>
                    */}
                </Route>
                {/*
                <Route path="*" component={NoMatch}/></Route>
                */}
                <Route path="/about" component={About}/>
            </Router>
        );
    }
}

export default Content;
