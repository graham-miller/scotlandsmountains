import React, { Component } from "react";
import { connect } from "react-redux";

import { search } from "../../actions/mountains";
import { reset } from "../../actions/map";

import "./Search.scss";

class SearchComponent extends Component {

    constructor(props){
        super(props);

        this.state = {
            term: "",
            timeoutId: null
        };

        this.search = this.search.bind(this);
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

    render() {

        return (
            <div>
                <input
                    type="search" value={this.state.term}
                    placeholder="Search" className="mountains" autoFocus={true}
                    onChange={this.search} />
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains.items,
        status: state.mountains.status
    };
};

const Search = connect(mapStateToProps)(SearchComponent);

export default Search;
