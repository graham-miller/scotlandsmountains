import React from 'react';
import AccountActions from './AccountActions';
import AccountStore from './AccountStore';

import IconMenu from 'material-ui/lib/menus/icon-menu';
import IconButton from 'material-ui/lib/icon-button';
import MenuItem from 'material-ui/lib/menus/menu-item';
import Colors from 'material-ui/lib/styles/colors';

import ActionAccountCircle from 'material-ui/lib/svg-icons/action/account-circle';

class AccountComponent extends React.Component {

    render() {
        return (
            <IconMenu
                iconButtonElement={
                    <IconButton
                        tooltip="Sign in"
                        color={Colors.white}
                        style={{width: '36px', height: '36px', padding:'0', margin:'6px 6px 0 0'}}
                        iconStyle={{width: '36px', height: '36px'}} >                        
                        <ActionAccountCircle color={Colors.white} />
                    </IconButton>
                }
                targetOrigin={{horizontal: 'right', vertical: 'top'}}
                anchorOrigin={{horizontal: 'right', vertical: 'top'}} >
                <MenuItem primaryText="Sign in" />
            </IconMenu>
        );
    }
}

export default AccountComponent;