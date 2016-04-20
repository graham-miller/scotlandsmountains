'use strict';

import React from 'react';
import ReactDOM from 'react-dom';
import {Tabs, Tab} from 'material-ui/Tabs';
import $ from 'jquery';

class LegalComponent extends React.Component {

    constructor(props) {
        super(props);

        console.log(this.props.params.activeDoc);
        
        this.state = {
            value: this.props.params.activeDoc,
            docs: [
                { value: 'terms', label: 'Terms' },
                { value: 'privacy', label: 'Privacy' },
                { value: 'disclaimer', label: 'Disclaimer' },
                { value: 'copyright', label: 'Copyright' },
            ]
        };
        
        this.handleChange = this.handleChange.bind(this); 
    }

    componentWillMount () {
        this.state.docs.map((doc) => {
            $.get(`/static/legal/${doc.value}.html`, (html) => {
                doc.html = html;
                this.setState(this.state)
            })

        });
    }

    componentWillReceiveProps (nextProps) {
        this.setState({value: nextProps.params.activeDoc});
    }

    handleChange (value) {
        this.setState({value: value});
    }
    
    render() {
        return (
            <div>
                <Tabs value={this.state.value} onChange={this.handleChange}>
                    {this.state.docs.map((doc) => {
                        return (
                            <Tab key={doc.page} value={doc.value} label={doc.label}>
                                <div
                                    className="padded"
                                    dangerouslySetInnerHTML={{ __html: doc.html }} />
                            </Tab>
                        );
                    }) }
                </Tabs>
            </div>
        );
    }
}

export default LegalComponent;