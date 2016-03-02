import React from 'react';
import LayoutActions from '../../actions/LayoutActions';
import AppBar from 'material-ui/lib/app-bar';
import IconButton from 'material-ui/lib/icon-button';

import NavigationMenu from 'material-ui/lib/svg-icons/navigation/menu';

class AppBarComponent extends React.Component {
    render() {
        return (
            <AppBar
                style={{position:'fixed',top:'0', height:'64', zIndex:'1400'}}
                iconElementLeft={
                    <IconButton
                        tooltip="Main menu"
                        onTouchTap={LayoutActions.toggleLeftNav}>
                        <NavigationMenu />
                    </IconButton>
                }
                title={<span>Scotland&apos;s Mountains</span>}
                />
        );
    }
}

export default AppBarComponent;