import alt from '../alt';

import MountainSource from '../sources/MountainSource';

class MountainActions {

    search(term) {
        return (dispatch) => {
            dispatch();
            MountainSource.search(term)
                .then((search) => this.update(search.results))
                .catch((errMsg) => this.failed(errMsg));
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