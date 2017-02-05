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
import Legal from "../other/Legal";
import ContactUs from "../other/ContactUs";

class ContentRoutesComponent extends Component {

    clearMountainsFromMap = (prevState, nextState) => {
        if (prevState.location.pathname !== nextState.location.pathname) {
            this.props.dispatch(clearMountains());
        }
    }

    render() {
        return (
            <Router onUpdate={() => window.scrollTo(0, 0)} name="content" history={browserHistory}>
                <Redirect from='/' to='/lists' />
                <Route component={App}>
                    <Route onChange={this.clearMountainsFromMap}>
                        <Route path='/lists(/:id)(/:name)' components={{map: ListTitle, content: ListContent}} />
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
