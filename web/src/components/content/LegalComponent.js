'use strict';

import React from 'react';
import ReactDOM from 'react-dom';
import {Tabs, Tab} from 'material-ui/Tabs';
import $ from 'jquery';

class LegalComponent extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            value: this.props.params.activeDoc,
            docs: [
                { page: 'termsandconditions', display: 'Terms & conditions' },
                { page: 'privacypolicy', display: 'Privacy policy' },
                { page: 'disclaimer', display: 'Disclaimer' },
                { page: 'copyright', display: 'Copyright' },
            ]
        };
        
        this.handleChange = this.handleChange.bind(this); 
    }

    componentWillMount() {
        this.state.docs.map((doc) => {
            $.get(`/static/legal/${doc.page}.html`, (html) => {
                doc.html = html;
                this.setState(this.state)
            })

        });
    }

    handleChange (value) {
        this.setState({value: value});
    }
    
    render() {
        return (
            <div>
                <h2>The small print...</h2>
                <Tabs value={this.state.value} onChange={this.handleChange}>
                    {this.state.docs.map((doc) => {
                        return (
                            <Tab key={doc.page} value={doc.page} label={doc.display}>
                                <div dangerouslySetInnerHTML={{ __html: doc.html }}></div>
                            </Tab>
                        );
                    }) }
                </Tabs>
            </div>
        );
    }
}

export default LegalComponent;