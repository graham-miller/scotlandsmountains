import React, { Component } from "react";
import { Router, Redirect, Route, browserHistory } from "react-router";

import { default as MountainsTitle } from "../mountains/Title";
import { default as MountainTitle } from "../mountain/Title";
import Search from "../search/Search";

class TitleRoutes extends Component {

    render() {
        return (
            <Router name="title" history={browserHistory}>
                <Redirect from="/" to="/mountains" />
                <Redirect from="/mountains" to="/mountains/munros" />
                <Route path="/mountains/:table" component={MountainsTitle} />
                <Route path="/mountain/:id(/:name)" component={MountainTitle} />
                <Route path="/search" component={Search} />
            </Router>
        );
    }
}

export default TitleRoutes;
