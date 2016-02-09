var alt = require('../alt');
var LayoutActions = require('../actions/LayoutActions');

class LayoutStore {
    constructor() {
        this.leftNavOpen = false;

        this.bindListeners({
            handleToggleLeftNav: LayoutActions.TOGGLE_LEFT_NAV
        });
    }

    handleToggleLeftNav() {
        this.leftNavOpen = !this.leftNavOpen;
    }
}

module.exports = alt.createStore(LayoutStore, 'LayoutStore');