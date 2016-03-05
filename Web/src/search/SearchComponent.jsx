import React from 'react';
import SearchActions from './SearchActions';
import SearchStore from './SearchStore';

import IconMenu from 'material-ui/lib/menus/icon-menu';
import IconButton from 'material-ui/lib/icon-button';
import MenuItem from 'material-ui/lib/menus/menu-item';
import Colors from 'material-ui/lib/styles/colors';

import ActionSearchCircle from 'material-ui/lib/svg-icons/action/Search-circle';

class SearchComponent extends React.Component {
    
    render() {

        const style = {width: '36px', height: '36px', padding:'0', margin:'6px 6px 0 0'};
        const iconStyle = {width: '36px', height: '36px'};
        
        const signedIn = true;

        let component = null;
        
        if (signedIn)  {
            component = (
                <IconMenu
                    iconButtonElement={
                        <IconButton
                            tooltip="Search"
                            style={style}
                            iconStyle={iconStyle} >                        
                            <ActionSearchCircle color={Colors.white} />
                        </IconButton>
                    }
                    targetOrigin={{horizontal: 'right', vertical: 'top'}}
                    anchorOrigin={{horizontal: 'right', vertical: 'top'}} >
                    <MenuItem primaryText="My mountains" />
                    <MenuItem primaryText="Search" />
                    <MenuItem primaryText="Sign out" />
                </IconMenu>
            );
        } else {
            component = (
                <IconButton
                    tooltip="Sign in"
                    style={style}
                    iconStyle={iconStyle} >                        
                    <ActionSearchCircle color={Colors.white} />
                </IconButton>
            );
        }

        return (component);
    }
}

export default SearchComponent;