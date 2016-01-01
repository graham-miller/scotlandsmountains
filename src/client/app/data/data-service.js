(function () {

    angular.module('sm.services').service('sm.services.data', ['$http', function ($http) {

        var mountains = null;

        var getMountains = function (callback) {
            if (mountains === null) {
                $http.get('data/index.json').
                    then(function (response) {
                        createMountains(response.data);
                        callback(mountains);
                    }, function (response) {
                        // TODO handle error
                        alert('Error getting mountain data: ' + response);
                    });
            } else {
                callback(mountains);
            }
        };

        var createMountains = function (data) {
            mountains = [];
            for (var i = 0; i < data.length; i++) {
                var mountain = data[i];
                var classification = getClassificationFor(mountain[5]);
                mountains.push({
                    id: mountain[0],
                    name: mountain[1],
                    latitude: parseFloat(mountain[2]),
                    longitude: parseFloat(mountain[3]),
                    height: parseInt(mountain[4]),
                    description: mountain[4] + (classification !== '' ? 'm (' + classification + ')' : 'm'),
                    classification: classification
                });

            }
        };

        var getClassificationFor = function (code) {
            switch (code) {
                case 'M':
                    return 'Munro';
                case 'C':
                    return 'Corbett';
                case 'G':
                    return 'Graham';
                default:
                    return '';
            }
        };

        this.isLoaded = function () { return mountains === null; };

        this.mountains = function(callback) {
            getMountains(callback);
        };

        this.getById = function(id, callback) {
            getMountains(function(mountains) {
                var result = mountain;
                for (var i = 0; i < mountains.length; i++) {
                    var mountain = mountains[i];
                    if (mountain.id === id) {
                        callback(mountain);
                        break;
                    }
                }
            });
        };

        this.search = function(term, callback) {
            getMountains(function(mountains) {
                var uCaseTerm = term.toUpperCase();
                var results = [];
                for (var i = 0; i < mountains.length; i++) {
                    var mountain = mountains[i];
                    if (mountain.name.toUpperCase().indexOf(uCaseTerm) >= 0) {
                        results.push(mountain);
                    }
                }
                callback(results);
            });
        };

    }]);

})();
