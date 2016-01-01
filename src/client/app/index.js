(function ($) {

    angular.module('sm', ['sm.routing', 'sm.nav', 'sm.map', 'sm.about', 'sm.services']);

    angular.module('sm.routing', ['ngRoute']);

    angular.module('sm.nav', ['sm.services']);

    angular.module('sm.mountain', []);

    angular.module('sm.map', ['sm.services', 'sm.map.search', 'sm.map.settings', 'sm.map.toolbar']);
    angular.module('sm.map.search', []);
    angular.module('sm.map.settings', []);
    angular.module('sm.map.toolbar', []);

    angular.module('sm.about', []);

    angular.module('sm.services', []);

    // collapse bootstrap menu after click 
    $(document).on('click', '.navbar-collapse.in', function (e) {
        if ($(e.target).is('a') && $(e.target).attr('class') != 'dropdown-toggle') {
            $(this).collapse('hide');
        }
    });

})(jQuery);
