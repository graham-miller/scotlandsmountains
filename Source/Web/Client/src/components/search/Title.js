import React, { Component } from "react";
import { connect } from "react-redux";

import TextField from "material-ui/TextField";

import { search } from "./actions";
import { reset } from "../map/actions";

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
                <TextField
                    hintText="Search"
                    fullWidth={true}
                    value={this.state.term}
                    type="search"
                    onChange={this.search}
                    className="mountains"
                    autoFocus={true} />
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        search: state.search.value,
        status: state.search.status
    };
};

const Search = connect(mapStateToProps)(SearchComponent);

export default Search;
