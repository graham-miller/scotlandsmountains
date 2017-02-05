import React, { Component } from "react";
import { Link } from "react-router";
import Logo from "../other/Logo";

class Footer extends Component {

    render() {
        return (
            <div id="footer">
                <div className="footer-section legal">
                    <Link to="/legal/terms">Terms and conditions</Link>&emsp;&middot;&emsp;
                    <Link to="/legal/privacy">Privacy policy</Link>&emsp;&middot;&emsp;
                    <Link to="/legal/disclaimer">Disclaimer</Link>&emsp;&middot;&emsp;
                    <Link to="/legal/copyright">Copyright</Link>&emsp;&middot;&emsp;
                    <Link to="/contactus">Contact us</Link>
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
            </div>
        );
    }
}

export default Footer;
