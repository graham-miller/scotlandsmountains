'use strict';

import React from 'react';

import IconMenu from 'material-ui/lib/menus/icon-menu';
import IconButton from 'material-ui/lib/icon-button';

import ActionSearch from 'material-ui/lib/svg-icons/action/search';

class SearchComponent extends React.Component {

    constructor(props) {
        super(props);

        // React components using ES6 classes no longer autobind `this` to non React methods
        this.handleOpen = this.handleOpen.bind(this)
        this.handleClose = this.handleClose.bind(this)
    }
    
    handleOpen() {
        this.props.onOpen();
    }
    
    handleClose() {
        this.props.onClose();
    }
    
    render() {

        if (this.props.open) {
            return (
                <IconButton
                    tooltip="Search open"
                    onTouchTap={this.handleClose} >
                    <ActionSearch />
                </IconButton>
            );
        }
        
        return (
            <IconButton
                tooltip="Search closed"
                onTouchTap={this.handleOpen} >
                <ActionSearch />
            </IconButton>
        );
    }
}

export default SearchComponent;