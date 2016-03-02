import alt from '../alt';
import LayoutActions from '../actions/LayoutActions';

class LayoutStore {
    constructor() {
        this.leftNavOpen = false;

        this.bindListeners({
            handleOpenLeftNav: LayoutActions.OPEN_LEFT_NAV,
            handleCloseLeftNav: LayoutActions.CLOSE_LEFT_NAV,
        });
    }

    handleOpenLeftNav() {
        this.leftNavOpen = true;
    }

    handleCloseLeftNav() {
        this.leftNavOpen = false;
    }

}

export default alt.createStore(LayoutStore, 'LayoutStore');