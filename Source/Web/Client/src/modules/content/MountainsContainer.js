import { connect } from 'react-redux';
import Mountains from './Mountains';

const mapStateToProps = (state) => {
    return {
        loading: state.mountains.loading,
        error: state.mountains.error,
        mountains: state.mountains.mountains
    };
}

const MountainsContainer = connect(mapStateToProps)(Mountains);

export default MountainsContainer;