import alt from '../alt';
import AccountActions from './AccountActions';

class AccountStore {
    constructor() {

        this.bindListeners({
            handleSignIn: AccountActions.SIGN_IN
        });
    }

    handleSignIn() {
        alert("Not available in beta.");
    }

}

export default alt.createStore(AccountStore, 'AccountStore');