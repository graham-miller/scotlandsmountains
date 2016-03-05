import React from 'react';
import LeftNav from 'material-ui/lib/left-nav';
import MenuItem from 'material-ui/lib/menus/menu-item';

class LeftNavComponent extends React.Component {
     
    render() {
        return (
            <div>
                <LeftNav
                    open={this.props.open}
                    style={{paddingTop:'110px'}}>
                    <MenuItem>Menu Item 1</MenuItem>
                    <MenuItem>Menu Item 2</MenuItem>
                </LeftNav>
            </div>
            );
    }
}

export default LeftNavComponent;