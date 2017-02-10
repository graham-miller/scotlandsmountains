import React, { Component } from "react";
import {HOC} from "formsy-react";

class Recaptcha extends Component {

    constructor(props) {
        super(props);
        this.state = {
            widgetId: null,
            value: ""
        };
    }

    componentDidMount() {
        if(!window.onLoadRecaptchaCallback) {

            window.onRecaptchaLoaded = () => {
                const widgetId = window.grecaptcha.render(this.recaptchaElement, {
                    "sitekey": this.props.siteKey,
                    "callback": "onRecaptchaChanged",
                    "expired-callback": "onRecaptchaExpired"
                });
                this.setState({widgetId: widgetId});
            };

            window.onRecaptchaChanged = (value) => {
                this.props.setValue(value);
                this.setState({value: value});
            };

            window.onRecaptchaExpired = () => {
                this.props.setValue("");
                this.setState({value: ""});
            };

            var element = document.createElement("script");
            element.setAttribute("src","https://www.google.com/recaptcha/api.js?onload=onRecaptchaLoaded&render=explicit");
            document.head.appendChild(element);

        } else {
            this.renderWidget();
        }
    }

    getValue() {
        return this.state.value;
    }

    render() {
        return (
            <div>
                <input type="hidden" value={this.state.value} />
                <div ref={(input) => this.recaptchaElement = input} />
            </div>
        );
    }
}

export default HOC(Recaptcha);
