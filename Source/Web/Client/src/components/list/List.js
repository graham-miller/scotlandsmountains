import React, { Component } from "react";
import { connect } from "react-redux";

import { fetchLists } from "../../state/lists";
import { fetchList } from "./actions";

import MountainList from "../common/MountainList";

class ListComponent extends Component {

    componentDidMount() {
        this.props.dispatch(fetchLists());
        if (this.props.routeParams.id) {
            this.props.dispatch(fetchList(this.props.routeParams.id));
        }
    }

    componentDidUpdate(prevProps, prevState) {
        // fixes bug when navigating to home (which defaults to /mountains/munros) but we're already home
        let tableChanged = prevProps.routeParams.id !== this.props.routeParams.id;
        let loading = this.props.status != null && this.props.status.loading;
        let noList = !this.props.list;

        if (!tableChanged && !loading && noList) {
            if (this.props.routeParams.id) {
                this.props.dispatch(fetchList(this.props.routeParams.id));
            }
        }
    }

    

    render() {

        let list = this.props.list;

        if (!list) { return null; }

        return (
            <MountainList
                mountains={list}
                showRowNumbers={true} />
        );
    }
}

const mapStateToProps = (state) => {

    return {
        list: state.list.value
    };
};

const List = connect(mapStateToProps)(ListComponent);

export default List;
