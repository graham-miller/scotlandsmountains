import React, { Component } from "react";
import { connect } from "react-redux";
import { Router, Redirect, Route, browserHistory } from "react-router";

import { clearMountains } from "../../state/actions";

import MapWrapper from "./MapWrapper";
import { default as ListTitle } from "../list/Title";
import { default as ListContent } from "../list/List";
import { default as MountainTitle } from "../mountain/Title";
import { default as MountainContent } from "../mountain/Mountain";
import { default as SearchTitle } from "../search/Title";
import { default as SearchContent } from "../search/Results";

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
                <Redirect from='/' to='/mountains/munros' />
                <Redirect from='/mountains' to='/mountains/munros' />
                <Route component={MapWrapper} onChange={this.clearMountainsFromMap}>
                    <Route path='/mountains/:table' components={{title: ListTitle, content: ListContent}} />
                    <Route path='/mountain/:id(/:name)' components={{title: MountainTitle, content: MountainContent}} />
                    <Route path='/search' components={{title: SearchTitle, content: SearchContent}} />
                </Route>
                <Route path='/legal(/:type)' component={null} />
            </Router>
        );
    }
}

const ContentRoutes = connect()(ContentRoutesComponent);

export default ContentRoutes;
