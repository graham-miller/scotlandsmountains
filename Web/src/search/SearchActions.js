import alt from '../alt';

class SearchActions {

    Update(term) {
        return term;
    }

    Select(key) {
        return key;
    }

}

export default alt.createActions(SearchActions);