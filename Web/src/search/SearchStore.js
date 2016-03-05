import alt from '../alt';
import SearchActions from './SearchActions';

class SearchStore {
    constructor() {

        this.bindListeners({
            handleUpdate: SearchActions.UPDATE,
            handleSelect: SearchActions.SELECT
        });
    }

    handleUpdate() {
        alert("Update");
    }
    
    handleSelect() {
        alert("Select");
    }

}

export default alt.createStore(SearchStore, 'SearchStore');