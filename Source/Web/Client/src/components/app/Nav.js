import React, { Component } from "react";
import { connect } from "react-redux";
import { Link } from "react-router";

import { fetchLists } from "../../state/lists";

import MenuItem from "material-ui/MenuItem";

import Logo from "../common/Logo";

class NavComponent extends Component {

    constructor(props) {
        super(props);
        this.props.dispatch(fetchLists());
    }

    render() {

        return (
            <div>
                <MenuItem onTouchTap={this.props.closeDrawer}
                    style={{ height: "80px", paddingTop: "16px", textAlign: "Center" }}>
                    <Logo size="48px" color="#909740" />
                </MenuItem>

                <MenuItem onTouchTap={this.props.closeDrawer}>
                    <Link to="/search" className="nav">Search</Link>
                </MenuItem>

                <MenuItem
                    primaryText="Lists"
                    initiallyOpen={false}
                    primaryTogglesNestedList={true}
                    nestedItems={
                        this.props.lists.map((list, index) =>
                            <MenuItem key={index} onTouchTap={this.props.closeDrawer}>
                                <Link to={"/mountains/" + list.name} className="nav">{list.name}</Link>
                            </MenuItem>
                        )
                    } />

                <MenuItem onTouchTap={this.props.closeDrawer}>
                    <Link to="/contactus" className="nav">Contact us</Link>
                </MenuItem>
            </div >
        );
    }
}

const mapStateToProps = (state) => {
    return {
        lists: state.lists
    };
};

const Nav = connect(mapStateToProps)(NavComponent);

export default Nav;
