'use strict';

import React from 'react';

import $ from 'jquery';

import config from '../../config';
import {ToolbarGroup, Toolbar} from 'material-ui/Toolbar';
import IconButton from 'material-ui/IconButton';
import IconMenu from 'material-ui/IconMenu';
import MenuItem from 'material-ui/MenuItem';

class SearchBarComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            timer: null,
            term: '',
            results: []
        };
        this.handleChanged = this.handleChanged.bind(this);
    }

    handleChanged(event) {
        const term = event.target.value;
        this.setState({ term: term });

        if (term.length > 2) {
            clearTimeout(this.state.timer);
            this.setState({
                timer: setTimeout(() => {
                    $.get(config.apiBaseUrl + '/api/search/' + encodeURIComponent(term), (data) => {
                        this.setState({results: data});
                    });
                }, 250)    
            });

        } else {
            this.setState({ results: [] });
        }
    }

    render() {

        return (
            <div>
                <Toolbar style={{ paddingTop: '6px', height: '46px' }}>
                    <ToolbarGroup firstChild={true}>
                        <input
                            type="search" ref="search"
                            autoFocus placeholder="Search"
                            style={{ marginLeft: '12px', width: '264px' }}
                            onChange={this.handleChanged} />
                    </ToolbarGroup>
                </Toolbar>
                {
                    this.state.results.length > 0 ? (
                        <div className="search-results">
                            <div className="scrollable">
                                <ul>
                                    {this.state.results.map(function(result) {
                                        return <li>{result.name}</li>;
                                    }) }
                                </ul>
                            </div>
                        </div>
                    ) : null
                }
            </div>
        );
    }
}

export default SearchBarComponent;