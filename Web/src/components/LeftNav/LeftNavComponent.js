'use strict';

import React from 'react';

import LeftNav from 'material-ui/lib/left-nav';
import MenuItem from 'material-ui/lib/menus/menu-item';
import RaisedButton from 'material-ui/lib/raised-button';

import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

class LeftNavComponent extends React.Component {

    render() {
        return (
            <LeftNav open={this.props.isOpen}>
                <MenuItem onTouchTap={this.props.close} style={{ padding: '12px 0 4px 6px' }} >
                    <NavigationClose />
                </MenuItem>
                <MenuItem>Menu Item 1</MenuItem>
                <MenuItem>Menu Item 2</MenuItem>
            </LeftNav>
        );
    }
}

LeftNavComponent.propTypes = {
    isOpen: React.PropTypes.bool.isRequired,
    close: React.PropTypes.func.isRequired
};

export default LeftNavComponent;