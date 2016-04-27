'use strict';

import React from 'react';
import AppBar from 'material-ui/AppBar';
import IconButton from 'material-ui/IconButton';
import NavigationMenu from 'material-ui/svg-icons/navigation/menu';
import NavigationClose from 'material-ui/svg-icons/navigation/close';
import AccountComponent from './AccountComponent';
import LeftNavComponent from './LeftNavComponent';

class AppBarComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = { leftNavOpen: false };
        this.openLeftNav = this.openLeftNav.bind(this); 
        this.closeLeftNav = this.closeLeftNav.bind(this); 
    }

    openLeftNav() {
        this.setState({ leftNavOpen: true });
    }

    closeLeftNav() {
        this.setState({ leftNavOpen: false });
    }

    render() {

        return (
            <div>
                <AppBar
                    className="fixed-to-top"
                    iconElementLeft={
                        <IconButton
                            onTouchTap={this.openLeftNav}>
                            <NavigationMenu />
                        </IconButton>
                    }
                    title={<a href="/" id="app-name">Scotland&apos;s Mountains</a>}
                    iconElementRight={<AccountComponent />} >
                </AppBar>
                <LeftNavComponent
                    mapIsActive={this.props.mapIsActive}
                    open={this.state.leftNavOpen}
                    close={this.closeLeftNav} />
            </div>
        );
    }
}

export default AppBarComponent;