import React, { Component } from "react";
import { connect } from "react-redux";
import { browserHistory } from "react-router";

import SelectField from "material-ui/SelectField";
import MenuItem from "material-ui/MenuItem";

import { fetchLists } from "../../state/lists";
import { fetchList } from "./actions";
import { toFriendlyUrlName } from "../../utility";
import Loading from "../common/Loading";

class TitleComponent extends Component {

    componentDidMount() {
        this.props.dispatch(fetchLists());
        if (this.props.routeParams.id) {
            this.props.dispatch(fetchList(this.props.routeParams.id));
        }
    }

    componentWillReceiveProps(nextProps) {
        const currentId = this.props.routeParams.id;
        const nextId = nextProps.routeParams.id;
        const listsLoaded = this.props.lists.length > 0;
        const defaultId = listsLoaded ? this.props.lists[0].id : "";
        const defaultName = listsLoaded ? toFriendlyUrlName(this.props.lists[0].name) : "";

        if (!nextId && listsLoaded) {
            browserHistory.replace("/lists/" + defaultId + "/" + defaultName);
        }

        if (currentId !== nextId) {
            if (!nextId && listsLoaded) {
                browserHistory.replace("/lists/" + defaultId + "/" + defaultName);
            } else {
                this.props.dispatch(fetchList(nextId));
            }
        }
    }

    handleChange = (event, index, value) => {
        browserHistory.push("/lists/" + value + "/" + toFriendlyUrlName(this.props.lists[index].name));
    }

    render() {

        let list = null;
        if (this.props.lists.length > 0) {
            list = (
                <SelectField
                    floatingLabelText="List"
                    value={this.props.routeParams.id || this.props.lists[0].id}
                    onChange={this.handleChange}>
                    {
                        this.props.lists.map((list, index) =>
                            <MenuItem key={index} value={list.id} primaryText={list.name} />
                        )
                    }
                </SelectField>
            );
        } else {
            list = (
                <SelectField floatingLabelText="List" value="">
                    <MenuItem value="" primaryText="Loading" />
                </SelectField>
            );
        }

        let spinner = null;
        if (this.props.list.status.Loading || !this.props.list.value) {
            spinner = (
                <Loading text="" wrapperStyle={{ position: "relative", display: "inline", left: "10px", top: "-10px" }} />
            );
        }

        return (
            <div style={{ width: "100%" }}>
                {list}
                {spinner}
            </div>
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
