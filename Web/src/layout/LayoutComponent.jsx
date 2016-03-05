'use strict';

import '../styles/App.css';
import 'normalize.css';

import React from 'react';
import ReactDOM from 'react-dom';

import AppBarComponent from './AppBarComponent.jsx'
import ToolBarComponent from './ToolBarComponent.jsx'
import LeftNavComponent from './LeftNavComponent.jsx'
import MapComponent from '../map/MapComponent.jsx'

import LayoutStore from './LayoutStore';
import LayoutActions from './LayoutActions';

// Needed for onTouchTap, can be removed when react 1.0 is released https://github.com/zilverline/react-tap-event-plugin
import injectTapEventPlugin from 'react-tap-event-plugin';
injectTapEventPlugin();

class LayoutComponent extends React.Component {
     
    constructor(props) {
        super(props);
        this.state = LayoutStore.getState();
        
        // React components using ES6 classes no longer autobind `this` to non React methods
        this.onChange = this.onChange.bind(this)
    }

    componentDidMount() {
        LayoutStore.listen(this.onChange);
    }

    componentWillUnmount() {
        LayoutStore.unlisten(this.onChange);
    }
    
    onChange(state) {
        this.setState(state);
    }
    
    handleOpenLeftNav() {
        LayoutActions.openLeftNav();
    }
    
    handleCloseLeftNav() {
        LayoutActions.closeLeftNav();
    }
    
    handleOpenSearch() {
        LayoutActions.openSearch();
    }
    
    handleCloseSearch() {
        LayoutActions.closeSearch();
    }
    
    render() {
        
        return (
            <div id="react-root">
                <AppBarComponent
                    leftNavOpen={this.state.leftNavOpen}
                    onOpenLeftNav={this.handleOpenLeftNav}
                    onCloseLeftNav={this.handleCloseLeftNav} />
                <ToolBarComponent
                    searchOpen={this.state.searchOpen}
                    onOpenSearch={this.handleOpenSearch}
                    onCloseSearch={this.handleCloseSearch} />
                <LeftNavComponent open={this.state.leftNavOpen}/>
                <MapComponent />
            </div>
        );
    }
}

export default LayoutComponent;