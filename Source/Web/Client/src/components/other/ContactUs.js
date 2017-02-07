import React, { Component } from "react";
import Formsy from "formsy-react";
import $ from "jquery";
import { post } from "../../api";
import RaisedButton from "material-ui/RaisedButton";
import { FormsyText } from "formsy-material-ui/lib";

import GettyImage from "./GettyImage";

class ContactUs extends Component {

    constructor(props) {
        super(props);

        this.state = {
            canSubmit: false,
            sent: false,
            error: false
        };
    }

    enableButton = () => this.setState({ canSubmit: true });

    disableButton = () => this.setState({ canSubmit: false });

    submitForm = (data) => {
        this.setState({ canSubmit: false });
        post("contactus/send", JSON.stringify(data),
            () => this.setState({sent: true}),
            () => this.setState({error: true}));
    }

    resetForm = () => {
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
                    <GettyImage />
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
                    <GettyImage />
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
                            fullWidth={true}
                            validations="isEmail"
                            validationError="Invalid"
                            required
                            floatingLabelText="Your email address" />
                    </div>

                    <div>
                        <FormsyText
                            name="subject"
                            fullWidth={true}
                            required
                            floatingLabelText="Subject" />
                    </div>

                    <div>
                        <FormsyText
                            name="message"
                            fullWidth={true}
                            multiLine={true} rows={5}
                            required
                            floatingLabelText="Message" />
                    </div>

                    <div>
                        <RaisedButton
                            disabled={!this.state.canSubmit}
                            type="submit" label="Send" primary={true} />
                    </div>

                </Formsy.Form>

                <GettyImage />
            </div>
        );
    }
}

export default ContactUs;
