import React, { Component } from "react";
import { connect } from "react-redux";
import Snackbar from "material-ui/Snackbar";

class NotificationComponent extends Component {

    render() {

        if (this.props.networkError) {

            const message = (
                <span>
                    <strong>Uh oh!</strong>&emsp;Bad Stuff&trade; happened
                </span>
            );

            return (
                <Snackbar
                    open={true}
                    message={message}
                    autoHideDuration={2147483647}
                    action="Retry"
                    onActionTouchTap={() => location.reload(true)} />
            );
        }

        return null;
    }
}

const mapStateToProps = (state) => {

    if (
        (((state.staticData || {}).status || {}).error || false) ||
        (((state.mountain || {}).status || {}).error || false) ||
        (((state.search || {}).status || {}).error || false)) {
        return { networkError: true };
    } else {
        return { networkError: false };        
    }
};

const Notification = connect(mapStateToProps)(NotificationComponent);

export default Notification;
