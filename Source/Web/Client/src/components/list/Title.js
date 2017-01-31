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
        
        // if (this.props.lists.length === 0) {
        //     return <Loading />;
        // }

        return (           
            <div style={{position:"relative",width:"100%"}}>
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
                <div style={{position:"absolute",right:0,top:0,width:"auto"}}> {
                    this.props.list.status.loading ? <Loading/> : null // TODO position this better
                } </div>
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
