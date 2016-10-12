import alt from '../alt';

import MountainSource from '../sources/MountainSource';

class MountainActions {

    getTable(name) {
        return (dispatch) => {
            dispatch();
            MountainSource.getTable(name)
                .then((mountains) => this.update(mountains))
                .catch((error) => this.failed(error.message));
        }
    }

    search(term) {
        return (dispatch) => {
            dispatch();
            MountainSource.search(term)
                .then((search) => this.update(search.results))
                .catch((error) => this.failed(error.message));
        }
    }

    update(mountains) {
        return mountains;
    }

    failed(errMsg) {
        return errMsg;
    }
}

export default alt.createActions(MountainActions);