import React, { Component } from 'react';
import { browserHistory } from 'react-router'
import { Navbar, Nav, NavItem } from 'react-bootstrap';

class Title extends Component {

    constructor() {
        super();
        this.goToUrl = this.goToUrl.bind(this);
    }

    goToUrl(url, event) {
        browserHistory.push(url);   
        event.preventDefault();
    }

    render() {
        return (
            <Navbar fixedTop fluid>
                <Navbar.Header>
                    <Navbar.Brand>
                        <a href="/" onClick={(e) => this.goToUrl('/', e)}>Scotland&apos;s Mountains</a>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav pullRight>
                        <NavItem eventKey={1} href="/search" onClick={(e) => this.goToUrl('/search', e)}>Search</NavItem>
                        <NavItem eventKey={1} href="/about" onClick={(e) => this.goToUrl('/about', e)}>About</NavItem>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}

export default Title;
