(function () {

    angular.module('sm.about').controller('AcknowedgementsController', ['$timeout', '$scope', function ($timeout, $scope) {

        var source = [
            {
                title: 'Angular',
                website: 'https://angularjs.org/',
                color: '#2B2B2B',
                logo: 'angular.png'
            },
            {
                title: 'Bing Maps',
                website: 'https://www.bingmapsportal.com/',
                color: '#505050',
                logo: 'bing.png'
            },
            {
                title: 'Bootstrap',
                website: 'http://getbootstrap.com/',
                color: '#5D4384',
                logo: 'bootstrap.png'
            },
            {
                title: 'Browsersync',
                website: 'http://www.browsersync.io/',
                color: '#0F2634',
                logo: 'browsersync.png'  
            },
            {
                title: 'Firefox',
                website: 'https://www.mozilla.org/firefox',
                color: '#E4E4E4',
                logo: 'firefox.png'
            },
            {
                title: 'Font Awesome',
                website: 'https://fortawesome.github.io/Font-Awesome/',
                color: '#1D9E74',
                logo: 'fontawesome.png'
            },
            {
                title: 'Github',
                website: 'https://github.com/',
                color: '#ffffff',
                logo: 'github.png'
            },
            {
                title: 'Gulp',
                website: 'http://gulpjs.com/',
                color: '#CF4646',
                logo: 'gulp.svg'
            },
            {
                title: 'Jasmine',
                website: 'http://jasmine.github.io/',
                color: '#EEEEEE',
                logo: 'jasmine.svg'
            },
            {
                title: 'jQuery',
                website: 'https://jquery.com/',
                color: '#343434',
                logo: 'jquery.gif'
            },
            {
                title: 'Karma',
                website: 'http://karma-runner.github.io/',
                color: '#ffffff',
                logo: 'karma.png'
            },
            {
                title: 'Leaflet',
                website: 'http://leafletjs.com/',
                color: '#ffffff',
                logo: 'leaflet.png'
            },
            {
                title: 'Node.js',
                website: 'https://nodejs.org/',
                color: '#333333',
                logo: 'node.svg'
            },
            {
                title: 'npm',
                website: 'https://www.npmjs.com/',
                color: '#EBEBEB',
                logo: 'npm.svg'
            },
            {
                title: 'sass',
                website: 'http://sass-lang.com/',
                color: '#F3F3F3',
                logo: 'sass.svg'
            },
            {
                title: 'Visual Studio Code',
                website: 'https://code.visualstudio.com/',
                color: '#373277',
                logo: 'code.svg'
            }
        ];

        var self = this;

        this.credits = [];
        while(source.length > 0) {
            var remaining = source.length;
            var position = Math.floor(Math.random() * remaining);
            this.credits.push(source.splice(position, 1)[0]);
        }
        
        this.year = new Date().getFullYear();
    }]);

})();
