var path = require("path");
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: {
        app: [
            'webpack-dev-server/client?http://0.0.0.0:3000',
            'webpack/hot/only-dev-server',
            './src/index.js'
        ]
    },
    output: {
        path: path.resolve(__dirname, "build"),
        publicPath: '/',
        filename: 'assets/bundle.js'
    },
    module: {
        loaders: [
            {
                test: /\.jsx?$/,
                loader: 'react-hot!babel-loader?' + JSON.stringify({ presets: ['es2015', 'react'] }),
                include: [path.resolve(__dirname, "src")]
            },
            {
                test: /\.css$/,
                loader: 'react-hot!style-loader!css-loader',
            },
            {
                test: /\.sass$/,
                loader: 'react-hot!style-loader!css-loader!sass-loader',
            },
            {
                test: /\.(png|jpg)$/,
                loader: 'react-hot!url-loader?limit=8192',
            }
        ]
    },
    devtool: "#cheap-source-map",
    plugins: [
        new webpack.HotModuleReplacementPlugin(),
        new HtmlWebpackPlugin({
            template: './src/index.html',
            inject: 'body',
        })
    ]
};