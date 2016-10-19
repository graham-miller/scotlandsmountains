import React, { Component } from 'react';
import { browserHistory } from 'react-router';
import $ from 'jquery';

import { clearList, search } from '../../actions/mountains';

import Loading from '../common/Loading';
import FullHeightContainer from '../common/FullHeightContainer'

import './Search.scss'

class Search extends Component {

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
        this.props.dispatch(clearList());
    }

    search(event) {
        
        this.setState({term: event.target.value});

        if (this.state.timeoutId) {
            clearTimeout(this.state.timeoutId);
        }

        const delay = 400;

        this.setState({
            timeoutId: setTimeout(() => {
                this.props.dispatch(search(this.state.term));
            }, delay)
        });
    }

    onMouseOver(mountain) {
        $(mountain.marker._icon).addClass('highlighted');
    }

    onMouseOut(mountain) {
        $(mountain.marker._icon).removeClass('highlighted');
    }

    onClick(mountain) {
        browserHistory.push('/mountain/' + mountain.id + '/' + mountain.name);
    }

    render() {

        var searchInput = (
            <div>
                <div>
                    <h2>Search</h2>
                </div>
                <div>
                    <input
                        type="search" value={this.state.term}
                        placeholder="Search" className="form-control" autoFocus={true}
                        onChange={this.search} />
                </div>
            </div>
        );

        if (this.props.mountains.status.error) {
            return (
                <div>
                    {searchInput}
                    <div>Network error</div>
                </div>
            );
        }

        if (this.props.mountains.status.loading) {
            return (
                <div>
                    {searchInput}
                    <Loading />
                </div>
            );
        }

        if (this.props.mountains.list.length === 0) {
            return (
                <div>
                    {searchInput}
                </div>
            );
        }

        return (
            <div>
                {searchInput}
                <FullHeightContainer className='scrollable' style={{marginTop: '8px'}} allowance='174'>
                    <ol className='search-results'>
                        {
                            this.props.mountains.list.map((mountain) =>
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
                </FullHeightContainer>
            </div>
        );
    }
}

export default Search;
