import React, { Component } from 'react';

import { fetchTable } from '../../actions/mountains';

class Mountains extends Component {

    componentDidMount() {
        this.props.dispatch(fetchTable('munro'));
    }

    render() {

        return (
            <ul>
            {
                this.props.mountains.map(mountain =>
                    <li key={mountain.id}>
                        {mountain.name}
                    </li>)
            }                
            </ul>
        );
    }
}

export default Mountains;
