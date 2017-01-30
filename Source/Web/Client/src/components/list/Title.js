import React, { Component } from "react";
import { connect } from "react-redux";
import { browserHistory } from "react-router";

import SelectField from "material-ui/SelectField";
import MenuItem from "material-ui/MenuItem";

import { fetchLists } from "../../state/lists";
import { fetchList } from "./actions";

import Loading from "../common/Loading";

class TitleComponent extends Component {

    componentDidMount() {
        this.props.dispatch(fetchLists());
        if (this.props.routeParams.id) {
            this.props.dispatch(fetchList(this.props.routeParams.id));            
        }
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.routeParams.id !== nextProps.routeParams.id) {
            if (!nextProps.routeParams.id && this.props.lists.length > 0) {
                browserHistory.push("/lists/" + this.props.lists[0].id);
            } else {
                this.props.dispatch(fetchList(nextProps.routeParams.id));            
            }
        }
    }

    handleChange = (event, index, value) => {
        browserHistory.push("/lists/" + value);
    }

    render() {
        
        let loading = null;
        if (this.props.lists.length === 0 || this.props.list.status.loading) {
            loading = (<Loading />);
            return loading;
        }

        return (           
            <div>
                <SelectField
                    floatingLabelText="List"
                    value={this.props.routeParams.id || this.props.lists[0].id}
                    onChange={this.handleChange}>
                    {
                        this.props.lists.map((list,index) => 
                            <MenuItem key={index} value={list.id} primaryText={list.name} />
                        )
                    }
                </SelectField>
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
