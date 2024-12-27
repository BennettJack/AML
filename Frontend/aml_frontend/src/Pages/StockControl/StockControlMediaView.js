import {React, useEffect, useState} from "react";
import axios from "axios";
import {useParams} from "react-router-dom";
import StockTransferForm from "../../Components/StockControl/StockTransferForm";
import MediaView from "../../Components/StockControl/MediaView";

const StockControlMediaView = () => {
    let { id } = useParams();
    const [mediaStockRecords, setMediaStockRecords] = useState([])
    const [mediaItem, setMediaItem] = useState([])
    useEffect(() => {
        axios.get("https://localhost:7095/InventoryService/api/Stock/GetMediaStockRecords?mediaId="+id+"&branchId=1").then(res =>
            setMediaStockRecords(res.data)).catch((e) => console.log(e))

        axios.get("https://localhost:7095/InventoryService/api/MediaModel/GetMediaById?mediaId="+id).then(res =>
            setMediaItem(res.data)).catch((e) => console.log(e))
    }, [])

    useEffect(() => {
        console.log(mediaStockRecords)
        console.log(mediaItem)
    }, [mediaItem]);
    
return (
        <>
            <div id={"StockControlMediaViewWrapper"}>
                <div>
                    <MediaView mediaItem={mediaItem}/>
                </div>
                <div id={"stockTransferFormWrapper"}>
                    <StockTransferForm mediaStockRecords={mediaStockRecords} mediaItem={mediaItem}/>
                </div>
            </div>
        </>
    )
}

export default StockControlMediaView