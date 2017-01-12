import React, { Component } from "react";
import { connect } from "react-redux";
import { Router, Redirect, Route, browserHistory } from "react-router";

import { clearMountains } from "../../state/actions";

import List from "../list/List";
import Mountain from "../mountain/Mountain";
import Results from "../search/Results";

class ContentRoutesComponent extends Component {

    constructor(props) {
        super(props);

        this.clearMountainsFromMap = this.clearMountainsFromMap.bind(this);
    }

    clearMountainsFromMap() {
        this.props.dispatch(clearMountains());
    }

    render() {
        return (
            <Router name="content" history={browserHistory}>
                <Redirect from='/' to='/mountains' />
                <Redirect from='/mountains' to='/mountains/munros' />
                <Route path='/mountains/:table' component={List} onLeave={this.clearMountainsFromMap} />
                <Route path='/mountain/:id(/:name)' component={Mountain} onLeave={this.clearMountainsFromMap} />
                <Route path='/search' component={Results} onLeave={this.clearMountainsFromMap} />
            </Router>
        );
    }
}

const ContentRoutes = connect()(ContentRoutesComponent);

export default ContentRoutes;
