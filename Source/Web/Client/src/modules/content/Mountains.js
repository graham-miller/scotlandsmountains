import React, { Component } from 'react';

import { fetchTable } from '../../actions/mountains';

import Loading from './Loading';

class Mountains extends Component {

    componentDidMount() {
        this.props.dispatch(fetchTable('munro'));
    }

    render() {

        return (
            <div>
                <Loading />
                <ul>
                {
                    this.props.mountains.map(mountain =>
                        <li key={mountain.id}>
                            {mountain.name}
                        </li>)
                }                
                </ul>
            </div>
        );
    }
}

export default Mountains;
