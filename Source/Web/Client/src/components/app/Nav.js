import React, { Component } from "react";
import { browserHistory } from "react-router";

import MenuItem from "material-ui/MenuItem";

import Logo from "../common/Logo";

class Nav extends Component {

    constructor(props) {
        super(props);
        this.navigateTo = this.navigateTo.bind(this);
    }

    navigateTo(url, event) {
        browserHistory.push(url);
        this.props.closeDrawer();
        event.preventDefault();
    }


    render() {
        return (
            <div>
                <MenuItem onTouchTap={this.props.closeDrawer}
                    style={{height:"80px", paddingTop: "16px", textAlign:"Center"}}>
                    <Logo size="48px" color="#909740" />
                </MenuItem>
                <MenuItem onTouchTap={(e) => this.navigateTo("/mountains", e)}>Lists</MenuItem>
                <MenuItem onTouchTap={(e) => this.navigateTo("/search", e)}>Search</MenuItem>
            </div>
        );
    }
}

export default Nav;
