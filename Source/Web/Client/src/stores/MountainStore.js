import alt from '../alt';
import MountainActions from '../actions/MountainActions';

class MountainStore {
    
    constructor() {
        this.mountains = [];
        this.errorMessage = null;
        this.bindListeners({
            handleUpdateMountains: MountainActions.UPDATE_MOUNTAINS,
            handleFetchMountains: MountainActions.FETCH_MOUNTAINS,
            handleMountainsFailed: MountainActions.MOUNTAINS_FAILED
        });
    }

    handleUpdateMountains(mountains) {
        this.mountains = mountains;
        this.errorMessage = null;
    }

    handleFetchMountains() {
        // reset the array while we're fetching new locations so React can
        // be smart and render a spinner for us since the data is empty.
        this.mountains = [];
    }

    handleMountainsFailed(errorMessage) {
        this.errorMessage = errorMessage;
    }
}

export default alt.createStore(MountainStore, 'MountainStore');