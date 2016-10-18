import React, { Component } from 'react';

import { clearList, search } from '../../actions/mountains';

import Result from './Result';
import Loading from '../common/Loading';
import FullHeightContainer from '../common/FullHeightContainer'

class Search extends Component {

    constructor(props){
        super(props);

        this.state = {
            term: '',
            timeoutId: null
        }


        this.search = this.search.bind(this);
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

    render() {

        var searchInput = (
            <div>
                <div>
                    <h2>Search</h2>
                </div>
                <div>
                    <input
                        type="search" id="search-input" value={this.state.term}
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
                    <table className="table table-hover table-sm">
                        <tbody>
                            {
                                this.props.mountains.list.map((mountain) =>
                                    <Result key={mountain.id} mountain={mountain} />
                                )
                            }                
                        </tbody>
                    </table>
                </FullHeightContainer>
            </div>
        );
    }
}

export default Search;
