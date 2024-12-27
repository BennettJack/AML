import {React, useEffect, useState} from "react";
import axios from "axios";
import {useParams} from "react-router-dom";

const StockControlMediaView = () => {
    let { id } = useParams();
    const [branches, setBranches] = useState([])
    useEffect(() => {
        axios.get("https://localhost:7095/InventoryService/api/Stock/GetMediaStockRecords?mediaId=1&branchId=1").then(res =>
            setBranches(res.data)).catch((e) => console.log(e))
    }, [])

    useEffect(() => {
        console.log(branches)
    }, [branches]);
    
return (
        <>
            <p>{id}</p>
        </>
    )
}

export default StockControlMediaView