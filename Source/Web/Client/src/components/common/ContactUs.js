import React, { Component } from "react";
import TextField from "material-ui/TextField";
import RaisedButton from "material-ui/RaisedButton";

class ContactUs extends Component {

    constructor(props) {
        super(props);

        this.state = {
            sender: "",
            subject: "",
            message: ""
        };

        this.submitForm = this.submitForm.bind(this);
    }

    submitForm() {
        alert(this.state.sender + "\n" + this.state.subject + "\n" + this.state.message);
    }

    render() {

        return (
            <div>
                <h2>Contact us</h2>
                <form action="" method="post">
                    <fieldset>
                        
                        <div>
                            <TextField
                                type="email" name="sender" floatingLabelText="Your email address"
                                onChange={(e) => this.setState({sender: e.target.value})}/>
                        </div>

                        <div>
                            <TextField
                                name="subject" floatingLabelText="Subject"
                                onChange={(e) => this.setState({subject: e.target.value})}/>
                        </div>

                        <div>
                            <TextField
                                name="message" floatingLabelText="Message" multiLine={true} rows={5}
                                onChange={(e) => this.setState({message: e.target.value})}/>
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
