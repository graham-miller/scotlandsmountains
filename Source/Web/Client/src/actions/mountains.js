function requestTable() {
    return {
        type: 'REQUEST_TABLE',
    }
}

function receiveTable(json) {
    return {
        type: 'RECEIVE_TABLE',
        mountains: json
    }
}

function requestSearch(term) {
    return {
        type: 'REQUEST_SEARCH',
        term
    }
}

function receiveSearch(json) {
    return {
        type: 'RECEIVE_SEARCH',
        searchResult: json
    }
}

function networkError() {
    return {
        type: 'NETWORK_ERROR'
    }
}

export function fetchTable(table) {
    return dispatch => {
        dispatch(requestTable())
        return fetch('/api/mountains/' + table, {
            redirect: 'follow',
            mode: 'cors'
        })
        .then(response => {
            if (!response.ok) {
                throw new Error();
            }
            return response.json();
        })
        .then(json => {
            dispatch(receiveTable(json));
        })
        .catch(function(error) {
            dispatch(networkError());
        });
    }
}

export function search(term) {
    return dispatch => {
        dispatch(requestSearch(term))
        return fetch('/api/mountains/search/' + term, {
            redirect: 'follow',
            mode: 'cors'
        })
        .then(response => {
            if (!response.ok) {
                throw new Error();
            }
            return response.json();
        })
        .then(json => {
            dispatch(receiveSearch(json));
        })
        .catch(function(error) {
            dispatch(networkError());
        });
    }
}