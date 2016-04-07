require('es6-promise').polyfill();
var path = require('path');
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var WebpackNotifierPlugin = require('webpack-notifier');

module.exports = {
    entry: {
        app: [
            'webpack-dev-server/client?http://0.0.0.0:3000',
            'webpack/hot/only-dev-server',
            './src/app.js'
        ]
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
                loader: 'react-hot!babel-loader?' + JSON.stringify({ presets: ['es2015', 'react'] }),
                include: [path.resolve(__dirname, 'src')],
                exclude: /__test__/
            },
            {
                test: /\.css$/,
                loader: 'react-hot!style-loader!css-loader',
            },
            {
                test: /\.less$/,
                loader: "style-loader!css-loader!less-loader",    
                include: [path.resolve(__dirname, 'src')]
            },
            {
                test: /\.(png|jpg)$/,
                loader: 'react-hot!url-loader?limit=8192',
                include: [path.resolve(__dirname, 'src')]
            },
            {
                test: /\.(png)$/,
                loader: 'file-loader?name=images/leaflet/[path][name].[ext]&context=./node_modules/leaflet/dist/images',
                include: [path.resolve(__dirname, 'node_modules/leaflet/dist/images')]
            }
        ]
    },
    devtool: 'source-map',
    plugins: [
        new webpack.HotModuleReplacementPlugin(),
        new HtmlWebpackPlugin({
            template: './src/index.html',
            inject: 'body',
        }),
        new WebpackNotifierPlugin(),
        new webpack.DefinePlugin({ 'process.env': { 'NODE_ENV': JSON.stringify('development') } })
]};