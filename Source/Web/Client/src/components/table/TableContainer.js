import { connect } from 'react-redux';
import Table from './Table';

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains
    };
}

const TableContainer = connect(mapStateToProps)(Table);

export default TableContainer;