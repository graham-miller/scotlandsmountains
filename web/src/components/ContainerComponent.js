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
                            
                            <ContainerComponent
                                outerStyle={{display: mapIsActive ? 'none' : 'block', zIndex: 2, backgroundColor: '#e8e8e8', minHeight: '100%'}}
                                innerStyle={{minHeight: '100%', padding: '0px 1em 1em 1em'}}
                                content={this.props.children}
                                footer={mapIsActive ? null : <FooterComponent showHandle={false} />} />
                            
                            {
                            // <div id="content-container-outer" className={mapIsActive ? 'active' : 'visible'}>
                            //     <div id="content-container-inner">
                            //         {this.props.children}
                            //     </div>
                            //     {mapIsActive ? null : <FooterComponent showHandle={false} /> }
                            // </div>
                            }
                        </div>
                    </div>          
                </div>          
            </MuiThemeProvider>
        );
    }
}

export default AppComponent;


'use strict';

import React from 'react';

class ContainerComponent extends React.Component {

    render() {

        const baseOuterStyle = {
            boxSizing: 'border-box',
            position: 'absolute',
            width: '100%',
            top: '0px'
        }
        
        const baseInnerStyle = {
            boxSizing: 'border-box',
            position: 'relative',
            width: '100%'
        }
        
        return (
            <div style={Object.assign(baseOuterStyle, this.props.outerStyle)}>
                { this.props.header }
                <div style={Object.assign(baseInnerStyle, this.props.innerStyle)}>
                { this.props.content }
                </div>
                { this.props.footer }
            </div>
        );
    }
}

ContainerComponent.defaultProps = {
    header: null,
    content: null,
    footer: null
};

export default ContainerComponent;


