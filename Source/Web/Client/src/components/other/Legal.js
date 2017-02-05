import React, { Component } from "react";
import GettyImage from "./GettyImage";

class Legal extends Component {

    componentDidMount() {
        this.getContent(this.props.params.type);
    }

    componentWillUpdate(nextProps, nextState) {
        if (this.props.params.type !== nextProps.params.type) {
            this.getContent(nextProps.params.type);
        }
    }

    getContent = (type) => {
        fetch("/legal/" + type + ".html")//, {redirect: "follow", mode: "cors"})
            .then(response => {
                if (!response.ok) {
                    throw new Error();
                }
                return response.text();
            })
            .then(html => {
                this.setState({ html: html });
            });
    }

    render() {
        var html = (this.state || {}).html || "";
        return (
            <div>
                <div ref="legal" dangerouslySetInnerHTML={{ __html: html }} />
                <GettyImage />
            </div>
        );
    }
}

export default Legal;
