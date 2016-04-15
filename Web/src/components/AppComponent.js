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
        var mapIsActive = this.props.children == null;
        var contentClassName = this.props.children == null ? 'hidden' : 'visible';

        return (
            <MuiThemeProvider muiTheme={theme}>
                <ContainerComponent
                    outerStyle={{backgroundColor:'#e8e8e8',height:'100%',paddingTop:'64px'}}
                    innerStyle={{height:'100%'}}
                    header={<AppBarComponent mapIsActive={mapIsActive} />}
                    content={
                        <div style={{height:'100%'}}>
                            <ContainerComponent
                                outerStyle={{display:mapIsActive?'block':'none',zIndex:1,height:'100%'}}
                                innerStyle={{height:'100%'}}
                                content={<MapComponent isActive={mapIsActive} />}
                                footer={mapIsActive ? <FooterComponent showHandle={true} /> : null } />
                            <ContainerComponent
                                outerStyle={{display:mapIsActive?'none':'block',zIndex:2,height:'100%',minHeight:'100%'}}
                                innerStyle={{minHeight:'100%',padding:'0px 1em 1em 1em'}}
                                content={this.props.children}
                                footer={mapIsActive ? null : <FooterComponent showHandle={false} />} />
                        </div>
                    } />
            </MuiThemeProvider>
        );
    }
}

export default AppComponent;