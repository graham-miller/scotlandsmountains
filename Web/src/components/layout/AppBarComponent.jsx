import React from 'react';
import LayoutActions from '../../actions/LayoutActions';
import AppBar from 'material-ui/lib/app-bar';
import FlatButton from 'material-ui/lib/flat-button';

class AppBarComponent extends React.Component {
    render() {
        return (
            <AppBar
                style={{position:'fixed',top:'0',zIndex:'1400'}}
                showMenuIconButton={true}
                onLeftIconButtonTouchTap={LayoutActions.toggleLeftNav}
                title={<span>Scotland&apos;s Mountains</span>}
                iconElementRight={<FlatButton label="Login" />}
                />
        );
    }
}

export default AppBarComponent;