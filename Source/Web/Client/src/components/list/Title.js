import React, { Component } from "react";
import { connect } from "react-redux";

import Loading from "../common/Loading";

class TitleComponent extends Component {

    render() {
        if (this.props.status.loading) {
            return (<Loading />);
        }
        return (
            <h2 style={{textTransform: "capitalize"}}>{this.props.routeParams.table}</h2>
        );
    }
}

const mapStateToProps = (state) => {

    return {
        status: state.list.status
    };

};

const Title = connect(mapStateToProps)(TitleComponent);

export default Title;
