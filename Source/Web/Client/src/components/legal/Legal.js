import React, { Component } from "react";
import $ from "jquery";

import GettyImage from "../common/GettyImage";

class Legal extends Component {

    constructor(props) {
        super(props);
        this.state = { html: "" };
        this.getContent();
    }

    componentWillUpdate(nextProps, nextState) {
        this.getContent();
    }

    getContent() {
        $.get("/legal/" + this.props.params.type + ".html", (html) => {
            if (this.refs.legal) {
                this.setState({ html: html });
            }
        });
    }

    componentWillUnmount() {
        this.setState({ html: "" });
    }

    render() {
        return (
            <div>
                <div ref="legal" dangerouslySetInnerHTML={{ __html: this.state.html }} />
                <GettyImage />
            </div>
        );
    }
}

export default Legal;
