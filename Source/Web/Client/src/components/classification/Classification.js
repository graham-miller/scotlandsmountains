import React, { Component } from 'react';
import { browserHistory } from 'react-router';
import $ from 'jquery';

import { fetchClassification } from '../../actions/mountains';

import Loading from '../common/Loading';
import NetworkError from '../common/NetworkError';
import FullHeightContainer from '../common/FullHeightContainer'

import './Classification.scss'

class Classification extends Component {

    constructor(props) {
        super(props);

        this.onMouseOver = this.onMouseOver.bind(this);
        this.onMouseOut = this.onMouseOut.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    componentDidMount() {
        this.props.dispatch(fetchClassification(this.props.routeParams.table));
    }

    onMouseOver(mountain) {
        $(mountain.marker._icon).addClass('highlighted');
    }

    onMouseOut(mountain) {
        $(mountain.marker._icon).removeClass('highlighted');
    }

    onClick(mountain) {
        browserHistory.push('/mountain/' + mountain.id);
    }

    render() {

        if (this.props.mountains.status.error) { return (<NetworkError />); }

        if (this.props.mountains.status.loading) { return (<Loading />); }

        if (!this.props.mountains.classification) { return (<Loading />); }

        return (
            <div>
                <h2 style={{textTransform: 'capitalize'}}>{this.props.routeParams.table}</h2>
                <FullHeightContainer className='scrollable' allowance='128'>
                    <ol className='classification-table'>
                        {
                            this.props.mountains.classification.map((mountain, index) =>
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

export default Classification;
