import React, { Component } from "react";
import { connect } from "react-redux";

import MountainList from "../common/MountainList";

class ResultsComponent extends Component {

    render() {

        let search = this.props.search;

        if (!search) { return null; }

        return (
            <MountainList
                mountains={this.props.search.results}
                showRowNumbers={false} />
        );
    }
}

const mapStateToProps = (state) => {
    return {
        search: state.search.value,
        status: state.search.status
    };
};

const Results = connect(mapStateToProps)(ResultsComponent);

export default Results;
