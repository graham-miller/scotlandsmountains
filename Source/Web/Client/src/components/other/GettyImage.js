import React, { Component } from "react";

class GettyImage extends Component {

    render() {
        return (
            <div style={{textAlign:"center",marginTop:"20px"}}>
                <div
                    className="getty embed image"
                    style={{backgroundColor:"#f8fbfd",display:"inline-block",color:"#a7a7a7",fontSize:"11px",width:"100%",maxWidth:"615px"}}>
                    <div style={{padding:0,margin:0,textAlign:"left"}}>
                        <a
                            href="http://www.gettyimages.com/detail/573624773"
                            target="_blank"
                            style={{color:"#a7a7a7",textDecoration:"none",fontWeight:"normal !important",border:"none",display:"inline-block"}}>
                            Embed from Getty Images
                        </a>
                    </div>
                    <div
                        style={{overflow:"hidden",position:"relative",height:0,padding:"45.691057% 0 0 0",width:"100%"}}>
                        <iframe
                            src="//embed.gettyimages.com/embed/573624773?et=v5ggI1IpQgJaELdNWCoXQg&viewMoreLink=off&sig=om8vYfcrYrsqtUEkYWSgRXOTKESCcCjbR8kkGIp5ihg=&caption=true"
                            width="615" height="281" scrolling="no" frameBorder="0"
                            style={{display:"inline-block",position:"absolute",top:0,left:0,width:"100%",height:"100%",margin:0}} />
                    </div>
                    <p style={{margin:0}}></p>
                </div>
            </div>
        );
    }
}

export default GettyImage;
