import {React, useEffect, useState} from "react";
import axios from "axios";
import Header from "../../Components/Header";
import Footer from "../../Components/Footer";
import {useNavigate} from "react-router-dom";
import "../../CSS/Reports.css"

const MediaReserveRecordsByBranchTable = ({branchDetails, reserveRecords}) => {

    const generateDate = (date) =>{
        const dateObject = new Date(date)
        const day = dateObject.getDate()
        const month = dateObject.getMonth() +1
        const year = dateObject.getFullYear()
        return day+"/"+month+"/"+year
    }

    const currentlyBorrowingToString = (currentlyReservedBool) => {
        if(currentlyReservedBool){
            return(
                <td id={"currentlyBorrowingTrue"}>True</td>
            )
        }
        else {
            return(
                <td id={"currentlyBorrowingFalse"}>False</td>
            )
        }
    }
    const generateTableRows = () => {
        if(reserveRecords.length > 0) {
            return (
                <>
                    {reserveRecords.map(function (record) {
                        return (
                            <tr>
                                <td>{branchDetails.branchId}</td>
                                <td>{branchDetails.branchLocation}</td>
                                <td>{record.mediaModelFormatConnection.mediaModel.mediaModelId}</td>
                                <td>{record.mediaModelFormatConnection.mediaModel.title}</td>
                                <td>{record.mediaModelFormatConnection.format.formatName}</td>
                                <td>{record.userId}</td>
                                <td>{generateDate(record.reservationDate)}</td>
                                <td>{generateDate(record.dateReservedFor)}</td>
                                {currentlyBorrowingToString(record.reservationActive)}
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

    return (
        <>
            <h2>Reserve Records</h2>
            <table id={"reserveTable"} className={"reportTable"}>
                <thead>
                <tr>
                    <th>Branch ID</th>
                    <th>Branch Location</th>
                    <th>Media ID</th>
                    <th>Media Title</th>
                    <th>Media Format</th>
                    <th>UserId</th>
                    <th>Reservation Placed Date</th>
                    <th>Date Reserved For</th>
                    <th>Currently Reserved</th>
                </tr>
                </thead>
                <tbody>
                {generateTableRows()}
                </tbody>
            </table>
        </>
    )
}

export default MediaReserveRecordsByBranchTable