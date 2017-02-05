import React, { Component } from "react";

class Loading extends Component {

    render() {

        return (
            <div style={this.props.wrapperStyle}>
                <div className="loader"/>
                    <span style={this.props.textStyle}>{this.props.text}</span>
            </div>
        );
    }
}

Loading.defaultProps = {
    wrapperStyle: {},
    textStyle: {},
    text: "Loading"
};

export default Loading;
