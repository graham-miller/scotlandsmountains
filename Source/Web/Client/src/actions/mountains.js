export const REQUEST_START = 'REQUEST_START';
export const RECEIVE_MOUNTAIN = 'RECEIVE_MOUNTAIN';
export const RECEIVE_CLASSIFICATION = 'RECEIVE_CLASSIFICATION';
export const RECEIVE_SEARCH = 'RECEIVE_SEARCH';
export const REQUEST_IGNORED = 'REQUEST_IGNORED';
export const REQUEST_ERROR = 'REQUEST_ERROR';

function requestStart() { return { type: REQUEST_START } }

function receiveMountain(json) {
    return {
        type: RECEIVE_MOUNTAIN,
        mountain: json
    }
}

function receiveClassification(json) {
    return {
        type: RECEIVE_CLASSIFICATION,
        mountains: json
    }
}

function receiveSearch(json) {
    return {
        type: RECEIVE_SEARCH,
        searchResult: json
    }
}

function requestIgnored() { return { type: REQUEST_IGNORED } }

function requestError() { return { type: REQUEST_ERROR } }

export function fetchMountain(id) {
    return dispatch => {
        dispatch(requestStart());
        return fetch('/api/mountains/' + id, {
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
                dispatch(receiveMountain(json));
            })
            .catch(function(error) {
                dispatch(requestError());
            });
        }
}

export function fetchClassification(classification) {
    return dispatch => {
        dispatch(requestStart());
        return fetch('/api/classifications/mountains/' + classification, {
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
                dispatch(receiveClassification(json));
            })
            .catch(function(error) {
                dispatch(requestError());
            });
        }
}

export function search(term) {

    if (!term || term.length < 3) {
        return dispatch => dispatch(requestIgnored());
    }

    return dispatch => {
        dispatch(requestStart());
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
                dispatch(requestError());
            });
        }
}