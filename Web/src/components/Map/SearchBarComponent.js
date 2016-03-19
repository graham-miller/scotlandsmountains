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
            <Toolbar style={{height:'46'}}>
                <ToolbarGroup firstChild={true}>
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