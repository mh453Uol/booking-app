const path = require('path');
const webpack = require('webpack');

const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const {
    CleanWebpackPlugin
} = require('clean-webpack-plugin');

const dirName = '../wwwroot/dist';

module.exports = (env, argv) => {
    return {
        mode: argv.mode === "production" ? "production" : "development",
        entry: {
            'main': ['./src/index.js', './src/sass/index.scss'],
            'vendors/jquery.min': './node_modules/jquery/dist/jquery.min.js',
            'vendors/jquery.validate.min': './node_modules/jquery-validation/dist/jquery.validate.min.js',
            'vendors/jquery.validate.unobtrusive.min': './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
            'vendors/bootstrap.min': ['./node_modules/bootstrap/dist/js/bootstrap.min.js', './node_modules/bootswatch/dist/flatly/bootstrap.min.css'],
            'vendors/poppers.min': './node_modules/popper.js/dist/popper.min.js'
        },
        output: {
            filename: '[name].js',
            path: path.resolve(__dirname, dirName)
        },
        module: {
            rules: [{
                    test: /\.s[c|a]ss$/,
                    use: [
                        'style-loader',
                        MiniCssExtractPlugin.loader,
                        'css-loader',
                        {
                            loader: 'postcss-loader',
                            options: {
                                config: {
                                    ctx: {
                                        env: argv.mode
                                    }
                                }
                            }
                        },
                        'sass-loader'
                    ]
                },
                {
                    test: /\.css$/,
                    use: [MiniCssExtractPlugin.loader, 'css-loader'],
                },
            ]
        },
        plugins: [
            new CleanWebpackPlugin(),
            new MiniCssExtractPlugin({
                filename: '[name].css'
            }),
            new webpack.ProvidePlugin({
                $: "jquery",
                jQuery: "jquery"
            }),
        ]
    };
};