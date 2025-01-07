import {React, useEffect, useState} from "react";
import "../../CSS/Reports.css"

const MediaBorrowRecordsByBranchTable = ({branchDetails, borrowRecords}) => {

    const generateDate = (date) =>{
        const dateObject = new Date(date)
        const day = dateObject.getDate()
        const month = dateObject.getMonth() +1
        const year = dateObject.getFullYear()
        return day+"/"+month+"/"+year
    }
    
    const currentlyBorrowingToString = (currentlyBorrowingBool) => {
        if(currentlyBorrowingBool){
            //Returning false because user is still borrowing
            return(
                <td id={"currentlyBorrowingTrue"}>False</td>
            )
        }
        else {
            //Returning true because user is no longer borrowing
            return(
            <td id={"currentlyBorrowingFalse"}>True</td>
            )
        }
    }
    const generateTableRows = () => {
        if(borrowRecords.length > 0) {
            return (
                <>
                    {borrowRecords.map(function (record) {
                        return (
                            <tr>
                                <td>{branchDetails.branchId}</td>
                                <td>{branchDetails.branchLocation}</td>
                                <td>{record.mediaModelFormatConnection.mediaModel.mediaModelId}</td>
                                <td>{record.mediaModelFormatConnection.mediaModel.title}</td>
                                <td>{record.mediaModelFormatConnection.format.formatName}</td>
                                <td>{record.userId}</td>
                                <td>{generateDate(record.borrowDate)}</td>
                                <td>{generateDate(record.returnDate)}</td>
                                {currentlyBorrowingToString(record.currentlyBorrowing)}
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
            <h2>Borrow Records</h2>
            <table id={"borrowTable"} className={"reportTable"}>
                <tbody>
                <tr>
                    <th>Branch ID</th>
                    <th>Branch Location</th>
                    <th>Media ID</th>
                    <th>Media Title</th>
                    <th>Media Format</th>
                    <th>UserId</th>
                    <th>Borrow Date</th>
                    <th>Return Date</th>
                    <th>Returned</th>
                </tr>
                {generateTableRows()}
                </tbody>
            </table>
        </>
    )
}

export default MediaBorrowRecordsByBranchTable