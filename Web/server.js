// Json server
var jsonServer = require('json-server');
var mocks = require('./api-mocks');
var server = jsonServer.create();
server.use(jsonServer.defaults());
server.get('/api/search/ben', function (req, res) { res.json(mocks.searchResults); })
server.listen(4000);

// Webpack dev server
var webpack = require('webpack');
var WebpackDevServer = require('webpack-dev-server');
var config = require('./webpack.config');
var open = require('open');

new WebpackDevServer(webpack(config), {
    proxy: {
        '/api/*': 'http://localhost:4000'
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
