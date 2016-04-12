'use strict';

import React from 'react';

import AppBar from 'material-ui/lib/app-bar';
import IconButton from 'material-ui/lib/icon-button';

import NavigationMenu from 'material-ui/lib/svg-icons/navigation/menu';
import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

import AccountComponent from './AccountComponent';
import LeftNavComponent from './LeftNavComponent';

class AppBarComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = { leftNavIsOpen: false };
        this.openLeftNav = this.openLeftNav.bind(this); 
        this.closeLeftNav = this.closeLeftNav.bind(this); 
    }

    openLeftNav() {
        this.setState({ leftNavIsOpen: true });
    }

    closeLeftNav() {
        this.setState({ leftNavIsOpen: false });
    }

    render() {

        return (
            <div>
                <AppBar
                    id="app-bar-component"
                    style={{ position: 'fixed', top: '0px' }}
                    iconElementLeft={
                        <IconButton
                            onTouchTap={this.openLeftNav}>
                            <NavigationMenu />
                        </IconButton>
                    }
                    title={<span>Scotland&apos;s Mountains</span>}
                    iconElementRight={<AccountComponent />} >
                </AppBar>
                <LeftNavComponent
                    mapIsActive={this.props.mapIsActive}
                    isOpen={this.state.leftNavIsOpen}
                    close={this.closeLeftNav} />
            </div>
        );
    }
}

export default AppBarComponent;