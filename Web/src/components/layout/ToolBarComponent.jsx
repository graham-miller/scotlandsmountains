import React from 'react';
import LayoutActions from '../../actions/LayoutActions';

import Toolbar from 'material-ui/lib/toolbar/toolbar';
import ToolbarGroup from 'material-ui/lib/toolbar/toolbar-group';
import IconButton from 'material-ui/lib/icon-button';

import ActionSearch from 'material-ui/lib/svg-icons/action/search';
import ContentAddCircleOutline from 'material-ui/lib/svg-icons/content/add-circle-outline';
import ContentRemoveCircleOutline from 'material-ui/lib/svg-icons/content/remove-circle-outline';
import NavigationRefresh from 'material-ui/lib/svg-icons/navigation/refresh';
import MapsSatellite from 'material-ui/lib/svg-icons/maps/satellite';
import MapsMap from 'material-ui/lib/svg-icons/maps/map';
import MapsLayers from 'material-ui/lib/svg-icons/maps/layers';
import MapsMyLocation from 'material-ui/lib/svg-icons/maps/my-location';
import ActionAccountCircle from 'material-ui/lib/svg-icons/action/account-circle';

class ToolBarComponent extends React.Component {
    render() {
        return (
            <Toolbar style={{position:'fixed',top:'64',minWidth:'440px', height:'46', zIndex:'1350'}}>
                <ToolbarGroup firstChild="true" float="left">
                    <IconButton tooltip="Search">
                        <ActionSearch />
                    </IconButton>
                    <IconButton tooltip="Zoom in">
                        <ContentAddCircleOutline />
                    </IconButton>
                    <IconButton tooltip="Zoom out">
                        <ContentRemoveCircleOutline />
                    </IconButton>
                    <IconButton tooltip="Reset">
                        <NavigationRefresh />
                    </IconButton>
                    <IconButton tooltip="Aerial view">
                        <MapsSatellite />
                    </IconButton>
                    <IconButton tooltip="Map view">
                        <MapsMap />
                    </IconButton>
                    <IconButton tooltip="Layers">
                        <MapsLayers />
                    </IconButton>
                    <IconButton tooltip="My location">
                        <MapsMyLocation />
                    </IconButton>
                </ToolbarGroup>
                <ToolbarGroup lastChild="true" float="right">
                    <IconButton tooltip="Login">
                        <ActionAccountCircle />
                    </IconButton>
                </ToolbarGroup>
            </Toolbar>
        );
    }
}

export default ToolBarComponent;