import React, { Component } from "react";

class Modal extends Component {

    render() {
        return (
            <div className="modal fade" id={this.props.id} tabIndex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 className="modal-title" id="modalLabel">{this.props.title}</h4>
                        </div>
                        <div className="modal-body">{this.props.body}</div>
                        <div className="modal-footer">{this.props.footer}</div>
                    </div>
                </div>
            </div>
        );
    }
}

export default Modal;
