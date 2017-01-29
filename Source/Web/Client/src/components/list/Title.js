import React, { Component } from "react";
import { connect } from "react-redux";

import { fetchLists } from "../../state/lists";
import { fetchList } from "./actions";

import Loading from "../common/Loading";

class TitleComponent extends Component {

    componentDidMount() {
        if (this.props.routeParams.id) {
            this.props.dispatch(fetchList(this.props.routeParams.id));
        }
    }

    render() {
        if (this.props.list.status.loading) {
            return (<Loading />);
        }

        debugger;
        return (            
            <h2>{this.props.list.name}</h2>
        );
    }
}

const mapStateToProps = (state) => {

    return {
        list: state.list,
        lists: state.lists
    };

};

const Title = connect(mapStateToProps)(TitleComponent);

export default Title;
