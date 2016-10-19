import React, { Component } from 'react';

import { fetchTable } from '../../actions/mountains';

import Row from './Row';
import Loading from '../common/Loading';
import FullHeightContainer from '../common/FullHeightContainer'

class Table extends Component {

    componentDidMount() {
        this.props.dispatch(fetchTable(this.props.routeParams.table));
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
                    <table className="table table-hover table-sm">
                        <tbody>
                            {
                                this.props.mountains.list.map((mountain, index) =>
                                    <Row key={mountain.id} mountain={mountain} index={index} />
                                )
                            }                
                        </tbody>
                    </table>
                </FullHeightContainer>
            </div>
        );
    }
}

export default Table;
