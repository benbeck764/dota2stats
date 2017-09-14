module.exports = function () {

    var base = {
        webroot: "./wwwroot/",
        node_modules: "./node_modules/"
    };

    var config = {
        /**
         * Files paths
         */
        angular: base.node_modules + "@angular/**/*.js",
        app: "App/**/*.*",
        appDest: base.webroot + "app",
        js: base.webroot + "js/*.js",
        jsDest: base.webroot + 'js',
        css: base.webroot + "css/*.css",
        cssDest: base.webroot + 'css',
        lib: base.webroot + "lib/",
        node_modules: base.node_modules,
        indexHtml: "Index.html",
        indexHtmlDest: base.webroot,
        publicDir: "public/**/*.*",
        publicDirDest: base.webroot + "public",
        styles: "styles.css",
        systemJsConfig: "systemjs.config.js",
        systemJsConfigDest: base.webroot,
        angularWebApi: base.node_modules + "angular-in-memory-web-api/*.js",
        bootstrap: base.node_modules + "bootstrap/dist/css/*",
        corejs: base.node_modules + "core-js/client/shim*.js",
        zonejs: base.node_modules + "zone.js/dist/zone*.js",
        reflectjs: base.node_modules + "reflect-metadata/Reflect*.js",
        systemjs: base.node_modules + "systemjs/dist/*.js",
        rxjs: base.node_modules + "rxjs/**/*.js"
    };

    return config;
};