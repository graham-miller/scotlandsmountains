'use strict';

import React from 'react';
import ReactDOM from 'react-dom';

import IconMenu from 'material-ui/lib/menus/icon-menu';
import IconButton from 'material-ui/lib/icon-button';

import ActionSearch from 'material-ui/lib/svg-icons/action/search';
import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

import SearchStore from './SearchStore';
import SearchActions from './SearchActions';

class SearchComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = SearchStore.getState();
        this.handleOpen = this.handleOpen.bind(this)
        this.handleClose = this.handleClose.bind(this)
        this.onChange = this.onChange.bind(this)
    }

    componentDidMount() {
        SearchStore.listen(this.onChange);
    }

    componentWillUnmount() {
        SearchStore.unlisten(this.onChange);
    }
    
    onChange(state) {
        this.setState(state);
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
                <span id="toolbar-search">
                    <IconButton
                        tooltip="Cancel search"
                        onTouchTap={this.handleClose} >
                        <NavigationClose />
                    </IconButton>
                    <input type="search" autoFocus placeholder="Search" />
                </span>
            );
        }
        
        return (
            <IconButton
                tooltip="Search"
                onTouchTap={this.handleOpen} >
                <ActionSearch />
            </IconButton>
        );
    }
}

export default SearchComponent;