'use strict';

import React from 'react';

import AppBarComponent from './AppBarComponent';
import MapComponent from './MapComponent';
import FooterComponent from './FooterComponent';
import MuiThemeProvider from 'material-ui/lib/MuiThemeProvider';
import theme from '../scripts/theme'; 

class AppComponent extends React.Component {

    render() {
        var mapIsActive = this.props.children == null;
        var contentClassName = this.props.children == null ? 'hidden' : 'visible';

        return (
            <MuiThemeProvider muiTheme={theme}>
                <div id="app-component">
                    <AppBarComponent mapIsActive={mapIsActive} />
                    <div id="below-app-bar-outer">
                        <div id="below-app-bar-inner">
                            <div id="map-container-outer">
                                <div id="map-container-inner">
                                    <MapComponent isActive={mapIsActive} />
                                </div>
                                {mapIsActive ? <FooterComponent showHandle={true} /> : null }
                            </div>
                            <div id="content-container-outer" className={mapIsActive ? 'active' : 'visible'}>
                                <div id="content-container-inner">
                                    {this.props.children}
                                </div>
                                {mapIsActive ? null : <FooterComponent showHandle={false} /> }
                            </div>
                        </div>
                    </div>          
                </div>          
            </MuiThemeProvider>
        );
    }
}

export default AppComponent;