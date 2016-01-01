var getOptionsFor = function (iconFileName) {
    return {
        iconUrl: "/css/images/" + iconFileName,
        iconSize: [20, 20],
        shadowSize: [50, 64],
        iconAnchor: [10, 10],
        shadowAnchor: [4, 62],
        popupAnchor: [0, -10]
    }
};

var munroIcon = L.icon(getOptionsFor("munro.png"));
var corbettIcon = L.icon(getOptionsFor("corbett.png"));
var grahamIcon = L.icon(getOptionsFor("graham.png"));
var otherIcon = L.icon(getOptionsFor("other.png"));

module.exports = function (code) {
    switch (code) {
        case "M":
            return munroIcon;
            break;
        case "C":
            return corbettIcon;
            break;
        case "G":
            return grahamIcon;
            break;
        default:
            return otherIcon;
            break;
    }
};
