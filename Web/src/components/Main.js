require('normalize.css');
require('styles/App.css');

import React from 'react';
import TitleBar from './TitleBar'

// Before you do any rendering, initialize the plugin
import injectTapEventPlugin from 'react-tap-event-plugin';
injectTapEventPlugin();

class AppComponent extends React.Component {
    render() {
        return (
            <div>
                <TitleBar />
            </div>
            );
    }
}

AppComponent.defaultProps = {
};

export default AppComponent;