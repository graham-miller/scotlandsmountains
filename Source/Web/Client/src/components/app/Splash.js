import React, { Component } from "react";
import Logo from "../other/Logo";
import Loading from "../other/Loading";

class Splash extends Component {

    render() {
        return (
            <div style={{display:"table",position:"absolute",height:"100%",width:"100%",backgroundColor:"#ffffff"}}>
                <div style={{display:"table-cell",verticalAlign:"middle"}}>
                    <div style={{width:"100%",textAlign:"center"}}>
                        <h1 style={{margin:0,color:"#909740"}}>Scotland&apos;s <Logo size="24px" color="#909740" />ountains</h1>
                        <Loading textStyle={{color:"#909740"}}/>
                    </div>
                </div>
            </div>
        );
    }
}

export default Splash;
