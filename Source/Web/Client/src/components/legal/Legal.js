import React, { Component } from "react";
import $ from "jquery";

class Legal extends Component {

    constructor (props) {
        super(props);
        this.state = {html: ""};
        this.getContent();
    }

    componentWillUpdate(nextProps, nextState) {
        this.getContent();
    }

    getContent() {
        $.get("/legal/" + this.props.params.type + ".html", (html) => {
            if (this.refs.legal) {
                this.setState({html: html});
            }
        });
    }

    componentWillUnmount() {
        this.setState({html: ""});
    }

    render() {
        return <div ref="legal" dangerouslySetInnerHTML={{__html: this.state.html}} />;
    }
}

export default Legal;
