'use strict';

import React from 'react';

import AppBarComponent from './AppBarComponent';
import MapComponent from './MapComponent';
import FooterComponent from './FooterComponent';

class AppComponent extends React.Component {

    render() {
        var mapIsActive = this.props.children == null;
        var contentClassName = this.props.children == null ? 'hidden' : 'visible';

        return (
            <div id="app-component">
                <AppBarComponent />
                <div id="below-app-bar-outer">
                    <div id="below-app-bar-inner">
                        <div id="map-container-outer">
                            <div id="map-container-inner">
                                <MapComponent />
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
        );
    }
}

export default AppComponent;