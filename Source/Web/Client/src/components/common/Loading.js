import React, { Component } from "react";

class Loading extends Component {

    render() {

        return (
            <div style={this.props.wrapperStyle}>
                <div className="loader" />
                {this.props.text}
            </div>
        );
    }
}

Loading.defaultProps = {
    wrapperStyle: {},
    text: "Loading"
};

export default Loading;
