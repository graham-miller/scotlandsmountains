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

        this.state = {
            modalId: "LegalModal",
            modalTitle: "",
            modalBody: ""
        };

        this.displayLegal = this.displayLegal.bind(this);
    }

    displayLegal(event, index) {

        console.log(this.links[index]);
        
        $.get(event.target.href, (data) => {
            this.setState({
                modalTitle: this.links[index].title,
                modalBody: data
            });
        });

        event.preventDefault();
    }

    render() {
        return (
            <div>
                <Modal />
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
