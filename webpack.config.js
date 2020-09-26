// Note this only includes basic configuration for development mode.
// For a more comprehensive configuration check:
// https://github.com/fable-compiler/webpack-config-template

var path = require("path");

module.exports = {
    mode: "development",
    target: "electron-main",
    entry: "./src/App.fsproj",
    node: {
        __dirname: false
    },
    output: {
        path: path.join(__dirname, "public"),
        filename: "main.js",
    },
    module: {
        rules: [{
            test: /\.fs(x|proj)?$/,
            use: "fable-loader"
        }]
    }
}