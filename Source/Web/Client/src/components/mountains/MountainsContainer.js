import { connect } from 'react-redux';
import Mountains from './Mountains';

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains
    };
}

const MountainsContainer = connect(mapStateToProps)(Mountains);

export default MountainsContainer;