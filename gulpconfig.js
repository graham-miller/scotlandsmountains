var dest = './dist/';
var destData = dest + 'data/';
var src = './src/client/';
var nodeModules = './node_modules/';
var deploy = '../ScotlandsMountains.github.io/';
 
module.exports = {
	srcHtml: src + 'app/**/*.html',
	srcSass: src + 'sass/**/*.scss',
	srcJs: [
		src + 'app/index.js',
		src + 'app/**/*.js'
	],
	srcCss: src + 'css/**/*',
	srcImg: [
		src + 'img/**/*',
		src + '!img/favicons/**/*',
		src + '!img/favicons/**',
		src + '!img/favicons/'
	],
	srcFav: src + 'img/favicons/**/*',
	srcData: './src/data/DoBIH_v14.3.csv',
	
	destAll: [
		dest + '**/*',
		'!' + destData + '**/*',
		'!' + destData + '**',
		'!' + destData,
	],
	dest: dest,
	destJs: dest + 'js/',
	destCss: dest + 'css/',
	destCssImg: dest + 'css/images/',
	destImg: dest + 'img/',
	destFav: dest,
	destFonts: dest + 'fonts/',
	destData: destData,

	libJs: [
		nodeModules + 'angular/angular.min.js',
		nodeModules + 'angular-route/angular-route.min.js',
		nodeModules + 'bootstrap/dist/js/bootstrap.min.js',
		nodeModules + 'jquery/dist/jquery.min.js',
		nodeModules + 'leaflet/dist/leaflet.js',
		nodeModules + 'leaflet.markercluster/dist/leaflet.markercluster.js'
	],
	libCss: [
		nodeModules + 'bootstrap/dist/css/bootstrap.min.css',
		nodeModules + 'leaflet/dist/leaflet.css',
		nodeModules + 'leaflet.markercluster/dist/MarkerCluster.css',
		nodeModules + 'leaflet.markercluster/dist/MarkerCluster.Default.css',
		nodeModules + 'font-awesome/css/font-awesome.min.css'
	],
	libCssImg: [
		nodeModules + 'leaflet/dist/images/**/*'
	],
	libFonts: [
		nodeModules + 'bootstrap/dist/fonts/*.*',
		nodeModules + 'font-awesome/fonts/*.*'
	],

	jsFileName: 'scotlands-mountains.min.js',
	cssFileName: 'scotlands-mountains.min.css',
	sassOptions: { outputStyle: 'compressed' },
	autoprefixerOptions: { browsers: ['last 2 versions', '> 5%', 'Firefox ESR'] },
	
	deployAll: [
		deploy + '**/*',
		'!' + deploy + '.git**/*',
		'!' + deploy + '.git**',
		'!' + deploy + '.git',
	],
	srcDeploy: dest + '**/*',
	destDeploy: deploy,
	domain: 'scotlandsmountains.net'
};