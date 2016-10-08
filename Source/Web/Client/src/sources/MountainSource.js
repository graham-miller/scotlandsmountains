const MountainSource = {
    search: (term) => {
        return fetch(encodeURI('api/mountains/search/' + term), {mode: 'no-cors', redirect: 'follow'})
            .then((response) => {
                //if (!response.ok) {
                //    throw Error(response.statusText);
                //}
                return response.json();
            })
            .catch((error) => {
                return error.message;
            });
    }
};

export default MountainSource;