﻿import {React, useEffect, useState} from "react";
import axios from "axios";
import StockControlMediaCard from "../../Components/StockControl/StockControlMediaCard";

const StockControlMainPage = () => {
    const [mediaList, setMediaList] = useState([])

    useEffect(() =>{
        axios.get("https://localhost:7095/InventoryService/api/MediaModel/GetAllMediaItems").then(res => 
            setMediaList(res.data)).catch((e) => console.log(e))  
    },[])

    useEffect(() => {
        console.log(mediaList)
    }, [mediaList]);


    return (
        <>
            <div id={"MediaGrid"}>
                {mediaList.map(function(mediaItem) {
                  return(
                    <StockControlMediaCard mediaItem={mediaItem} />
                  )  
                })}
            </div>
        </>
    )
}


export default StockControlMainPage

