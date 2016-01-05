'use strict';

var gulp = require('gulp');
var config = require('./gulpconfig.js');
var plugins = require('gulp-load-plugins')();
var browserSync = require('browser-sync').create();
var del = require('del');
var fs = require('fs');
var data = require('./server/data/data.js');

gulp.task('serve', function() {

    browserSync.init({
        server: {
            baseDir: config.wwwroot
        }
    });

    //gulp.watch(config.wwwroot, ['task name']);
});

gulp.task('dataclean', function(){
    del.sync('./client/wwwroot/api');
});

gulp.task('data', ['dataclean'], function(callback){
    data.copyTo('./resources/dobih/DoBIH_v15.1.csv', './client/wwwroot/api/', callback);
});
