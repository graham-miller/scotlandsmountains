import React, { Component } from "react";
import { connect } from "react-redux";
import { Link } from "react-router";
import MenuItem from "material-ui/MenuItem";
import Logo from "../other/Logo";
import { toFriendlyUrlName } from "../../utility";

class NavComponent extends Component {

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
                        this.props.staticData.value.lists.map((list, index) =>
                            <MenuItem key={index} onTouchTap={this.props.closeDrawer}>
                                <Link
                                    to={"/lists/" + list.id + "/" + toFriendlyUrlName(list.name)}
                                    className="nav">{list.name}</Link>
                            </MenuItem>
                        )
                    } />

                <MenuItem onTouchTap={this.props.closeDrawer}>
                    <a href="https://github.com/graham-miller/scotlandsmountains/issues/new" target="_blank" className="nav">Report a problem</a>
                </MenuItem>

                <MenuItem onTouchTap={this.props.closeDrawer}>
                    <Link to="/contactus" className="nav">Contact us</Link>
                </MenuItem>
            </div >
        );
    }
}

const mapStateToProps = (state) => {
    return {
        staticData: state.staticData
    };
};

const Nav = connect(mapStateToProps)(NavComponent);

export default Nav;
