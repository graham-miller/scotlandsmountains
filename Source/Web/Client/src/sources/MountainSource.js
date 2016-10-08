const MountainSource = {
    search: (term) => {
        return fetch(encodeURI('api/mountains/search/' + term), {mode: 'no-cors', redirect: 'follow'})
        //return fetch(encodeURI('https://scotlandsmountains.azurewebsites.net/api/mountains/search/' + term), {mode: 'no-cors', redirect: 'follow'})
            .then((response) => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json().then();
            })
            .then((json) => json)
            .catch((error) => {
                return error.message;
            });
    }
};

export default MountainSource;