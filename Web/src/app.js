'use strict';

import React from 'react';
import ReactDOM from 'react-dom';

import LayoutComponent from './layout/LayoutComponent.js'

class App extends React.Component {

    render() {
        return (<LayoutComponent />);
    }
}

ReactDOM.render(<App/>, document.getElementById('app'));