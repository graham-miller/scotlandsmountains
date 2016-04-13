'use strict';

import React from 'react';
import { Link } from 'react-router'
import { history } from '../scripts/history'

import LeftNav from 'material-ui/lib/left-nav';
import MenuItem from 'material-ui/lib/menus/menu-item';
import RaisedButton from 'material-ui/lib/raised-button';

import NavigationClose from 'material-ui/lib/svg-icons/navigation/close';

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
            <LeftNav open={this.props.isOpen}>
                <MenuItem onTouchTap={() => {this.handleSelect()}} style={{ padding: '20px 0 20px 4px' }} >
                    <NavigationClose />
                </MenuItem>
                
                {mapLink}
                
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