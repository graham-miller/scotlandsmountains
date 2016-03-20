'use strict';

import React from 'react';

import AppBar from 'material-ui/lib/app-bar';
import IconButton from 'material-ui/lib/icon-button';

import NavigationMenu from 'material-ui/lib/svg-icons/navigation/menu';
import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

import AccountComponent from '../Account/AccountComponent.js'
import LeftNavComponent from '../LeftNav/LeftNavComponent.js'

class AppBarComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = { leftNavOpen: false };
        this.handleOpenLeftNav = this.handleOpenLeftNav.bind(this); 
        this.handleCloseLeftNav = this.handleCloseLeftNav.bind(this); 
    }

    handleOpenLeftNav() {
        this.setState({ leftNavOpen: true })
    }

    handleCloseLeftNav() {
        this.setState({ leftNavOpen: false })
    }

    render() {

        return (
            <div>
                <AppBar
                    id="app-bar-component"
                    style={{ position: 'fixed', top: '0' }}
                    iconElementLeft={
                        <IconButton
                            onTouchTap={this.state.leftNavOpen ? this.handleCloseLeftNav : this.handleOpenLeftNav}>
                            <NavigationMenu />
                        </IconButton>
                    }
                    title={<span>Scotland&apos; s Mountains</span>}
                    iconElementRight={<AccountComponent />} >
                </AppBar>
                <LeftNavComponent
                    open={this.state.leftNavOpen}
                    onClose={this.handleCloseLeftNav} />
            </div>
        );
    }
}

export default AppBarComponent;