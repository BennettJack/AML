import {React, useEffect, useState} from "react";
import axios from "axios";
import {useParams} from "react-router-dom";
import StockTransferForm from "../../Components/StockControl/StockTransferForm";
import MediaView from "../../Components/StockControl/MediaView";
import Footer from "../../Components/Footer";
import Header from "../../Components/Header";

const StockControlMediaView = () => {
    let { id } = useParams();
    const currentBranchId = 1
    const [mediaStockRecords, setMediaStockRecords] = useState([])
    const [mediaItem, setMediaItem] = useState([])
    const [targetBranchId, setTargetBranchId] = useState(0)
    const [branches, setBranches] = useState([])
    
    useEffect(() => {
        axios.get("https://localhost:7095/InventoryService/api/Stock/GetMediaStockRecords?mediaId="+id+"&branchId="+currentBranchId).then(res =>
            setMediaStockRecords(res.data)).catch((e) => console.log(e))

        axios.get("https://localhost:7095/InventoryService/api/MediaModel/GetMediaById?mediaId="+id).then(res =>
            setMediaItem(res.data)).catch((e) => console.log(e))
        
        axios.get("https://localhost:7095/BranchService/api/Branch/GetAllBranches").then(res =>
            setBranches(res.data)).catch((e) => console.log(e));
    }, [])
    
    const handleChange = (e) =>{
        if(e.target.name === "branchSelect") {
            setTargetBranchId(e.target.value)
        }
    }
    
    return (
            <>
                <Header/>
                <div id={"StockControlMediaViewWrapper"}>
                    <div id={"mediaViewContainer"}>
                        <MediaView mediaItem={mediaItem}/>
                    </div>
                    <div id={"stockTransferFormWrapper"}>
                        <h3>Select branch to transfer to</h3>
                        <form id={"selectBranchTransferForm"}>
                            <select
                                onChange={handleChange}
                                name={"branchSelect"}
                            >
                                <option value={0}>Please select branch</option>
                                {branches.map(function (branch) {
                                    if (branch.branchId !== currentBranchId)
                                        return (
                                            <option value={branch.branchId}> {branch.branchLocation}</option>
                                        )
                                })}
                            </select>
                        </form>
                        <StockTransferForm mediaStockRecords={mediaStockRecords} mediaItem={mediaItem}
                                           targetBranchId={targetBranchId} currentBranchId={currentBranchId}/>
                    </div>
                </div>
                <Footer/>
            </>
    )
}

export default StockControlMediaView