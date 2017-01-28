import React, { Component } from "react";
import { Link } from "react-router";

import MenuItem from "material-ui/MenuItem";

import Logo from "../common/Logo";

class Nav extends Component {

    render() {
        return (
            <div>
                <MenuItem onTouchTap={this.props.closeDrawer}
                    style={{height:"80px", paddingTop: "16px", textAlign:"Center"}}>
                    <Logo size="48px" color="#909740" />
                </MenuItem>
                <MenuItem onTouchTap={this.props.closeDrawer}>
                    <Link to="/mountains" className="nav">Lists</Link>
                </MenuItem>
                <MenuItem onTouchTap={this.props.closeDrawer}>
                    <Link to="/search" className="nav">Search</Link>
                </MenuItem>
                <MenuItem onTouchTap={this.props.closeDrawer}>
                    <Link to="/contactus" className="nav">Contact us</Link>
                </MenuItem>
            </div>
        );
    }
}

export default Nav;
