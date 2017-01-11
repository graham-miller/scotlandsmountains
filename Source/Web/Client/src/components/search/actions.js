import callApi from "../../state/callApi";

export const Actions = {
    StartSearch: "START_SEARCH",
    ReceiveResults: "RECEIVE_RESULTS",
    SearchError: "SEARCH_ERROR",
};

function startSearch() {
    return {
        type: Actions.StartSearch
    };
}

function receiveResults(json) {
    return {
        type: Actions.ReceiveResults,
        json
    };
}

function searchError() {
    return {
        type: Actions.SearchError
    };
}

export function search(term) {
    return callApi("/api/search/" + term, startSearch, receiveResults, searchError);
}
