import {React, useEffect, useState} from "react";
import axios from "axios";
import Header from "../../Components/Header";
import Footer from "../../Components/Footer";
import {useNavigate} from "react-router-dom";
import "../../CSS/Reports.css"

const MediaReserveRecordsByBranchTable = () => {

    const generateTable = () => {

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
                    <th>UserId</th>
                    <th>Reservation Date</th>
                    <th>Date Reserved Until</th>
                    <th>Currently Reserved</th>
                </tr>
                </tbody>
            </table>
        </>
    )
}

export default MediaReserveRecordsByBranchTable