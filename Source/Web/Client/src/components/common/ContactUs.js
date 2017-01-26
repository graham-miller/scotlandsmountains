import React, { Component } from "react";

import $ from "jquery";

import TextField from "material-ui/TextField";
import RaisedButton from "material-ui/RaisedButton";

class ContactUs extends Component {

    constructor(props) {
        super(props);

        this.state = {
            sent: false,
            error: false,
            sender: "",
            subject: "",
            message: "",
            senderErrorText: "",
            subjectErrorText: "",
            messageErrorText: ""
        };

        this.submitForm = this.submitForm.bind(this);
    }

    submitForm() {
        $.ajax("/api/contactus/send", {
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(this.state)
        }).done((data) => {
            this.setState(data);
        }).fail((jqXHR) => {
            this.setState(jqXHR.responseJSON);
        });
    }

    render() {

        if (this.state.sent) {
            return (
                <div>
                    <h2>Contact us</h2>
                    <p>Your message has been sent.</p>
                    <p>Thanks for getting in touch!</p>
                </div>
            );
        }

        if (this.state.error) {
            return (
                <div>
                    <h2>Contact us</h2>
                    <p>Oops! something went wrong trying to send your message.</p>
                    <p><a href="/contactus" onClick={() => this.setState({error: false})}>Try again</a>.</p>
                </div>
            );
        }

        return (
            <div>
                <h2>Contact us</h2>
                <form action="" method="post">
                    <fieldset>
                        
                        <div>
                            <TextField
                                type="email" name="sender"
                                floatingLabelText="Your email address"
                                errorText={this.state.senderErrorText}
                                onChange={(e) => this.setState({sender: e.target.value, senderErrorText: ""})}/>
                        </div>

                        <div>
                            <TextField
                                name="subject"
                                floatingLabelText="Subject"
                                errorText={this.state.subjectErrorText}
                                onChange={(e) => this.setState({subject: e.target.value, subjectErrorText: ""})}/>
                        </div>

                        <div>
                            <TextField
                                name="message" multiLine={true} rows={5}
                                floatingLabelText="Message"
                                errorText={this.state.messageErrorText}
                                onChange={(e) => this.setState({message: e.target.value, messageErrorText: ""})}/>
                        </div>

                        <div>
                            <RaisedButton onClick={() => this.submitForm()} label="Send" primary={true} />
                        </div>

                    </fieldset>
                </form>
            </div>
        );
    }
}

export default ContactUs;
