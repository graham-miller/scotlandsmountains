import React, { Component } from "react";
import { Link } from "react-router";
import AppBar from "material-ui/AppBar";
import Drawer from "material-ui/Drawer";
import Nav from "./Nav";
import Logo from "../other/Logo";

class Header extends Component {

    constructor() {
        super();
        this.state = {drawerOpen: false};
    }

    toggleDrawer = () => this.setState({drawerOpen: !this.state.drawerOpen});

    closeDrawer = () => this.setState({drawerOpen: false});

    render() {

        let brand = (
            <Link to="/" className="brand">
                Scotland&apos;s <Logo size="24px" color="#ffffff" />ountains
            </Link>
        );

        return (
            <div id="header">
                <AppBar
                    title={brand}
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

export default Header;
