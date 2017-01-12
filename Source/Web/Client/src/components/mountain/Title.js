import React, { Component } from "react";
import { connect } from "react-redux";

class TitleComponent extends Component {

    render() {

        return (<h2>{this.props.name}</h2>);
    }
}

const mapStateToProps = (state) => {
    if (state.mountain == null || state.mountain.value == null) {
        return { name: "" };
    } else {
        return { name: state.mountain.value.name || "" };
    }
};

const Title = connect(mapStateToProps)(TitleComponent);

export default Title;
