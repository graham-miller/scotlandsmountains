import React, { Component } from "react";

class Recaptcha extends Component {

    render() {
        return (
            <div
                style={{margin:"14px 0 14px 0"}}
                className="g-recaptcha"
                data-sitekey="6Lf4Ah0TAAAAAIsZzbo-JwGcYtJGPwCJdhVIErYz" />
        );
    }
}

export default Recaptcha;
