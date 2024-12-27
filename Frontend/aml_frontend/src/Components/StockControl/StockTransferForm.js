import {React, useEffect, useState} from "react";
import axios from "axios";

const StockTransferForm = ({mediaStockRecords}, {mediaItem}) =>{

    const stockTransferValues = []
    const handleSubmit = (e) => {
        e.preventDefault();

        const form = new FormData(e.target);
        for (let [key, value] of form.entries()) {
            stockTransferValues.push({
                formatId: key,
                stockToTransfer: value
            })
        }
        console.log(stockTransferValues)
    };
    
    return(
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
                            name={record.mediaModelFormatConnection.format.formatId}
                        />
                    </div>
                )
            })}
            <button type={"submit"}>Submit</button>
        </form>
    )
}

export default StockTransferForm