import React, { Component } from "react";

class Title extends Component {

    render() {
        return (
            <h2 style={{textTransform: "capitalize"}}>{this.props.routeParams.table}</h2>
        );
    }
}

export default Title;
