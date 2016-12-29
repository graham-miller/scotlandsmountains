import React, { Component } from "react";
import { connect } from "react-redux";

import { fetchList } from "../../actions/mountains";

import MountainList from "../common/MountainList";
import Loading from "../common/Loading";
import NetworkError from "../common/NetworkError";

class ListComponent extends Component {

    componentDidMount() {
        this.props.dispatch(fetchList(this.props.routeParams.table));
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

const List = connect(mapStateToProps)(ListComponent);

export default List;
