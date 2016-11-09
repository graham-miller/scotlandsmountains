import React, { Component } from "react";

import LoadingGif from "./loading.gif";

class Loading extends Component {

    render() {

        return (
            <div>
                Loading
                <img src={LoadingGif} role="presentation" style={{margin: "0 0 0 10px"}} />
            </div>
        );
    }
}

export default Loading;
