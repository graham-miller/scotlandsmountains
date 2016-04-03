require('es6-promise').polyfill();
var path = require('path');
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var WebpackNotifierPlugin = require('webpack-notifier');

module.exports = {
    entry: {
        app: [ './src/app.js' ]
    },
    output: {
        path: path.resolve(__dirname, 'build'),
        publicPath: '/',
        filename: 'assets/bundle.js'
    },
    module: {
        loaders: [
            {
                test: /\.js$/,
                loader: 'babel-loader?' + JSON.stringify({ presets: ['es2015', 'react'] }),
                include: [path.resolve(__dirname, 'src')],
                exclude: /__test__/
            },
            {
                test: /\.css$/,
                loader: 'style-loader!css-loader',
            },
            {
                test: /\.less$/,
                loader: "style-loader!css-loader!less-loader",    
                include: [path.resolve(__dirname, 'src')]
            },
            {
                test: /\.(png|jpg)$/,
                loader: 'url-loader?limit=8192',
                include: [path.resolve(__dirname, 'src')]
            },
            {
                test: /\.(png)$/,
                loader: 'file-loader?name=images/leaflet/[path][name].[ext]&context=./node_modules/leaflet/dist/images',
                include: [path.resolve(__dirname, 'node_modules/leaflet/dist/images')]
            }
        ]
    },
    plugins: [
        new HtmlWebpackPlugin({
            template: './src/index.html',
            inject: 'body',
        }),
        new WebpackNotifierPlugin(),
        new webpack.optimize.UglifyJsPlugin(),
        new webpack.optimize.OccurenceOrderPlugin(),
        new webpack.DefinePlugin({ DEBUG: false })
    ]
};