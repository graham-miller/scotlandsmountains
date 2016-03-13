'use strict';

import React from 'react';

import Toolbar from 'material-ui/lib/toolbar/toolbar';
import ToolbarGroup from 'material-ui/lib/toolbar/toolbar-group';
import IconButton from 'material-ui/lib/icon-button';
import IconMenu from 'material-ui/lib/menus/icon-menu';
import MenuItem from 'material-ui/lib/menus/menu-item';

class SearchBarComponent extends React.Component {

    render() {
        
        return (
            <Toolbar style={{position:'fixed',top:'110',minWidth:'440px', height:'36', zIndex:'1350'}}>
                <ToolbarGroup firstChild={true} float="left">
                    <input
                        type="search" ref="search"
                        autoFocus placeholder="Search"
                        style={{marginLeft:'12px',width:'264px'}} />                  
                </ToolbarGroup>
            </Toolbar>
        );
    }
}

export default SearchBarComponent;