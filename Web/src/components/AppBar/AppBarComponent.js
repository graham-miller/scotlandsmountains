'use strict';

import React from 'react';

import AppBar from 'material-ui/lib/app-bar';
import IconButton from 'material-ui/lib/icon-button';

import NavigationMenu from 'material-ui/lib/svg-icons/navigation/menu';
import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

import AccountComponent from '../Account/AccountComponent.js'

class AppBarComponent extends React.Component {

    render() {

        return (
            <AppBar
                id="app-bar-component"
                style={{position:'fixed',top:'0', height:'64', zIndex:'1400'}}
                iconElementLeft={
                    <IconButton
                        onTouchTap={this.handleOpenLeftNav}>
                        <NavigationMenu />
                    </IconButton>
                }
                title={<span>Scotland&apos;s Mountains</span>}
                iconElementRight={<AccountComponent />}
                />
        );
    }
}

export default AppBarComponent;