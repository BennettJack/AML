import {React, useEffect, useState} from "react";
import axios from "axios";
import '../../CSS/StockControl.css'

const StockControlMediaCard = ({mediaItem}) => {
    const stockControlMediaViewBaseUrl = "http://localhost:3000/StockControlMediaView/"
    const imageFolder = "Images/MediaImages/FullImage/"
    return (
        <div id={"MediaCardWrapper"}>
            <img src={"https://localhost:7254/Images/FullImage/"+mediaItem.fullImageUrl} alt={"image of " + mediaItem.title}/>
            <a id={"stockControlMediaCardLink"} href={stockControlMediaViewBaseUrl + mediaItem.id}>{mediaItem.title}</a>
        </div>
    )
}

export default StockControlMediaCard