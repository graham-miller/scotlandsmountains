import React, { Component } from 'react';

import MountainStore from '../stores/MountainStore';
import MountainActions from '../actions/MountainActions';

class Home extends Component {

    constructor(props) {
        super(props);
        this.state = MountainStore.getState();
        this.onChange = this.onChange.bind(this);
    }

    componentDidMount() {
        MountainStore.listen(this.onChange);
        MountainActions.getTable('munro');
    }

    componentWillUnmount() {
        MountainStore.unlisten(this.onChange);
    }

    onChange(state) {
        this.setState(state);
    }

    render() {

        if (this.state.errorMessage) {
            return (
                <div>{this.state.errorMessage}</div>
            );
        }

        if (!this.state.mountains.length) {
            return (
                <div>Loading...</div>
            )
        }

        const style = {
            padding: '2px',
            height: '100%',
            overflow: 'scroll', overflowX: 'hidden',
            border: '1px solid #333'
        }

        return (
            <div className='full-height'>
                <div style={style}>
                    <ul style={{listStyleType: 'none', padding: 0}}>
                        {this.state.mountains.map(function(mountain) {
                            return (
                                <li key={mountain.id}>{mountain.name}</li>
                            );
                        })}
                    </ul>            
                </div>
            </div>
        );
    }
}

export default Home;
