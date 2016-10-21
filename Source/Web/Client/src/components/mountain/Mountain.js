import React, { Component } from 'react';

import { fetchMountain } from '../../actions/mountains';

import Loading from '../common/Loading';

class Mountain extends Component {

    componentWillMount() {
        this.props.dispatch(fetchMountain(this.props.params.id));
    }

    render() {

        if (this.props.mountains.status.error) {
            return (<div>Network error</div>);
        }

        if (this.props.mountains.status.loading) {
            return (<Loading />);
        }

        var mountain = this.props.mountains.list[0];

        if (mountain) {
            return (
                <div>
                    { mountain.name }
                </div>);
        }

        return (<div>Not found</div>);
    }
}

export default Mountain;
