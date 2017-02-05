import React, { Component } from "react";
import { connect } from "react-redux";
import Loading from "../other/Loading";

class TitleComponent extends Component {

    render() {

        if (this.props.status.loading) {
            return (<Loading />);
        }
        return (<h2>{this.props.name}</h2>);
    }
}

const mapStateToProps = (state) => {

    return {
        name: (((state.mountain) || {}).value || {}).name || "",
        status: state.mountain.status
    };

};

const Title = connect(mapStateToProps)(TitleComponent);

export default Title;
