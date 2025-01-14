﻿import {React, useEffect, useState} from "react";
import "../../CSS/Reports.css"

const MediaStockRecordsByBranchTable = ({branchDetails, stockRecords}) => {


    const generateTableRows = () => {
        if(stockRecords.length > 0) {
            return (
                <>
                    {stockRecords.map(function (record) {
                        return (
                            <tr>
                                <td>{branchDetails.branchId}</td>
                                <td>{branchDetails.branchLocation}</td>
                                <td>{record.mediaModelFormatConnection.mediaModel.mediaModelId}</td>
                                <td>{record.mediaModelFormatConnection.mediaModel.title}</td>
                                <td>{record.mediaModelFormatConnection.format.formatName}</td>
                                <td>{record.stockCount}</td>
                                <td>{record.stockCount - record.reservedCount - record.borrowedCount}</td>
                                <td>{record.borrowedCount}</td>
                                <td>{record.reservedCount}</td>
                            </tr>
                        )
                    })}
                </>
            )
        }
        else{
            return (
                <tr>
                    <td colSpan={9}>No records for selected parameters </td>
                </tr>
            )
        }
    }
    
    return(
        <>
            <h2>Stock Records</h2>
            <table id={"stockTable"} className={"reportTable"}>
                <tbody>
                <tr>
                    <th>Branch ID</th>
                    <th>Branch Location</th>
                    <th>Media ID</th>
                    <th>Media Title</th>
                    <th>Media Format</th>
                    <th>Total Stock At This Branch</th>
                    <th>Available Stock</th>
                    <th>Borrow Count</th>
                    <th>Reserve Count</th>
                </tr>
                {generateTableRows()}
                </tbody>
            </table>
        </>
    )
}

export default MediaStockRecordsByBranchTable