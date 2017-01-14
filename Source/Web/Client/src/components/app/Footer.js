import React, { Component } from "react";

import Logo from "../common/Logo";

import "./Footer.scss";

class Footer extends Component {

    render() {
        return (
            <footer>
                <div className="footer-section legal">
                    <a href="#">Terms and conditions</a>&nbsp;&middot;&nbsp;
                    <a href="#">Privacy policy</a>&nbsp;&middot;&nbsp;
                    <a href="#">Disclaimer</a>&nbsp;&middot;&nbsp;
                    <a href="#">Copyright</a>            
                </div>
                <div className="footer-section">
                    <p>
                        Site design / logo &copy; {new Date().getFullYear()} Graham Miller.
                    </p>
                    <p>
                        Site developed and operated by Graham Miller.
                    </p>
                    <p>
                        Mountain data &copy;
                        &nbsp;<a href='http://www.hills-database.co.uk/' target='_blank'>The Database of British and Irish Hills</a>&nbsp;
                        licensed under a
                        &nbsp;<a href='http://creativecommons.org/licenses/by/3.0/deed.en_GB' target='_blank'>Creative Commons Attribution 3.0 Unported License</a>.
                    </p>
                </div>
                <div className="footer-section" style={{textAlign: "center"}}>
                    <p>
                        <Logo size="50px" color="#909690" />
                    </p>
                </div>
            </footer>
        );
    }
}

export default Footer;
