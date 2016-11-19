import React, { Component } from "react";
import { connect } from "react-redux";

class TitleComponent extends Component {

    render() {

        return (<h2>{this.props.name}</h2>);
    }
}

const mapStateToProps = (state) => {

    return {
        name: state.mountains.items.length === 1 ? state.mountains.items[0].name : "",
    };
};

const Title = connect(mapStateToProps)(TitleComponent);

export default Title;
