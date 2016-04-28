'use strict';

import React from 'react';
import ReactDOM from 'react-dom';
import $ from 'jquery';

import config from '../../config.js';

class ClassificationComponent extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            classification: this.props.params.classification,
            mountains: []
        };
        
        this.loadMountains = this.loadMountains.bind(this);
    }
    
    componentWillMount () {
        this.loadMountains(this.state.classification);
    }

    componentWillReceiveProps (nextProps) {
        if (this.state.classification !== nextProps.params.classification) {
            this.setState({classification: nextProps.params.classification});
            this.loadMountains(nextProps.params.classification);
        }
    }
    
    loadMountains(classification) {
        $.get(`${config.apiBaseUrl}/api/classification/${classification}/mountains`, (data) => {
            this.setState({mountains: data})
        });
    }
    
    render() {
        
        return (
            <div className="padded">
                <h1>{this.state.classification.charAt(0).toUpperCase() + this.state.classification.slice(1) + 's'}</h1>
                <table>
                    <colgroup>
                        <col />
                        <col />
                        <col style={{width: '10em'}} />
                        <col />
                    </colgroup>
                    <thead>
                        <tr>
                            <th></th>
                            <th>Name</th>
                            <th>Height</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                    {
                        this.state.mountains.map(function(mountain, index) {
                            return (
                                <tr key={mountain.key}>
                                    <td>{index + 1}</td>
                                    <td>{mountain.name}</td>
                                    <td>{mountain.height}</td>
                                    <td></td>
                                </tr>
                            );
                        })
                    }
                    </tbody>
                </table>
            </div>
        );
    }
}
        // "key": "3mzAVRq1",
        // "name": "Ben Nevis",
        // "height": "1,344m (4,409ft)",
        // "classification": "Munro, Murdo",
        // "latLong": [
        //     56.796849,
        //     -5.003525

export default ClassificationComponent;