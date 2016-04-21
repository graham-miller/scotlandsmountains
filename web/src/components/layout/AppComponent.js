'use strict';

import React from 'react';
import AppBarComponent from './AppBarComponent';
import ContainerComponent from './ContainerComponent';
import MapComponent from '../map/MapComponent';
import FooterComponent from './FooterComponent';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import theme from './theme'; 

class AppComponent extends React.Component {

    constructor(props) {
        super(props);

        this.state = {mapIsActive: this.props.children == null};

        this.componentWillReceiveProps = this.componentWillReceiveProps.bind(this);
    }

    componentWillReceiveProps (nextProps) {
        this.setState({mapIsActive: nextProps.children == null});
    }

    render() {

        let mapIsActive = this.state.mapIsActive;

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

        return (
            <MuiThemeProvider muiTheme={theme}>
                {app}
            </MuiThemeProvider>
        );
    }
}

export default AppComponent;