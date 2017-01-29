import React, { Component } from "react";
import { connect } from "react-redux";

import MountainList from "../common/MountainList";

class ListComponent extends Component {

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
        lists: state.lists,
        list: state.list.value
    };
};

const List = connect(mapStateToProps)(ListComponent);

export default List;
