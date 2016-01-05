var
    fs = require('fs'),
    parse = require('csv-parse'),
    transform = require('stream-transform'),
    mkdirp = require('mkdirp'),
    iconv = require('iconv-lite'),
    sortBy = require('sort-by'),
    columns = require('./columns.js');

module.exports = {

    copyTo: function (src, dest, callback) {

        mkdirp(dest);

        var decode = function (content) {
            return iconv.decode(content, 'win1251');
        };

        var getClassification = function(record) {
            if(record[columns.munro] === '1') { return 'M'; }
            if(record[columns.corbett] === '1') { return 'C'; }
            if(record[columns.graham] === '1') { return 'G'; }
            return '';
        };

        var createMountain = function (record) {
            return {
                name: record[columns.name],
                height: Math.floor(parseFloat(record[columns.metres])),
                latitude: parseFloat(record[columns.latitude]),
                longitude: parseFloat(record[columns.longitude]),
                classification: getClassification(record)
            };
        };

        var filter = function (record) {
            var country = record[columns.country];
            var height = Math.floor(parseFloat(record[columns.metres]));
            var unclassified = record[columns.unclassified];
            var oldGR = record[columns.name].match(/old GR/i);
            return (country === 'S' || country === 'ES') && height >= 500 && unclassified !== "1" && !oldGR;
        };

        var transform = function (records, filter) {
            var results = [];
            records.forEach(function (record) {
                if(filter(record)) { results.push(createMountain(record)); }
            });
            return results;
        };

        var assignIds = function(records){
            var id = 1;
            records.forEach(function (record) {
                record.id = id++;
            });
        };

        var formatIndex = function(mountains) {
            var index = [];
            
            mountains.forEach(function(m) {
               index.push([m.id, m.name.replace(/\s*\[.*?\]\s*/g, ''), m.latitude, m.longitude, m.height, m.classification]);
            });
            
            return JSON.stringify(index);  
        };

        var generateMountainList = function (records) {
            var mountains = transform(records, filter);
            mountains.sort(sortBy('-height'));
            assignIds(mountains);
            return mountains;
        };

        var processData = function (err, content) {
            var data = decode(content);
            parse(data, { delimiter: ',', trim: true }, function (err, records) {
                var mountains = generateMountainList(records);
                fs.writeFile(dest + 'index.json', formatIndex(mountains), function() { callback(); });
            });
        };

        fs.readFile(src, processData);
    }
};
