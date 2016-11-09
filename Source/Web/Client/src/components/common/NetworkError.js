import React, { Component } from "react";

class NetworkError extends Component {

    render() {
        return (
            <div className="alert alert-danger" role="alert">
                <strong>Uh oh!</strong> Something went wrong fetching data from the server.
            </div>
        );
    }
}

export default NetworkError;
