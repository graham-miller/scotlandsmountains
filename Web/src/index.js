import React from 'react';
import ReactDOM from 'react-dom';

import LayoutComponent from './layout/LayoutComponent.jsx'

class App extends React.Component {

    render() {
        return (<LayoutComponent />);
    }
}

ReactDOM.render(<App/>, document.getElementById('app'));