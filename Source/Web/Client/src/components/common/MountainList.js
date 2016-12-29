import React, { Component } from "react";
import { browserHistory } from "react-router";
import $ from "jquery";

import {List, ListItem} from "material-ui/List";

class MountainTable extends Component {
    
    constructor(props){
        super(props);

        this.onMouseOver = this.onMouseOver.bind(this);
        this.onMouseOut = this.onMouseOut.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    onMouseOver(mountain) {
        if (mountain.marker) {
            $(mountain.marker._icon).addClass("highlighted");
        }
    }

    onMouseOut(mountain) {
        if (mountain.marker) {
            $(mountain.marker._icon).removeClass("highlighted");
        }
    }

    onClick(mountain) {
        var name = mountain.name.replace(/\s/gmi, "_").replace(/[^a-z0-9_]/gmi, "");
        browserHistory.push("/mountain/" + mountain.id + "/" + name);
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
