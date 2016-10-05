import React, { Component } from 'react';
import { browserHistory } from 'react-router'
import { Navbar, Nav, NavDropdown, MenuItem, NavItem } from 'react-bootstrap';

class Titlebar extends Component {

    goToUrl(url) {
        browserHistory.push(url);
    }

    render() {
        return (
            <Navbar fixedTop fluid>
                <Navbar.Header>
                    <Navbar.Brand>
                        <a href="#">Scotland&apos;s Mountains</a>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav pullRight>
                        <NavItem eventKey={1} href="#" onClick={this.goToUrl('/about')}>About</NavItem>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}

export default Titlebar;
