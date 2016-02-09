require('./styles/App.css');
require('normalize.css');

import React from 'react';
import ReactDOM from 'react-dom';

import AppBarComponent from './components/layout/AppBarComponent.jsx'
import LeftNavComponent from './components/layout/LeftNavComponent.jsx'
import MapComponent from './components/map/MapComponent.jsx'

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