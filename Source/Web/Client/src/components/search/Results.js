import React, { Component } from "react";
import { connect } from "react-redux";

import Loading from "../common/Loading";
import NetworkError from "../common/NetworkError";
import MountainList from "../common/MountainList";

class ResultsComponent extends Component {

    render() {

        if (this.props.status.error) { return (<div><NetworkError /></div>); }

        if (this.props.status.loading) { return (<div><Loading /></div>); }

        if (this.props.search == null || this.props.search.results.length === 0) { return null; }

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
