'use strict';

import React from 'react';

import LeftNav from 'material-ui/lib/left-nav';
import MenuItem from 'material-ui/lib/menus/menu-item';
import RaisedButton from 'material-ui/lib/raised-button';

import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

class LeftNavComponent extends React.Component {

    render() {
        return (
            <div>
                <LeftNav open={this.props.open}>
                    <MenuItem onTouchTap={this.props.onClose} style={{ padding: '12px 0 4px 6px' }} >
                        <NavigationClose />
                    </MenuItem>
                    <MenuItem>Menu Item 1</MenuItem>
                    <MenuItem>Menu Item 2</MenuItem>
                </LeftNav>
            </div>
        );
    }
}

LeftNavComponent.propTypes = {
    open: React.PropTypes.bool.isRequired,
    onClose: React.PropTypes.func.isRequired
};

export default LeftNavComponent;