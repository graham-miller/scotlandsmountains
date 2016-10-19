import React, { Component } from 'react';
import { browserHistory } from 'react-router';
import $ from 'jquery';

import { clearList,fetchTable } from '../../actions/mountains';

import Loading from '../common/Loading';
import FullHeightContainer from '../common/FullHeightContainer'

import './Table.scss'

class Table extends Component {

    constructor(props) {
        super(props);

        this.onMouseOver = this.onMouseOver.bind(this);
        this.onMouseOut = this.onMouseOut.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    componentWillMount() {
        this.props.dispatch(clearList());
    }

    componentDidMount() {
        this.props.dispatch(fetchTable(this.props.routeParams.table));
    }

    onMouseOver(mountain) {
        $(mountain.marker._icon).addClass('highlighted');
    }

    onMouseOut(mountain) {
        $(mountain.marker._icon).removeClass('highlighted');
    }

    onClick(mountain) {
        browserHistory.push('/mountain/' + mountain.id + '/' + mountain.name);
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
                    <h2 style={{textTransform: 'capitalize'}}>{this.props.routeParams.table}</h2>
                </div>
                <FullHeightContainer className='scrollable' allowance='128'>
                    <ol className='classification-table'>
                        {
                            this.props.mountains.list.map((mountain, index) =>
                                <li
                                    key={mountain.id}
                                    onMouseOver={() => this.onMouseOver(mountain)}
                                    onMouseOut={() => this.onMouseOut(mountain)}
                                    onClick={() => this.onClick(mountain)}>
                                    <span className='number'>{index+1}</span>
                                    <span className='name'>{mountain.name}</span>
                                    <span className='height'>{mountain.height}</span>
                                </li>
                            )
                        }                
                    </ol>
                </FullHeightContainer>
            </div>
        );
    }
}

export default Table;
