import { connect } from 'react-redux';
import Mountain from './Mountain';

const mapStateToProps = (state) => {
    return {
        //mountains: state.mountains
    };
}

const MountainContainer = connect(mapStateToProps)(Mountain);

export default MountainContainer;