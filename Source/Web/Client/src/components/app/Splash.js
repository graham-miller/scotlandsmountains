import React, { Component } from "react";

import Logo from "../common/Logo";
import Loading from "../common/Loading";

class Splash extends Component {

    render() {
        return (
            <div style={{display:"table",position:"absolute",height:"100%",width:"100%",backgroundColor:"#909740"}}>
                <div style={{display:"table-cell",verticalAlign:"middle"}}>
                    <div style={{width:"100%",color:"#ffffff",textAlign:"center"}}>
                        <h1 style={{ margin: 0 }}>Scotland&apos;s <Logo size="24px" color="#ffffff" />ountains</h1>
                        <Loading />
                    </div>
                </div>
            </div>
        );
    }
}

export default Splash;
