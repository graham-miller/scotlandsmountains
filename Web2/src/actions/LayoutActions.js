var alt = require('../alt');

class LayoutActions {
    toggleLeftNav() {
        return true;
     }
}

module.exports = alt.createActions(LayoutActions);