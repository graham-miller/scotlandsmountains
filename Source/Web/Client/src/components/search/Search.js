import React, { Component } from 'react';
import { connect } from 'react-redux';
import { browserHistory } from 'react-router';
import $ from 'jquery';

import { search } from '../../actions/mountains';
import { reset } from '../../actions/map';

import Loading from '../common/Loading';
import FullHeight from '../common/FullHeight'
import NetworkError from '../common/NetworkError';

import './Search.scss'

class SearchComponent extends Component {

    constructor(props){
        super(props);

        this.state = {
            term: '',
            timeoutId: null
        }

        this.search = this.search.bind(this);
        this.onMouseOver = this.onMouseOver.bind(this);
        this.onMouseOut = this.onMouseOut.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    componentWillMount() {
        this.props.dispatch(reset());
        if (this.state.term.length > 2) {
            this.props.dispatch(search(this.state.term));
        }
    }

    search(event) {
        
        this.setState({term: event.target.value});

        if (this.state.timeoutId) {
            clearTimeout(this.state.timeoutId);
        }

        const delay = 400;

        this.setState({
            timeoutId: setTimeout(() => {
                if (this.state.term.length > 2) {
                    this.props.dispatch(search(this.state.term));
                }
            }, delay)
        });
    }

    onMouseOver(mountain) {
        if (mountain.marker) {
            $(mountain.marker._icon).addClass('highlighted');
        }
    }

    onMouseOut(mountain) {
        if (mountain.marker) {
            $(mountain.marker._icon).removeClass('highlighted');
        }
    }

    onClick(mountain) {
        var name = mountain.name.replace(/\s/gmi, '_').replace(/[^a-z0-9_]/gmi, '')
        browserHistory.push('/mountain/' + mountain.id + '/' + name);
    }

    render() {

        var searchInput = (
            <div>
                <h2>Search</h2>
                <div>
                    <input
                        type="search" value={this.state.term}
                        placeholder="Search" className="form-control" autoFocus={true}
                        onChange={this.search} />
                </div>
            </div>
        );

        if (this.props.status.error) { return (<div>{searchInput}<NetworkError /></div>); }

        if (this.props.status.loading) { return (<div>{searchInput}<Loading /></div>); }

        if (this.props.mountains.length === 0) { return (<div>{searchInput}</div>); }

        return (
            <div>
                {searchInput}
                <FullHeight className='scrollable' style={{marginTop: '8px'}} allowance='174'>
                    <ol className='search-results'>
                        {
                            this.props.mountains.map((mountain) =>
                                <li
                                    key={mountain.id}
                                    onMouseOver={() => this.onMouseOver(mountain)}
                                    onMouseOut={() => this.onMouseOut(mountain)}
                                    onClick={() => this.onClick(mountain)}>
                                    <span className='name'>{mountain.name}</span>
                                    <span className='height'>{mountain.height}</span>
                                </li>
                            )
                        }                
                    </ol>
                </FullHeight>
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains.items,
        status: state.mountains.status
    };
}

const Search = connect(mapStateToProps)(SearchComponent);

export default Search;
