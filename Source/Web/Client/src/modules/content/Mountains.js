import React, { Component } from 'react';

import { fetchTable } from '../../actions/mountains';

import Loading from './Loading';

class Mountains extends Component {

    componentDidMount() {
        this.props.dispatch(fetchTable('munro'));
    }

    render() {

        if (this.props.error) {
            return (<div>Network error</div>);
        }

        if (this.props.loading) {
            return (<Loading />);
        }

        return (
            <div>
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
