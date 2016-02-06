import React from 'react';
import AppBar from 'material-ui/lib/app-bar';
import FlatButton from 'material-ui/lib/flat-button';

const TitleBar = () => (
    <AppBar
        title={<span>Scotland's Mountains</span>}
        iconElementRight={<FlatButton label="Login" />} />
);

export default TitleBar;