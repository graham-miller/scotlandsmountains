import React, { Component } from 'react';
import { connect } from 'react-redux'

import { create, destroy } from '../../actions/map';
import Toolbar from './Toolbar';
import FullHeightContainer from '../common/FullHeightContainer'

import './Map.scss';

class MapComponent extends Component {

    componentDidMount() {
        this.props.dispatch(create('map'));
    }

    componentWillUpdate(nextProps, nextState) {
        if (nextProps.lastUpdated !== this.props.lastUpdated) {
            this.props.map.displayMountains(nextProps.mountains);
        }
    }

    componentWillUnmount() {    
        this.props.dispatch(destroy());
    }
    
    render() {

        return (
            <div style={{position:'relative'}}>
                <FullHeightContainer allowance='85' handleResize={this.resizeMap}>
                    <div id='map' style={{height: '100%'}} />
                </FullHeightContainer>
                <Toolbar/>
            </div>
        );
    }
}

const mapStateToProps = (state) => {

    return {
        map : state.map.object,
        mountains: state.mountains.items,
        status: state.mountains.status,
        lastUpdated: state.mountains.lastUpdated
    };
}

const Map = connect(mapStateToProps)(MapComponent)

export default Map;
