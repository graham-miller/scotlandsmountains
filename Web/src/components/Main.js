require('normalize.css');
require('styles/App.css');

import React from 'react';
import AppBarComponent from './layout/AppBarComponent'
import LeftNavComponent from './layout/LeftNavComponent'
import MapComponent from './map/MapComponent'

class AppComponent extends React.Component {

    render() {
        return (
            <div id="app-component">
                <AppBarComponent />
                <LeftNavComponent />
                <MapComponent />
            </div>
            );
    }
}

AppComponent.defaultProps = { };

export default AppComponent;