import {React, useEffect, useState} from "react";
import axios from "axios";
import Header from "../../Components/Header";
import Footer from "../../Components/Footer";
import {useNavigate} from "react-router-dom";
import "../../CSS/Reports.css"

const MediaStockRecordsByBranchTable = ({branchDetails, stockRecords}) => {


    const generateTableRows = () => {
        return(
            <>
                {stockRecords.map(function(record){
                return(
                    <tr>
                        <th>{branchDetails.branchId}</th>
                        <th>{branchDetails.branchLocation}</th>
                        <th>{record.mediaModelFormatConnection.mediaModel.mediaModelId}</th>
                        <th>{record.mediaModelFormatConnection.mediaModel.title}</th>
                        <th>{record.mediaModelFormatConnection.format.formatName}</th>
                        <th>{record.stockCount}</th>
                        <th>{record.stockCount - record.reservedCount - record.borrowedCount}</th>
                        <th>{record.borrowedCount}</th>
                        <th>{record.reservedCount}</th>
                    </tr>
                )
                })}
            </>

        )
    }
    
    
    return(
        <>
        <table>
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