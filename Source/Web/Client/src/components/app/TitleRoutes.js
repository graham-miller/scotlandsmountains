import React, { Component } from "react";
import { connect } from "react-redux";
import { Router, Redirect, Route, browserHistory } from "react-router";

import { clear } from "../../actions/mountains";

import Classification from "../classification/Classification";
import Mountain from "../mountain/Mountain";
import Search from "../search/Search";

class TitleRoutesComponent extends Component {

    constructor(props) {
        super(props);

        this.resetMountains = this.resetMountains.bind(this);
    }

    resetMountains() {
        this.props.dispatch(clear());
    }

    render() {
        return (
            <Router history={browserHistory}>
                <Redirect from='/' to='/mountains' />
                <Redirect from='/mountains' to='/mountains/munros' />
                <Route path='/mountains/:table' component={Classification} onLeave={this.resetMountains} />
                <Route path='/mountain/:id(/:name)' component={Mountain} onLeave={this.resetMountains} />
                <Route path='/search' component={Search} onLeave={this.resetMountains} />
            </Router>
        );
    }
}

const TitleRoutes = connect()(TitleRoutesComponent);

export default TitleRoutes;
