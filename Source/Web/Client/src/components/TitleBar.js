import React, { Component } from 'react';
import { Navbar, Nav, NavDropdown, MenuItem } from 'react-bootstrap';

class Titlebar extends Component {
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
                        <NavDropdown eventKey={1} title="Dropdown" id="basic-nav-dropdown">
                            <MenuItem eventKey={1.1}>Action</MenuItem>
                            <MenuItem eventKey={1.2}>Another action</MenuItem>
                            <MenuItem eventKey={1.3}>Something else here</MenuItem>
                            <MenuItem divider />
                            <MenuItem eventKey={1.3}>Separated link</MenuItem>
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}

export default Titlebar;
