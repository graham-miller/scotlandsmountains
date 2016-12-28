import React, { Component } from "react";
import { browserHistory } from "react-router";

import MenuItem from "material-ui/MenuItem";

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
                <MenuItem style={{height:"64px",textAlign:"Center"}}>M</MenuItem>
                <MenuItem onTouchTap={(e) => this.navigateTo("/mountains", e)}>Lists</MenuItem>
                <MenuItem onTouchTap={(e) => this.navigateTo("search", e)}>Search</MenuItem>
            </div>
        );
    }
}

export default Nav;
