'use strict';

import React from 'react';
import MapActions from '../map/MapActions';

import IconButton from 'material-ui/lib/icon-button';
import IconMenu from 'material-ui/lib/menus/icon-menu';
import MenuItem from 'material-ui/lib/menus/menu-item';

import ContentAddCircleOutline from 'material-ui/lib/svg-icons/content/add-circle-outline';
import ContentRemoveCircleOutline from 'material-ui/lib/svg-icons/content/remove-circle-outline';
import NavigationRefresh from 'material-ui/lib/svg-icons/navigation/refresh';
import MapsSatellite from 'material-ui/lib/svg-icons/maps/satellite';
import MapsMap from 'material-ui/lib/svg-icons/maps/map';
import MapsLayers from 'material-ui/lib/svg-icons/maps/layers';
import MapsMyLocation from 'material-ui/lib/svg-icons/maps/my-location';

class MapButtonsComponent extends React.Component {

    render() {
        return (        
            <span>
                <IconButton tooltip="Zoom in" onTouchTap={MapActions.zoomIn}>
                    <ContentAddCircleOutline />
                </IconButton>
                <IconButton tooltip="Zoom out" onTouchTap={MapActions.zoomOut}>
                    <ContentRemoveCircleOutline />
                </IconButton>
                <IconButton tooltip="Reset" onTouchTap={MapActions.reset}>
                    <NavigationRefresh />
                </IconButton>

                <IconMenu
                    iconButtonElement={
                        <IconButton tooltip="Layers">
                            <MapsLayers />
                        </IconButton>
                    }>
                    <MenuItem primaryText="Map view" leftIcon={<MapsMap />} />
                    <MenuItem primaryText="Aerial view" leftIcon={<MapsSatellite />} />
                </IconMenu>

                <IconButton tooltip="My location">
                    <MapsMyLocation />
                </IconButton>
            </span>  
        );
    }
}

export default MapButtonsComponent;