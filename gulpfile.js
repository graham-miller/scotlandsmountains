'use strict';

var gulp = require('gulp'),
    plugins = require('gulp-load-plugins')(),
    del = require('del'),
    config = require('./gulpconfig.js'),
    browserSync = require('browser-sync').create(),
    data = require('./src/data/data.js');

gulp.task('clean', function(){
    del.sync(config.destAll);
});

gulp.task('html', function(){
    return gulp
        .src(config.srcHtml)
        .pipe(plugins.plumber({errorHandler: plugins.notify.onError("Error: <%= error.message %>")}))
        .pipe(gulp.dest(config.dest))
        .pipe(browserSync.stream());
});

gulp.task('js', function(){
    return gulp
        .src(config.srcJs)
        .pipe(plugins.plumber({errorHandler: plugins.notify.onError("Error: <%= error.message %>")}))
        .pipe(plugins.sourcemaps.init())
            .pipe(plugins.concat(config.jsFileName))
            .pipe(plugins.ngAnnotate())
            .pipe(plugins.uglify())
        .pipe(plugins.sourcemaps.write())        
        .pipe(gulp.dest(config.destJs))        
        .pipe(browserSync.stream());
});

gulp.task('sass', function(){
    return gulp
        .src(config.srcSass)
        .pipe(plugins.plumber({errorHandler: plugins.notify.onError("Error: <%= error.message %>")}))
        .pipe(plugins.sourcemaps.init())
            .pipe(plugins.concat(config.cssFileName))
            .pipe(plugins.sass(config.sassOptions))
        .pipe(plugins.sourcemaps.write())
        .pipe(plugins.autoprefixer(config.autoprefixerOptions))
        .pipe(gulp.dest(config.destCss))
        .pipe(browserSync.stream());
});

gulp.task('img', function(){
    return gulp
        .src(config.srcImg)
        .pipe(gulp.dest(config.destImg));
});

gulp.task('css', function(){
    return gulp
        .src(config.srcCss)
        .pipe(gulp.dest(config.destCss));
});

gulp.task('fav', function(){
    return gulp
        .src(config.srcFav)
        .pipe(gulp.dest(config.destFav));
});

gulp.task('libjs', function(){
    return gulp
        .src(config.libJs)
        .pipe(gulp.dest(config.destJs));
});

gulp.task('libcss', function(){
    return gulp
        .src(config.libCss)
        .pipe(gulp.dest(config.destCss));
});

gulp.task('libcssimg', function(){
    return gulp
        .src(config.libCssImg)
        .pipe(gulp.dest(config.destCssImg));
});

gulp.task('libfonts', function(){
    return gulp
        .src(config.libFonts)
        .pipe(gulp.dest(config.destFonts));
});

gulp.task('serve', ['build'], function() {

    browserSync.init({
        server: {
            baseDir: config.dest
        }
    });

    gulp.watch(config.srcHtml, ['html']);
    gulp.watch(config.srcJs, ['js']);
    gulp.watch(config.srcSass, ['sass']);
    gulp.watch(config.destAll).on('change', browserSync.reload);
});

gulp.task('dataclean', function(){
    del.sync(config.destData);
});

gulp.task('data', ['dataclean'], function(callback){
    data.copyTo(config.srcData, config.destData, callback);
});

gulp.task('build', ['clean', 'html', 'js', 'sass', 'img', 'css', 'fav', 'libjs', 'libcss', 'libcssimg', 'libfonts']);
gulp.task('default', ['serve']);
