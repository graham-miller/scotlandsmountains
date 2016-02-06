require('normalize.css');
require('styles/App.css');

import React from 'react';
//import injectTapEventPlugin from 'react-tap-event-plugin';
import TitleBar from './TitleBar'

// Needed for onTouchTap, can be removed when react 1.0 is released https://github.com/zilverline/react-tap-event-plugin
//injectTapEventPlugin();

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