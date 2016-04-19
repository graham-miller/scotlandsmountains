'use strict';

import React from 'react';
import { Link } from 'react-router'
import { history } from './history'
import Drawer from 'material-ui/Drawer';
import MenuItem from 'material-ui/MenuItem';
import RaisedButton from 'material-ui/RaisedButton';
import NavigationClose from 'material-ui/svg-icons/navigation/close';

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
        
        let mapLink = null;
        
        if(!this.props.mapIsActive){
            mapLink = <MenuItem onTouchTap={() => {this.handleSelect('/')}}>Map</MenuItem>
        }
        
        return (
            <Drawer open={this.props.isOpen}>
                <MenuItem onTouchTap={() => {this.handleSelect()}} style={{ padding: '12px 0 4px 4px' }} >
                    <NavigationClose />
                </MenuItem>
                
                {mapLink}
                
                <MenuItem onTouchTap={() => {this.handleSelect('/about')}}>About</MenuItem>
            </Drawer>
        );
    }
}

LeftNavComponent.propTypes = {
    isOpen: React.PropTypes.bool.isRequired,
    close: React.PropTypes.func.isRequired
};

export default LeftNavComponent;