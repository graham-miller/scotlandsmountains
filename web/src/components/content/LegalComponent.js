'use strict';

import React from 'react';
import ReactDOM from 'react-dom';
import {Tabs, Tab} from 'material-ui/Tabs';
import $ from 'jquery';

class LegalComponent extends React.Component {

    constructor(props) {
        super(props);
        
        this.state = {
            docs: [
                {key: 'privacypolicy', display: 'Privacy policy'},
                {key: 'termsandconditions', display: 'Terms & conditions'},
                {key: 'disclaimer', display: 'Disclaimer'},
                {key: 'copyright', display: 'Copyright'},
            ]
        }
    }

    componentDidMount() {
        this.state.docs.map((doc) => {
            $.get(`/static/legal/${doc.key}.html`, (html) => {
                ReactDOM.findDOMNode(this.refs[doc.key]).innerHTML = html;
            })
            
        });
    }

    render() {
        return (
            <div>
                <Tabs>
                {this.state.docs.map((doc) => {
                    return (
                        <Tab label={doc.display}>
                            <div ref={doc.key}></div>
                        </Tab>
                    );
                })}
                </Tabs>
            </div>
        );
    }
}

export default LegalComponent;