// Json server
var jsonServer = require('json-server');
var mocks = require('./api_mocks/mocks');

var server = jsonServer.create();
server.use(jsonServer.defaults());
server.get('/api/search/ben', function (req, res) { res.json(mocks.searchResults); })
server.get('/api/classification/munro/mountains', function (req, res) { res.json(mocks.munros); })
server.get('/api/classification/corbett/mountains', function (req, res) { res.json(mocks.corbetts); })
server.get('/api/classification/graham/mountains', function (req, res) { res.json(mocks.grahams); })
server.listen(3001);

// Webpack dev server
var webpack = require('webpack');
var WebpackDevServer = require('webpack-dev-server');
var config = require('./webpack.debug.config');
var open = require('open');

new WebpackDevServer(webpack(config), {
    proxy: {
        '/api/*': 'http://localhost:3001'
    },
    publicPath: config.output.publicPath,
    hot: true,
    historyApiFallback: true
}).listen(3000, 'localhost', function(err, result) {
    if (err) {
        console.log(err);
    }
    console.log('Listening at localhost:3000');
    open('http://localhost:3000');
});
