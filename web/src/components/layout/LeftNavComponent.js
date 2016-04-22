'use strict';

import React from 'react';
import { Link } from 'react-router'
import { history } from './history'
import Drawer from 'material-ui/Drawer';
import MenuItem from 'material-ui/MenuItem';
import {List, ListItem} from 'material-ui/List';
import RaisedButton from 'material-ui/RaisedButton';
import NavigationClose from 'material-ui/svg-icons/navigation/close';
import ArrowDropRight from 'material-ui/svg-icons/navigation-arrow-drop-right';

class LeftNavComponent extends React.Component {

    constructor(props) {
        super(props);
        
        this.state = {open: this.props.open};
        
        this.handleSelect = this.handleSelect.bind(this);
        this.handleToggle = this.handleToggle.bind(this);
        this.handleClose = this.handleClose.bind(this);
    }

    componentWillReceiveProps (nextProps) {
        this.setState({open: nextProps.open});
    }

    handleToggle () {
        this.setState({open: !this.state.open});
    }

    handleClose () {
        this.setState({open: false});
        this.props.close();
    }
      
    handleSelect(url) {
        this.handleClose();
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
            <Drawer
                docked={false}
                open={this.state.open}
                onRequestChange={(open) => this.setState({open})} >
                
                <MenuItem onTouchTap={() => {this.handleSelect()}} style={{ padding: '12px 0 4px 4px' }} >
                    <NavigationClose />
                </MenuItem>
                
                {mapLink}
                
                <MenuItem onTouchTap={() => {this.handleSelect('/about')}}>About</MenuItem>
                
                <MenuItem
                    primaryText="Legal notices"
                    rightIcon={<ArrowDropRight />}
                    menuItems={[
                        <MenuItem onTouchTap={() => {this.handleSelect('/legal/terms')}}>Terms and conditions</MenuItem>,
                        <MenuItem onTouchTap={() => {this.handleSelect('/legal/privacy')}}>Privacy policy</MenuItem>,
                        <MenuItem onTouchTap={() => {this.handleSelect('/legal/disclaimer')}}>Disclaimer</MenuItem>,
                        <MenuItem onTouchTap={() => {this.handleSelect('/legal/copyright')}}>Copyright</MenuItem>
                    ]} />
            </Drawer>
        );
    }
}

LeftNavComponent.propTypes = {
    open: React.PropTypes.bool.isRequired,
    close: React.PropTypes.func.isRequired
};

export default LeftNavComponent;