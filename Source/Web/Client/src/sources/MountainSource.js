import request from 'superagent';

const MountainSource = {
    search: (term) => {
        return request
            .get('https://scotlandsmountains.azurewebsites.net/api/mountains/search/' + term)
            .then((response) => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.body;
            })
            .catch((error) => {
                throw Error(error.message);
            });
    }
};

export default MountainSource;