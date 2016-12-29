import React, { Component } from "react";
import { Router, Redirect, Route, browserHistory } from "react-router";

import { default as list } from "../list/Title";
import { default as mountain } from "../mountain/Title";
import { default as search } from "../search/Title";

class TitleRoutes extends Component {

    render() {
        return (
            <Router name="title" history={browserHistory}>
                <Redirect from="/" to="/mountains" />
                <Redirect from="/mountains" to="/mountains/munros" />
                <Route path="/mountains/:table" component={list} />
                <Route path="/mountain/:id(/:name)" component={mountain} />
                <Route path="/search" component={search} />
            </Router>
        );
    }
}

export default TitleRoutes;
