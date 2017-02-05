import React, { Component } from "react";
import { connect } from "react-redux";
import MountainList from "../other/MountainList";

class ResultsComponent extends Component {

    render() {

        let search = this.props.search;

        if (!search) { return null; }

        let summary = null;

        if (this.props.search.count === 0) {
            summary = (
                <p>
                    No matches found.
                </p>
            );
        } else {
            summary = (
                <p>
                    Showing {this.props.search.results.length} of {this.props.search.count} result{this.props.search.count === 1 ? "" : "s"}.
                </p>
            );
        }

        return (
            <div>
                {summary}
                <MountainList
                    mountains={this.props.search.results}
                    showRowNumbers={false} />
            </div>
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
