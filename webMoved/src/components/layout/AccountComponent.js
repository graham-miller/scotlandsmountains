'use strict';

import React from 'react';
import IconMenu from 'material-ui/IconMenu';
import IconButton from 'material-ui/IconButton';
import MenuItem from 'material-ui/MenuItem';
import {white} from 'material-ui/styles/colors';
import ActionAccountCircle from 'material-ui/svg-icons/action/account-circle';

class AccountComponent extends React.Component {
    
    render() {
        const style = {width: '36px', height: '36px', padding:'0px', margin:'6px 6px 0 0'};
        const iconStyle = {width: '36px', height: '36px'};
        
        return (
            <IconMenu
                iconButtonElement={
                    <IconButton
                        style={style}
                        iconStyle={iconStyle} >                        
                        <ActionAccountCircle color={white} />
                    </IconButton>
                }
                targetOrigin={{horizontal: 'right', vertical: 'top'}}
                anchorOrigin={{horizontal: 'right', vertical: 'top'}} >
                <MenuItem primaryText="My mountains" />
                <MenuItem primaryText="Account" />
                <MenuItem primaryText="Sign out" />
            </IconMenu>
        );
    }
}

export default AccountComponent;