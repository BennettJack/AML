import {React, useEffect, useState} from "react";
import axios from "axios";

const StockTransferForm = ({mediaStockRecords, mediaItem,targetBranchId,currentBranchId}) =>{
    const [targetBranchStockRecords, setTargetBranchStockRecords] = useState([])
    const stockTransferValues = []
    const handleSubmit = (e) => {
        e.preventDefault();

        const form = new FormData(e.target);
        for (let [key, value] of form.entries()) {
            if(value !== ""){
            stockTransferValues.push({
                mediaModelFormatConnectionId: key,
                stockToTransfer: value
            })}
        }
        let stockUpdateDto = {
            targetBranchId: targetBranchId,
            currentBranchId: currentBranchId,
            stockUpdates: stockTransferValues
        }
        axios.post("https://localhost:7095/InventoryService/api/Stock/TransferStock", stockUpdateDto).then(res => console.log(res)).catch((e) => console.log(e))
    };

    useEffect(() => {
        if(targetBranchId !== 0) {
            axios.get("https://localhost:7095/InventoryService/api/Stock/GetMediaStockRecords?mediaId=" + mediaItem.mediaModelId + "&branchId=" + targetBranchId).then(res =>
                setTargetBranchStockRecords(res.data)).catch((e) => console.log(e))
        }
    }, [targetBranchId]);
    
    const renderTargetBranch = () =>{
        if(targetBranchId === 0){
            return(
                <p> No target branch selected</p>
            )}
        else{
            return(
                <div>
                {targetBranchStockRecords.map(function (record) {
                        return (
                            <p
                                id={"transferFormFormatLabel"}>Format: {record.mediaModelFormatConnection.format.formatName}
                                <br/>
                                Current stock: {record.stockCount} <br/>
                                Current borrowed: {record.borrowedCount} <br/>
                                Current reserved: {record.reservedCount} <br/>
                                Current available: {record.stockCount} <br/>
                            </p>
                        )
                    })}
                </div>
            )
        }
    }
    return(
        <div id={"transferComponentWrapper"}>
            <form onSubmit={handleSubmit}>
                {mediaStockRecords.map(function (record) {
                    return (
                        <div>
                            <label
                                id={"transferFormFormatLabel"}>Format: {record.mediaModelFormatConnection.format.formatName}
                                <br/>
                                Current stock: {record.stockCount} <br/>
                                Current borrowed: {record.borrowedCount} <br/>
                                Current reserved: {record.reservedCount} <br/>
                                Current available: {record.stockCount} <br/>
                            </label>
                            <input
                                type={"number"}
                                max={record.stockCount}
                                min={0}
                                name={record.mediaModelFormatConnection.mediaModelFormatConnectionId}
                            />
                        </div>
                    )
                })}
                <button type={"submit"}>Submit</button>
            </form>
            {renderTargetBranch()}
            <div>
            </div>
        </div>
    )
}

export default StockTransferForm


/*
*/
