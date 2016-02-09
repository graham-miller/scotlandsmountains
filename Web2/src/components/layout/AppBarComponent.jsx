import React from 'react';
import AppBar from 'material-ui/lib/app-bar';
import FlatButton from 'material-ui/lib/flat-button';

const AppBarComponent = () => (
    <AppBar
        style={{position:'fixed',top:'0',zIndex:'1400'}}
        showMenuIconButton={true}
        title={<span>Scotland&apos;s Mountains</span>}
        iconElementRight={<FlatButton label="Login" />}
        />
);

export default AppBarComponent;