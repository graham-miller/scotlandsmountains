import React, { Component } from "react";
import { browserHistory } from "react-router";

import AppBar from "material-ui/AppBar";
import Drawer from "material-ui/Drawer";

import Nav from "./Nav";

import Logo from "../common/Logo";

class Title extends Component {

    constructor() {
        super();

        this.state = {drawerOpen: false};

        this.toggleDrawer = this.toggleDrawer.bind(this);
        this.closeDrawer = this.closeDrawer.bind(this);
        this.goToUrl = this.goToUrl.bind(this);
    }

    toggleDrawer() {
        this.setState({drawerOpen: !this.state.drawerOpen});
    }

    closeDrawer() {
        this.setState({drawerOpen: false});
    }

    goToUrl(url, event) {
        browserHistory.push(url);   
        event.preventDefault();
    }

    render() {

        let brand = (
            <span style={{cursor: "pointer"}}>
                Scotland&apos;s <Logo size="24px" color="#ffffff" />ountains
            </span>
        );

        return (
            <div>
                <AppBar
                    title={brand}
                    onTitleTouchTap={(e) => this.goToUrl("/", e)}
                    onLeftIconButtonTouchTap={this.toggleDrawer}
                    style={{position:"fixed",top:0}} />
                <Drawer
                    open={this.state.drawerOpen}
                    docked={false}
                    onRequestChange={(drawerOpen) => this.setState({drawerOpen})}
                    children={<Nav closeDrawer={this.closeDrawer} />} />
            </div>
        );
    }
}

export default Title;
