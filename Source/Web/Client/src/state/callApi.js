const callApi = function (url, onStart, onSuccess, onError) {
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

export default callApi;