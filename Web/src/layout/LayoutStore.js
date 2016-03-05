'use strict';

import alt from '../alt';
import LayoutActions from './LayoutActions';

class LayoutStore {
    constructor() {
        this.leftNavOpen = false;
        this.searchOpen = false;

        this.bindListeners({
            handleOpenLeftNav: LayoutActions.OPEN_LEFT_NAV,
            handleCloseLeftNav: LayoutActions.CLOSE_LEFT_NAV,
            handleOpenSearch: LayoutActions.OPEN_SEARCH,
            handleCloseSearch: LayoutActions.CLOSE_SEARCH
        });
    }

    handleOpenLeftNav() {
        this.leftNavOpen = true;
    }

    handleCloseLeftNav() {
        this.leftNavOpen = false;
    }
    
    handleOpenSearch() {
        this.searchOpen = true;
    }

    handleCloseSearch() {
        this.searchOpen = false;
    }

}

export default alt.createStore(LayoutStore, 'LayoutStore');