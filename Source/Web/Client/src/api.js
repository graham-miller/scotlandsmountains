import store from "./state/store";

//debugger;

const baseUrl = () => {
    const state = store.getState();
    return state.staticData.value ? state.staticData.value.apiBaseUrl : "/api/";
};

export function get (url, onStart, onSuccess, onError) {
    console.log("When '" + url + "' called, base URL is '" + baseUrl() + "'." );
    return dispatch => {
        dispatch(onStart());
        return fetch(url, {redirect: "follow", mode: "cors"})
            .then(response => {
                if (!response.ok) {
                    throw new Error();
                }
                return response.json();
            })
            .then(json => {
                dispatch(onSuccess(json));
            })
            .catch(function(error) {
                dispatch(onError());
            });
    };
};
