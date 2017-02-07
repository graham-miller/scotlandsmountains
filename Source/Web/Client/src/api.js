import store from "./state/store";

const baseUrl = () => {
    const state = store.getState();
    return state.staticData.value ? state.staticData.value.apiBaseUrl : "/api/";
};

export function get (path, onStart, onSuccess, onError) {
    return dispatch => {
        dispatch(onStart());
        return fetch(baseUrl() + path, {redirect: "follow", mode: "cors"})
            .then(response => {
                if (!response.ok) {
                    throw new Error();
                }
                return response.json();
            })
            .then(json => dispatch(onSuccess(json)))
            .catch(error => dispatch(onError(error)));
    };
};

export function post (path, data, onSuccess, onError) {
    return fetch(baseUrl() + path, {
        method: "post",
        body: data,
        mode: "cors",
        headers: { 
            "Accept": "application/json",
            "Content-Type": "application/json" 
        },
    })
    .then(response => {if (!response.ok) { throw new Error();}})
    .then(body => onSuccess())
    .catch(error => onError());
};
