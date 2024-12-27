import {React, useEffect, useState} from "react";
import axios from "axios";
import {useParams} from "react-router-dom";

const StockControlMediaView = () => {
    let { id } = useParams();
    const [branches, setBranches] = useState([])
    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetAllBranches").then(res =>
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