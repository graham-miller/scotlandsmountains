import alt from '../alt';
import MountainActions from '../actions/MountainActions';

class MountainStore {
    
    constructor() {
        this.mountains = [];
        this.errorMessage = null;
        this.bindListeners({
            handleUpdate: MountainActions.UPDATE,
            handleSearch: MountainActions.SEARCH,
            handleFailed: MountainActions.FAILED
        });
    }

    handleUpdate(mountains) {
        this.mountains = mountains;
        this.errorMessage = null;
    }

    handleSearch() {
        // reset the array while we're waiting so we can render a spinner
        this.mountains = [];
    }

    handleFailed(errorMessage) {
        this.errorMessage = errorMessage;
    }
}

export default alt.createStore(MountainStore, 'MountainStore');