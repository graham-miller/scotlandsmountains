/// <binding AfterBuild='build' Clean='clean' ProjectOpened='watch' />

"use strict";

var gulp = require("gulp");
var del = require("del");
var browserify = require("browserify");
var source = require("vinyl-source-stream")
var buffer = require("vinyl-buffer")
var sourcemaps = require("gulp-sourcemaps");
var uglify = require("gulp-uglify");
var rename = require("gulp-rename");
var concat = require("gulp-concat");
var minifyCss = require("gulp-minify-css");
var merge = require("gulp-merge");
var gulpif = require("gulp-if");

var paths = {
    webroot: "./wwwroot",
    npmroot: "./node_modules"
};
paths.clean = [paths.webroot + "/**/*", "!" + paths.webroot + "/bin{,/**/*}"];
paths.jsOutput = paths.webroot + "/js";
paths.cssOutput = paths.webroot + "/css";
paths.fontOutput = paths.webroot + "/fonts";
paths.imagesOutput = paths.webroot + "/images";
paths.copy = [
    {
        src: paths.npmroot + "/bootstrap/dist/js/bootstrap*",
        dest: paths.jsOutput
    },
    {
        src: paths.npmroot + "/jquery/dist/*",
        dest: paths.jsOutput
    },
    {
        src: paths.npmroot + "/finchjs/*.js",
        dest: paths.jsOutput
    },
    {
        src: paths.npmroot + "/leaflet/dist/leaflet-src.js",
        rename: "leaflet.js",
        dest: paths.jsOutput
    },
    {
        src: paths.npmroot + "/leaflet/dist/leaflet.js",
        rename: "leaflet.min.js",
        dest: paths.jsOutput
    },
    {
        src: paths.npmroot + "/leaflet.markercluster/dist/leaflet.markercluster-src.js",
        rename: "leaflet-markercluster.js",
        dest: paths.jsOutput
    },
    {
        src: paths.npmroot + "/leaflet.markercluster/dist/leaflet.markercluster.js",
        rename: "leaflet-markercluster.min.js",
        dest: paths.jsOutput
    },
    {
        src: paths.npmroot + "/bootstrap/dist/css/*",
        dest: paths.cssOutput
    },
    {
        src: paths.npmroot + "/leaflet/dist/images/**/*",
        dest: paths.cssOutput + "/images"
    },
    {
        src: paths.npmroot + "/bootstrap/dist/fonts/*",
        dest: paths.fontOutput
    },
    {
        src: ["./app/images/**/*", "!./app/images/favicons{,/**/*}"],
        dest: paths.imagesOutput
    },
    {
        src: "./app/images/favicons/*",
        dest: paths.webroot
    }
];

gulp.task("clean", function () {
    return del.sync(paths.clean);
});

gulp.task("build:app:js", function () {

    var b = browserify({
        entries: "./app/js/app.js",
        debug: true
    })

    return b.bundle()
        .pipe(source("app.js"))
        .pipe(buffer())
        .pipe(sourcemaps.init())
        .pipe(gulp.dest(paths.jsOutput))
        .pipe(uglify())
        .pipe(rename({ extname: ".min.js" }))
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest(paths.jsOutput));

});

gulp.task("build:app:css", function () {

    var css = gulp.src("./app/css/**/*.css")
        .pipe(concat("app.css"))
        .pipe(gulp.dest(paths.cssOutput))
        .pipe(sourcemaps.init())
        .pipe(minifyCss())
        .pipe(rename({ extname: ".min.css" }))
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest(paths.cssOutput));

    var images = gulp.src("./app/css/images/**/*")
        .pipe(gulp.dest(paths.webroot + "/css/images"));

    merge(css, images);
});

gulp.task("build:copy", function () {

    var subtasks = [];

    for (var i = 0; i < paths.copy.length; i++) {
        var toCopy = paths.copy[i];
        subtasks.push(
            gulp.src(toCopy.src)
                .pipe(gulpif(toCopy.rename !== undefined, rename(toCopy.rename)))
                .pipe(gulp.dest(toCopy.dest)));
    }

    subtasks.push(
        gulp.src(paths.npmroot + "/leaflet/dist/leaflet.css")
            .pipe(gulp.dest(paths.cssOutput))
            .pipe(sourcemaps.init())
            .pipe(minifyCss())
            .pipe(rename({ extname: ".min.css" }))
            .pipe(sourcemaps.write("."))
            .pipe(gulp.dest(paths.cssOutput))
    );

    merge.apply(subtasks);
});

gulp.task("build", [
    "clean",
    "build:app:js",
    "build:app:css",
    "build:copy",
]);

gulp.task("default", ["build"]);

gulp.task("watch", function () {
    gulp.watch("./app/**/*", ["build"]);
});