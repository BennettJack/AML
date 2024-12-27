import {React, useEffect, useState} from "react";
import axios from "axios";
import {useNavigate} from "react-router-dom";
import '../../CSS/StockControl.css'



const StockControlMediaCard = ({mediaItem}) => {
    let navigate = useNavigate()
    const stockControlMediaViewBaseUrl = "StockControlMediaView/"
    return (
        <div id={"mediaCardWrapper"} onClick={() => navigate((stockControlMediaViewBaseUrl + mediaItem.id))}>
            <img src={"https://localhost:7254/Images/FullImage/" + mediaItem.fullImageUrl}
                 alt={"image of " + mediaItem.title}/>
            <p id = {"stockControlMediaCardTitle"} > {mediaItem.title}</p>
        </div>
    )
}

export default StockControlMediaCard

