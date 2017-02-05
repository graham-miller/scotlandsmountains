import React, { Component } from "react";
import { browserHistory } from "react-router";
import $ from "jquery";

import {List, ListItem} from "material-ui/List";
import {toFriendlyUrlName} from "../../utility";

class MountainTable extends Component {

    onMouseOver = (mountain) => {
        if (mountain.marker) {
            $(mountain.marker._icon).addClass("highlighted");
        }
    }

    onMouseOut = (mountain) => {
        if (mountain.marker) {
            $(mountain.marker._icon).removeClass("highlighted");
        }
    }

    onClick= (mountain) => {
        browserHistory.push("/mountain/" + mountain.id + "/" + toFriendlyUrlName(mountain.name));
    }

    render() {

        return (
            <List>
                {
                    this.props.mountains.map((mountain, index) =>
                        <ListItem
                            key={mountain.id}
                            leftAvatar={this.props.showRowNumbers ? <span style={{paddingTop:"4px"}}>{index+1}</span> : null}
                            primaryText={mountain.name}
                            secondaryText={mountain.height}
                            onTouchTap={() => this.onClick(mountain)}
                            onMouseOver={() => this.onMouseOver(mountain)}
                            onMouseOut={() => this.onMouseOut(mountain)} />
                    )
                }
            </List>
        );
    }
}

MountainTable.defaultProps = {
    showRowNumbers: false,
    mountains: []
};

export default MountainTable;
