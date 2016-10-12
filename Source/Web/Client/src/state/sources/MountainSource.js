const callApi = (url) => {
    return fetch(url, { mode: 'cors', redirect: 'follow'})
        .then((response) => {
            if (response.ok) { return response.json(); }
            else { throw Error(response.statusText); }
        })
        .catch((error) => { throw Error(error.message); });
}

const MountainSource = {
    getTable: (name) => { return callApi('api/mountains/' + name); },
    search: (term) => { return callApi('api/mountains/search/' + term); }
};

export default MountainSource;