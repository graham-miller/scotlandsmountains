import React from 'react';
import LayoutStore from './LayoutStore';
import LayoutActions from './LayoutActions';

import AppBar from 'material-ui/lib/app-bar';
import IconButton from 'material-ui/lib/icon-button';

import NavigationMenu from 'material-ui/lib/svg-icons/navigation/menu';
import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

import AccountComponent from '../account/AccountComponent.jsx'

class AppBarComponent extends React.Component {
     
    constructor(props) {
        super(props);
        this.state = LayoutStore.getState();
        
        // React components using ES6 classes no longer autobind `this` to non React methods
        this.onChange = this.onChange.bind(this)
    }

    componentDidMount() {
        LayoutStore.listen(this.onChange);
    }

    componentWillUnmount() {
        LayoutStore.unlisten(this.onChange);
    }
    
    onChange(state) {
        this.setState(state);
    }

    render() {

        var menuButton;

        if(this.state.leftNavOpen) {
            menuButton = (
                <IconButton
                    tooltip="Close menu"
                    onTouchTap={LayoutActions.closeLeftNav}>
                    <NavigationClose />
                </IconButton>
            );
        } else {
            menuButton = (
                <IconButton
                    tooltip="Open menu"
                    onTouchTap={LayoutActions.openLeftNav}>
                    <NavigationMenu />
                </IconButton>
            );
        }



        return (
            <AppBar
                className="app-bar"
                style={{position:'fixed',top:'0', height:'64', zIndex:'1400'}}
                iconElementLeft={menuButton}
                title={<span>Scotland&apos;s Mountains</span>}
                iconElementRight={<AccountComponent />}
                />
        );
    }
}

export default AppBarComponent;