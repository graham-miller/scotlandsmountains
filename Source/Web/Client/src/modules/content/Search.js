import React, { Component } from 'react';

import { search } from '../../actions/mountains';

import Mountain from './Mountain';
import './Mountains.scss';
import Loading from './Loading';

import getHeight from '../../util/getHeight';

class Search extends Component {

    constructor(props){
        super(props);

        this.state = {
            term: '',
            timeoutId: null
        }

        this.search = this.search.bind(this);
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

        if (this.props.mountains.status.error) {
            return (<div>Network error</div>);
        }

        if (this.props.mountains.status.loading) {
            return (<Loading />);
        }

        return (
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
                <div className="scrollable" style={{height: getHeight()-81}}>
                    <table className="table table-hover table-sm">
                        <tbody>
                            {
                                this.props.mountains.list.map((mountain, index) =>
                                    <Mountain key={mountain.id} mountain={mountain} index={index} />
                                )
                            }                
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}

export default Search;
