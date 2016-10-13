import React, { Component } from 'react';

import MdAddCircleOutline from 'react-icons/md/add-circle-outline';
import MdRemoveCircleOutline from 'react-icons/md/remove-circle-outline';
import MdRefresh from 'react-icons/md/refresh';
//import MdLayers from 'react-icons/lib/md/layers';
import MdMap from 'react-icons/lib/md/map';
import MdSatellite from 'react-icons/lib/md/satellite';

class Toolbar extends Component {

    render() {

        const style = { position: 'absolute', left: '15px', top: '15px', zIndex:10000 };

        return (
            <div className="btn-group" role="group" aria-label="Button group with nested dropdown" style={style}>
                
                <button type="button" className="btn btn-secondary"><MdAddCircleOutline /></button>
                <button type="button" className="btn btn-secondary"><MdRemoveCircleOutline /></button>
                <button type="button" className="btn btn-secondary"><MdRefresh /></button>
                <button type="button" className="btn btn-secondary"><MdMap /></button>
                <button type="button" className="btn btn-secondary"><MdSatellite /></button>
                
            </div>
        );
    }
}

export default Toolbar;
