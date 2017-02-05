import React, { Component } from "react";

class Logo extends Component {

    render() {
        return (
            <svg
                width={this.props.size} height={this.props.size} viewBox="0 0 260 260">
                <path
                    style={{
                        fill: "none",
                        stroke: this.props.color,
                        strokeWidth: 30,
                        strokeLinecap: "round",
                        strokeLinejoin: "round",
                        strokeOpacity: 1
                    }}
                    d="M  15,245 75,85 125,165 175,15 245,245"/>
            </svg>
        );
    }
}

export default Logo;