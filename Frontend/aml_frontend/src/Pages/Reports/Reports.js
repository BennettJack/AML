import {React, useEffect, useState} from "react";
import axios from "axios";
import Header from "../../Components/Header";
import Footer from "../../Components/Footer";
import {useNavigate} from "react-router-dom";
import "../../CSS/Reports.css"

const Reports = () => {
    const currentBranchId = 1
    const [currentBranch, setCurrentBranch] = useState({})
    const MediaReportsBaseUrl = "Reports/MediaReports"
    let navigate = useNavigate()

    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetBranchById?&branchId="+currentBranchId).then(res =>
            setCurrentBranch(res.data)).catch((e) => console.log(e))
    }, []);

    useEffect(() => {
        console.log(currentBranch)
    }, [currentBranch]);
    return(
        <>
            <Header/>
            <h1>Available reports for {currentBranch.branchLocation} branch</h1>
            <div id={"reportLinksWrapper"}>
                <a href={MediaReportsBaseUrl}>Media usage reports</a>
                <a href={"#"}>Member activity reports</a>
            </div>
            <Footer/>
        </>
    )
}

export default Reports