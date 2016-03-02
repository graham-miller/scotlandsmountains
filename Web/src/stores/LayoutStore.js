import alt from '../alt';
import LayoutActions from '../actions/LayoutActions';

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

export default alt.createStore(LayoutStore, 'LayoutStore');