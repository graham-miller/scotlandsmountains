import React, { Component } from "react";
import {HOC} from "formsy-react";

class Recaptcha extends Component {

    constructor(props) {
        super(props);
        this.state = { widgetId: null };
    }

    componentDidMount() {
        if(!window.onLoadRecaptchaCallback) {

            window.onRecaptchaLoaded = () => {
                const widgetId = window.grecaptcha.render(this.recaptchaElement, {
                    "sitekey": "6Lf4Ah0TAAAAAIsZzbo-JwGcYtJGPwCJdhVIErYz",
                    "callback": "onRecaptchaChanged",
                    "expired-callback": "onRecaptchaExpired"
                });
                this.setState({widgetId: widgetId});
            };

            window.onRecaptchaChanged = (value) => {
                this.props.setValue(value);
            };

            window.onRecaptchaExpired = () => {
                this.props.setValue(null);
            };

            var element = document.createElement("script");
            element.setAttribute("src","https://www.google.com/recaptcha/api.js?onload=onRecaptchaLoaded&render=explicit");
            document.head.appendChild(element);

        } else {
            this.renderWidget();
        }
    }

    render() {
        return (
            <div style={{margin:"14px 0 14px 0"}}>
                <input type="hidden" value={this.props.getValue()} />
                <div ref={(input) => this.recaptchaElement = input} />
            </div>
        );
    }
}

export default HOC(Recaptcha);
