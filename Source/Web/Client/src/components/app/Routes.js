import React, { Component } from "react";
import { connect } from "react-redux";
import { Router, Redirect, Route, browserHistory } from "react-router";

import { clearMountains } from "../../state/actions";

import App from "./App";
import { default as ListTitle } from "../list/Title";
import { default as ListContent } from "../list/List";
import { default as MountainTitle } from "../mountain/Title";
import { default as MountainContent } from "../mountain/Mountain";
import { default as SearchTitle } from "../search/Title";
import { default as SearchContent } from "../search/Results";

import Legal from "../legal/Legal";

import ContactUs from "../common/ContactUs";

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
            <Router onUpdate={() => window.scrollTo(0, 0)} name="content" history={browserHistory}>
                <Redirect from='/' to='/mountains/munros' />
                <Redirect from='/mountains' to='/mountains/munros' />
                <Route component={App}>
                    <Route onChange={this.clearMountainsFromMap}>
                        <Route path='/mountains/:table' components={{map: ListTitle, content: ListContent}} />
                        <Route path='/mountain/:id(/:name)' components={{map: MountainTitle, content: MountainContent}} />
                        <Route path='/search' components={{map: SearchTitle, content: SearchContent}} />
                    </Route>
                    <Route path='/legal(/:type)' components={{content: Legal}} />
                    <Route path='/contactus' components={{content: ContactUs}} />
                </Route>
            </Router>
        );
    }
}

const ContentRoutes = connect()(ContentRoutesComponent);

export default ContentRoutes;
