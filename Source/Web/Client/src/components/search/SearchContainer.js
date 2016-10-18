import { connect } from 'react-redux';
import Search from './Search';

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains
    };
}

const SearchContainer = connect(mapStateToProps)(Search);

export default SearchContainer;