'use strict';

import React from 'react';
import AppBarComponent from './AppBarComponent';
import ContainerComponent from './ContainerComponent';
import MapComponent from './MapComponent';
import FooterComponent from './FooterComponent';
import MuiThemeProvider from 'material-ui/lib/MuiThemeProvider';
import theme from '../scripts/theme'; 

class AppComponent extends React.Component {

    render() {

        let mapIsActive = this.props.children == null;

        let map = <ContainerComponent
            outerClassName={'map ' + (mapIsActive ? 'active' : 'inactive')} 
            innerClassName="map"
            content={<MapComponent isActive={mapIsActive} />}
            footer={mapIsActive ? <FooterComponent showHandle={true} /> : null } />

        let content = <ContainerComponent
            outerClassName={'content ' + (mapIsActive ? 'inactive' : 'active')} 
            innerClassName="content"
            content={this.props.children}
            footer={mapIsActive ? null : <FooterComponent showHandle={false} />} />

        let app = <ContainerComponent
            outerClassName="app" innerClassName="app"
            header={<AppBarComponent mapIsActive={mapIsActive} />}
            content={<div style={{height:'100%'}}>{map}{content}</div>} />

        return (<MuiThemeProvider muiTheme={theme}>{app}</MuiThemeProvider>);
    }
}

export default AppComponent;