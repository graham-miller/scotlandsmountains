import React, { Component } from "react";
import { connect } from "react-redux";

import { fetchClassification } from "../../actions/mountains";

import MountainList from "../common/MountainList";
import Loading from "../common/Loading";
import NetworkError from "../common/NetworkError";

class TableComponent extends Component {

    componentDidMount() {
        this.props.dispatch(fetchClassification(this.props.routeParams.table));
    }

    render() {

        if (this.props.status.error) { return (<NetworkError />); }

        if (this.props.status.loading) { return (<Loading />); }

        if (!this.props.mountains) { return (<Loading />); }

        return (
            <MountainList
                mountains={this.props.mountains}
                showRowNumbers={true} />
        );
    }
}

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains.items,
        status: state.mountains.status
    };
};

const Table = connect(mapStateToProps)(TableComponent);

export default Table;
