const MountainSource = {
    search: (term) => {
        return fetch('api/mountains/search/' + term, { mode: 'cors', redirect: 'follow'})
            .then((response) => {
                if (response.ok) {
                    return response.json();
                }
                else {
                    throw Error(response.statusText);
                }
            })
            .catch((error) => {
                throw Error(error.message);
            });
    }
};

export default MountainSource;