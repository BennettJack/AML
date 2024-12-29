import {React, useEffect, useState} from "react";
import axios from "axios";
import "../../CSS/Reports.css"

const MediaReports = () => {
    const [mediaItems, setMediaItems] = useState([])
    const currentBranchId = 1
    const [currentBranch, setCurrentBranch] = useState({})
    const [selectedMediaItem, setSelectedMediaItem] = useState(null )  

    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetBranchById?&branchId="+currentBranchId).then(res =>
            setCurrentBranch(res.data)).catch((e) => console.log(e))

        axios.get("https://localhost:7095/InventoryService/api/Stock/GetAllMediaStockRecordsByBranch?&branchId="+currentBranchId).then(res =>
            setMediaItems(res.data)).catch((e) => console.log(e))
    }, []);

    useEffect(() => {
        console.log(currentBranch)
        console.log(mediaItems)
    }, [mediaItems]);
    
    const handleChange = (e) =>{
        
    }
    
    const renderForm = () =>{
        
    }
    return(
        <>
            <form>
                
            </form>
        </>
    )
}

export default MediaReports