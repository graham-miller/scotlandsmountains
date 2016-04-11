'use strict';

import React from 'react';

import Toolbar from 'material-ui/lib/toolbar/toolbar';
import ToolbarGroup from 'material-ui/lib/toolbar/toolbar-group';
import IconButton from 'material-ui/lib/icon-button';
import IconMenu from 'material-ui/lib/menus/icon-menu';
import MenuItem from 'material-ui/lib/menus/menu-item';

import ActionSearch from 'material-ui/lib/svg-icons/action/search';
import ContentAddCircleOutline from 'material-ui/lib/svg-icons/content/add-circle-outline';
import ContentRemoveCircleOutline from 'material-ui/lib/svg-icons/content/remove-circle-outline';
import NavigationRefresh from 'material-ui/lib/svg-icons/navigation/refresh';
import MapsSatellite from 'material-ui/lib/svg-icons/maps/satellite';
import MapsMap from 'material-ui/lib/svg-icons/maps/map';
import MapsLayers from 'material-ui/lib/svg-icons/maps/layers';
import MapsMyLocation from 'material-ui/lib/svg-icons/maps/my-location';

class ToolBarComponent extends React.Component {

    render() {
        return (
            <Toolbar style={{ height: '46px' }}>
                <ToolbarGroup firstChild={true} style={{ float: 'none' }}>

                    <IconButton onTouchTap={this.props.toggleSearch}>
                        <ActionSearch />
                    </IconButton>
                    <IconButton onTouchTap={this.props.zoomIn}>
                        <ContentAddCircleOutline />
                    </IconButton>
                    <IconButton onTouchTap={this.props.zoomOut}>
                        <ContentRemoveCircleOutline />
                    </IconButton>
                    <IconButton onTouchTap={this.props.reset}>
                        <NavigationRefresh />
                    </IconButton>

                    <IconMenu
                        iconButtonElement={<IconButton><MapsLayers /></IconButton>}>
                        <MenuItem
                            onTouchTap={this.props.setBaseLayer.bind(this, 'map') }
                            primaryText="Map view"
                            leftIcon={<MapsMap />} />
                        <MenuItem
                            onTouchTap={this.props.setBaseLayer.bind(this, 'aerial') }
                            primaryText="Aerial view"
                            leftIcon={<MapsSatellite />} />
                    </IconMenu>

                    <IconButton>
                        <MapsMyLocation />
                    </IconButton>

                </ToolbarGroup>
            </Toolbar>
        );
    }
}

ToolBarComponent.propTypes = {
    toggleSearch: React.PropTypes.func.isRequired,
    zoomIn: React.PropTypes.func.isRequired,
    zoomOut: React.PropTypes.func.isRequired,
    reset: React.PropTypes.func.isRequired,
    setBaseLayer: React.PropTypes.func.isRequired
};

export default ToolBarComponent;