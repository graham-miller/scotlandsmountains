import React, { Component } from "react";
import { browserHistory } from "react-router";

class Title extends Component {

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
            <h1>
                <a href="/" onClick={(e) => this.goToUrl("/", e)}>Scotland&apos;s Mountains</a>
            </h1>
        );
    }
}

export default Title;
