import React, { Component } from 'react';

//import { fetchTable } from '../../actions/mountains';

//import Loading from '../common/Loading';

class Mountain extends Component {

    render() {
        return (<div>Show mountain details {this.props.params.id}</div>);
    }
}

export default Mountain;
