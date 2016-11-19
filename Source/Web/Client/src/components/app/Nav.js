import React, { Component } from "react";
import { browserHistory } from "react-router";

class Nav extends Component {

    constructor() {
        super();
        this.goToUrl = this.goToUrl.bind(this);
    }

    goToUrl(url, event) {
        browserHistory.push(url);   
        event.preventDefault();
    }

    render() {
        return (
            <nav>
                <a className="nav-item" href="/mountains" onClick={(e) => this.goToUrl("/mountains", e)}>Lists</a>
                <a className="nav-item" href="/search" onClick={(e) => this.goToUrl("/search", e)}>Search</a>
            </nav>
        );
    }
}

export default Nav;
