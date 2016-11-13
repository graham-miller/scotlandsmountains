import React, { Component } from "react";
import $ from "jquery";

import Modal from "../common/Modal";

class Legal extends Component {

    constructor(props) {
        super(props);

        this.links = [
            {
                title: "Terms and conditions",
                name: "terms"
            },
            {
                title: "Privacy policy",
                name: "privacy"
            },
            {
                title: "Disclaimer",
                name: "disclaimer"
            },
            {
                title: "Copyright",
                name: "copyright"
            },
        ];

        this.modalId = "LegalModal";

        this.state = {
            modalTitle: "",
            modalBody: ""
        };

        this.displayLegal = this.displayLegal.bind(this);
    }

    displayLegal(event, index) {

        this.setState({
            modalTitle: this.links[index].title
        });

        $.get(event.target.href, (data) => {
            this.setState({
                modalTitle: this.links[index].title,
                modalBody: data
            });
        });

        event.preventDefault();
    }

    componentDidMount() {
        if (this.state.modalTitle !== "") {
            $("#" + this.modalId).modal("show");
        }
    }

    render() {
        return (
            <div>
                <Modal
                    id={this.modalId}
                    title={this.state.modalTitle}
                    body={this.state.modalBody}/>
                    <p>
                        The small print:
                    </p>
                <ul>
                {
                    this.links.map((link, index) => {
                        return (
                            <li key={index}>
                                <a onClick={(e) => this.displayLegal(e, index)} href={process.env.PUBLIC_URL + "/legal/" + link.name}>
                                    {link.title}
                                </a>
                            </li>
                        );
                    })
                }
                </ul>
            </div>
        );
    }
}

export default Legal;
