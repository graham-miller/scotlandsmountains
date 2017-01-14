import React, { Component } from "react";
import { connect } from "react-redux";

import { fetchList } from "./actions";

import MountainList from "../common/MountainList";
import Loading from "../common/Loading";
import NetworkError from "../common/NetworkError";

class ListComponent extends Component {

    componentDidMount() {
        this.props.dispatch(fetchList(this.props.routeParams.table));
    }

    componentDidUpdate(prevProps, prevState) {
        // fixes bug when navigating to home (which defaults to /mountains/munros) but we're already home
        let tableChanged = prevProps.routeParams.table !== this.props.routeParams.table;
        let loading = this.props.status != null && this.props.status.loading;
        let noList = !this.props.list;

        if (!tableChanged && !loading && noList) {
            debugger;
            this.props.dispatch(fetchList(this.props.routeParams.table));
        }
    }

    render() {

        if (this.props.status == null) { return null; }

        if (this.props.status.error) { return (<NetworkError />); }

        if (this.props.status.loading) { return (<Loading />); }

        if (!this.props.list) { return (<Loading />); }

        return (
            <MountainList
                mountains={this.props.list}
                showRowNumbers={true} />
        );
    }
}

const mapStateToProps = (state) => {

    return {
        list: state.list.value,
        status: state.list.status,
    };
};

const List = connect(mapStateToProps)(ListComponent);

export default List;
