import React, { Component } from "react";
import Formsy from "formsy-react";

import $ from "jquery";

import RaisedButton from "material-ui/RaisedButton";

import { FormsyText } from "formsy-material-ui/lib";

class ContactUs extends Component {

    constructor(props) {
        super(props);

        this.state = {
            canSubmit: false,
            sent: false,
            error: false
        };

        this.enableButton = this.enableButton.bind(this);
        this.disableButton = this.disableButton.bind(this);
        this.submitForm = this.submitForm.bind(this);
        this.resetForm = this.resetForm.bind(this);
    }

    enableButton() {
        this.setState({ canSubmit: true });
    }

    disableButton() {
        this.setState({ canSubmit: false });
    }

    submitForm(data) {
        this.setState({ canSubmit: false });
        $.ajax("/api/contactus/send", {
            method: "POST",
            crossDomain: true,
            contentType: "application/json",
            data: JSON.stringify(data)
        }).done(() => {
            this.setState({sent: true});
        }).fail(() => {
            this.setState({error: true});
        });
    }

    resetForm() {
        if (this.refs.form) {
            this.refs.form.reset();
        }
        this.setState({
            canSubmit: false,
            sent: false,
            error: false
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
                    <div>
                        <RaisedButton onClick={this.resetForm} label="Try again" primary={true} />
                    </div>
                </div>
            );
        }

        return (
            <div>
                <h2>Contact us</h2>

                <Formsy.Form
                    ref="form"
                    onValid={this.enableButton}
                    onInvalid={this.disableButton}
                    onValidSubmit={this.submitForm}
                    onInvalidSubmit={this.notifyFormError} >

                    <div>
                        <FormsyText
                            name="sender"
                            type="email"
                            validations="isEmail"
                            validationError="Invalid"
                            required
                            floatingLabelText="Your email address" />
                    </div>

                    <div>
                        <FormsyText
                            name="subject"
                            validations="isWords"
                            validationError="Invalid"
                            required
                            floatingLabelText="Subject" />
                    </div>

                    <div>
                        <FormsyText
                            name="message"
                            multiLine={true} rows={5}
                            validations="isWords"
                            validationError="Invalid"
                            required
                            floatingLabelText="Message" />
                    </div>

                    <div>
                        <RaisedButton
                            disabled={!this.state.canSubmit}
                            type="submit" label="Send" primary={true} />
                    </div>

                </Formsy.Form>

            </div>
        );
    }
}

export default ContactUs;
