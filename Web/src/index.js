require('./styles/App.css');
require('normalize.css');

import React from 'react';
import ReactDOM from 'react-dom';

import AppBarComponent from './components/layout/AppBarComponent.jsx'
import LeftNavComponent from './components/layout/LeftNavComponent.jsx'
import MapComponent from './components/map/MapComponent.jsx'

// Needed for onTouchTap, can be removed when react 1.0 is released https://github.com/zilverline/react-tap-event-plugin
import injectTapEventPlugin from 'react-tap-event-plugin';
injectTapEventPlugin();

class App extends React.Component {

    render() {
        return (
            <div id="react-root">
                <AppBarComponent />
                <LeftNavComponent />
                <MapComponent />
            </div>
            );
    }
}

ReactDOM.render(<App/>, document.getElementById('app'));