import React, { Component } from "react";
import { connect } from "react-redux";

import Loading from "../common/Loading";

class TitleComponent extends Component {

    componentDidMount() {

        //this.props.params.id

    }

    render() {
        if (this.props.list.status.loading) {
            return (<Loading />);
        }
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
