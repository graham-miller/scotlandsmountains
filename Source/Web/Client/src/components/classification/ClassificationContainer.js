import { connect } from 'react-redux';
import Classification from './Classification';

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains
    };
}

const ClassificationContainer = connect(mapStateToProps)(Classification);

export default ClassificationContainer;