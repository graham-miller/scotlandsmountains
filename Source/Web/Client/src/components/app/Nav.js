import React, { Component } from "react";
import { browserHistory } from "react-router";

class NavItem extends Component {

    constructor() {
        super();
        this.goToUrl = this.goToUrl.bind(this);
    }

    goToUrl(url, event) {
        browserHistory.push(url);   
        event.preventDefault();
    }

    render() {

        const path = this.props.path;
        const text = this.props.text;

        let className = "nav-item";

        if (window.location.pathname.indexOf(path) === 0) {
            className += " active";
        }

        return (
            <a className={className} href={path} onClick={(e) => this.goToUrl(path, e)}>{text}</a>
        );
    }
}

class Nav extends Component {


    render() {
        return (
            <nav>
                <NavItem path="/mountains" text="Lists" />
                <NavItem path="/search" text="Search" />
            </nav>
        );
    }
}

export default Nav;
