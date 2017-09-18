/// <binding AfterBuild='default' Clean='clean' />
/// 
"use strict";

var gulp = require('gulp');
var config = require('./gulp.config')();
var cleanCSS = require('gulp-clean-css');
var clean = require('gulp-clean');
var rename = require('gulp-rename');
var gutil = require('gulp-util');
var watch = require('gulp-watch');
var refresh = require('gulp-refresh');
var ts = require('gulp-typescript');
var $ = require('gulp-load-plugins')({ lazy: true });

gulp.task("clean:wwwroot", function (cb) {
    return gulp.src('wwwroot/*', { read: false }).pipe(clean());
});

gulp.task("clean:js", function (cb) {
    return gulp.src('wwwroot/js/*.min.js', { read: false }).pipe(clean());
});

gulp.task("clean:css", function (cb) {
    return gulp.src('wwwroot/css/*.min.css', { read: false }).pipe(clean());
});

gulp.task('minify:css', function () {
    return gulp.src(config.css)
        .pipe(cleanCSS())
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(gulp.dest(config.cssDest));
});

gulp.task("clean", ["clean:wwwroot"]);//["clean:js", "clean:css"]);
gulp.task('minify', ['minify:css']);

gulp.task("copy:angular", function () {

    return gulp.src(config.angular,
            { base: config.node_modules + "@angular/" })
        .pipe(gulp.dest(config.lib + "@angular/"));
});

gulp.task("copy:angularWebApi", function () {
    return gulp.src(config.angularWebApi,
            { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:bootstrap", function () {
    return gulp.src(config.bootstrap,
            { base: config.node_modules })
        .pipe(gulp.dest(config.cssDest));
});

gulp.task("copy:corejs", function () {
    return gulp.src(config.corejs,
            { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:zonejs", function () {
    return gulp.src(config.zonejs,
            { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:reflectjs", function () {
    return gulp.src(config.reflectjs,
            { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:systemjs", function () {
    return gulp.src(config.systemjs,
            { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:rxjs", function () {
    return gulp.src(config.rxjs,
            { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("copy:app", function () {
    return gulp.src(config.app)
        .pipe(gulp.dest(config.appDest));
});

gulp.task("copy:indexHtml", function () {
    return gulp.src(config.indexHtml)
        .pipe(gulp.dest(config.indexHtmlDest));
});

gulp.task("copy:public", function () {
    return gulp.src(config.publicDir)
        .pipe(gulp.dest(config.publicDirDest));
});

gulp.task("copy:styles", function () {
    return gulp.src(config.styles)
        .pipe(gulp.dest(config.cssDest));
});

gulp.task("copy:systemJsConfig", function () {
    return gulp.src(config.systemJsConfig)
        .pipe(gulp.dest(config.systemJsConfigDest));
});

gulp.task("copy:envConfig", function () {
    return gulp.src(config.config)
        .pipe(gulp.dest(config.configDest));
});

gulp.task("copy:angular4DataTable", function () {
    return gulp.src(config.angular4DataTable, 
        { base: config.node_modules })
        .pipe(gulp.dest(config.lib));
});

gulp.task("dependencies", [
    "copy:angular",
    "copy:angular4DataTable",
    "copy:angularWebApi",
    "copy:bootstrap",
    "copy:corejs",
    "copy:zonejs",
    "copy:reflectjs",
    "copy:systemjs",
    "copy:rxjs",
    "copy:app",
    "copy:indexHtml",
    "copy:public",
    "copy:styles",
    "copy:systemJsConfig",
    "copy:envConfig"
]);

gulp.task("start-livereload", function() {
    livereload.listen({ start: true });
});

gulp.task("watch-html", function() {
    //HTML change + prints log in console
    gulp.watch('app/**/*.html').on('change', function (file) {
        console.log(file.path);
        gulp
            .src(file.path, { "base": config.baseWebRoot })
            .pipe(gulp.dest(config.appDest))
            .pipe(refresh(file.path));
    });
});

gulp.task("watch-ts", ['copy:app'], function () {
    // Javascript change + prints log in console
    return watch('app/**/*.ts').on('change', function(file) {
        refresh.changed(file);
            gutil.log(gutil.colors.yellow('TypeScript file changed' + ' (' + file + ')'));
        });
});

gulp.task("watch-css", function () {
    // SASS/CSS change + prints log in console
    gulp.watch('app/**/*.css').on('change', function (file) {
        console.log(file.path);
        gulp
            .src(file.path)
            .pipe(gulp.dest(config.appDest))
            .pipe(refresh());
    });
});

var tsProject = ts.createProject('tsconfig.json');

gulp.task("watch", ['watch-html', 'watch-css'], function () {

    // Start gulp-refresh (live-reload)
    refresh.listen({ start: true });

    //gulp.watch('app/**/*.html').on('change', function (file) {
    //    console.log(file.path);
    //    gulp
    //        .src(file.path, { "base": config.baseWebRoot })
    //        .pipe(gulp.dest(config.appDest))
    //        .pipe(refresh());
    //});

    //gulp.watch('app/**/*.css').on('change', function (file) {
    //    console.log(file.path);
    //    gulp
    //        .src(file.path, { "base": config.baseWebRoot })
    //        .pipe(gulp.dest(config.appDest))
    //        .pipe(refresh());
    //});

    gulp.watch('app/**/*.ts').on('change', function (file) {

        var tsResult = gulp.src(file.path)
            .pipe(tsProject());

        //gulp
        //    .src(tsResult.js)
        //    .pipe(gulp.dest(config.appDest))
        //    .pipe(refresh());

        tsResult.js.pipe(gulp.dest(config.appDest));
    });
});

gulp.task("default", ['minify', "dependencies"]);