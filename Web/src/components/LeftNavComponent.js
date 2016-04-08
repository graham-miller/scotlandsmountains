'use strict';

import React from 'react';
import { Link } from 'react-router'
import { history } from '../scripts/history'

import LeftNav from 'material-ui/lib/left-nav';
import MenuItem from 'material-ui/lib/menus/menu-item';
import RaisedButton from 'material-ui/lib/raised-button';

import NavigationArrowBack from 'material-ui/lib/svg-icons/navigation/arrow-back';

class LeftNavComponent extends React.Component {

    constructor(props) {
        super(props);
        this.handleSelect = this.handleSelect.bind(this);
    }
    
    handleSelect(url) {
        this.props.close();
        if(url !== undefined) {
            history.push(url);
        }
    }

    render() {
        return (
            <LeftNav open={this.props.isOpen}>
                <MenuItem onTouchTap={() => {this.handleSelect()}} style={{ padding: '12px 0 4px 6px' }} >
                    <NavigationArrowBack />
                </MenuItem>
                <MenuItem onTouchTap={() => {this.handleSelect('/about')}}>About</MenuItem>
            </LeftNav>
        );
    }
}

LeftNavComponent.propTypes = {
    isOpen: React.PropTypes.bool.isRequired,
    close: React.PropTypes.func.isRequired
};

export default LeftNavComponent;