require('normalize.css');
require('styles/App.css');

import React from 'react';
import AppBarComponent from './layout/AppBarComponent'
import LeftNavComponent from './layout/LeftNavComponent'

class AppComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = {open: false};
    }

    handleToggle() {
        this.setState({open: !this.state.open});
    }

    render() {
        return (
            <div>
                <AppBarComponent />
                <LeftNavComponent />
            </div>
            );
    }
}

AppComponent.defaultProps = { };

export default AppComponent;