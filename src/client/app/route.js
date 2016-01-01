(function ($) {

    angular.module('sm.routing').config(['$routeProvider', function ($routeProvider) {


        var showMap = function() {
            $("#sm-map-container").show();
            $("#sm-content").hide();
        };
        
        var showContent = function() {
            $("#sm-map-container").hide();
            $("#sm-content").show();
        };


        $routeProvider
            .when('/', {
                template: '',
                controller: showMap
            })
            .when('/tables', {
                templateUrl: function(params){ return '/tables/index.html'; },
                controller: [function(TablesController) {
                    showContent();
                    return TablesController;
                }]
            })
            .when('/about', {
                templateUrl: function(params){ return '/about/index.html'; },
                controller: showContent
            })
            .when('/about/acknowledgements', {
                templateUrl: '/about/acknowledgements/acknowledgements.html',
                controller: [function(AcknowledgementsController) {
                    showContent();
                    return AcknowledgementsController;
                }]
            })
            .when('/about/:page', {
                templateUrl: function(params){ return '/about/' + params.page + '.html'; },
                controller: showContent
            })
            .when('/account/:page', {
                templateUrl: function(params){ return '/account/' + params.page + '.html'; },
                controller: showContent
            })
            .otherwise({ redirectTo: '/' });

    }]);

})(jQuery);
