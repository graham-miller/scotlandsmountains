'use strict';

import React from 'react';

import AppBar from 'material-ui/lib/app-bar';
import IconButton from 'material-ui/lib/icon-button';

import NavigationMenu from 'material-ui/lib/svg-icons/navigation/menu';
import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

import AccountComponent from '../Account/AccountComponent.js'

class AppBarComponent extends React.Component {

    constructor(props) {
        super(props);

        // React components using ES6 classes no longer autobind `this` to non React methods
        this.handleOpenLeftNav = this.handleOpenLeftNav.bind(this)
        this.handleCloseLeftNav = this.handleCloseLeftNav.bind(this)
    }
    
    handleOpenLeftNav() {
        this.props.onOpenLeftNav();
    }
    
    handleCloseLeftNav() {
        this.props.onCloseLeftNav();
    }

    render() {

        var menuButton;

        if(this.props.leftNavOpen) {
            menuButton = (
                <IconButton
                    tooltip="Close menu"
                    onTouchTap={this.handleCloseLeftNav}>
                    <NavigationClose />
                </IconButton>
            );
        } else {
            menuButton = (
                <IconButton
                    tooltip="Open menu"
                    onTouchTap={this.handleOpenLeftNav}>
                    <NavigationMenu />
                </IconButton>
            );
        }

        return (
            <AppBar
                id="app-bar-component"
                style={{position:'fixed',top:'0', height:'64', zIndex:'1400'}}
                iconElementLeft={menuButton}
                title={<span>Scotland&apos;s Mountains</span>}
                iconElementRight={<AccountComponent />}
                />
        );
    }
}

export default AppBarComponent;