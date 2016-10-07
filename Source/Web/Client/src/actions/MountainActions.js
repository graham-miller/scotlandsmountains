import alt from '../alt';

import MountainSource from '../sources/MountainSource';

class MountainActions {

    fetchMountains() {
        var that = this;
        return function(dispatch) {
            dispatch();
            MountainSource.fetch()
                .then(function(locations) {
                    that.updateMountains(locations);
                })
                .catch(function(errorMessage) {
                    that.mountainsFailed(errorMessage);
                });
        }
    }

    updateMountains(mountains) {
        return mountains;
    }

    mountainsFailed(errorMessage) {
        return errorMessage;
    }
}

export default alt.createActions(MountainActions);