import React, { Component } from 'react';
import { browserHistory } from 'react-router'
import { Navbar, Nav, NavItem } from 'react-bootstrap';

class Title extends Component {

    goToUrl(url, event) {
        browserHistory.push(url);   
        event.preventDefault();
    }

    render() {
        var that = this;

        return (
            <Navbar fixedTop fluid>
                <Navbar.Header>
                    <Navbar.Brand>
                        <a href="/" onClick={that.goToUrl.bind(that, '/')}>Scotland&apos;s Mountains</a>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav pullRight>
                        <NavItem eventKey={1} href="/search" onClick={that.goToUrl.bind(that, '/search')}>Search</NavItem>
                        <NavItem eventKey={1} href="/about" onClick={that.goToUrl.bind(that, '/about')}>About</NavItem>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}

export default Title;
