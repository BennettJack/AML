import {React, useEffect, useState} from "react";
import axios from "axios";
import "../../CSS/Reports.css"
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import MediaStockRecordsByBranchTable from "../../Components/Reports/MediaStockRecordsByBranchTable";
import MediaBorrowRecordsByBranchTable from "../../Components/Reports/MediaBorrowRecordsByBranchTable";
import MediaReserveRecordsByBranchTable from "../../Components/Reports/MediaReserveRecordsByBranchTable";

const MediaReports = () => {
    const [stockRecords, setStockRecords] = useState([])
    const currentBranchId = 1
    const [currentBranch, setCurrentBranch] = useState({})
    const [selectedMediaItem, setSelectedMediaItem] = useState(null )  
    const [startDate, setStartDate] = useState(new Date(new Date(new Date().setMonth(new Date().getMonth() -1))))
    const [endDate, setEndDate] = useState(new Date())
    const [reserveRecords, setReserveRecords] = useState([])
    const [borrowRecords, setBorrowRecords] = useState([])

    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetBranchById?&branchId="+currentBranchId).then(res =>
            setCurrentBranch(res.data)).catch((e) => console.log(e))

        axios.get("https://localhost:7095/InventoryService/api/Stock/GetAllMediaStockRecordsByBranch?&branchId="+currentBranchId).then(res =>
            setStockRecords(res.data)).catch((e) => console.log(e))
        
        console.log(stockRecords)
    }, []);

    useEffect(() => {
        axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchReserveRecordsByDate?&branchId="+currentBranchId+
        "&startDate="+startDate.toJSON()+"&endDate="+endDate.toJSON()).then(res =>
            setReserveRecords(res.data)).catch((e) => console.log(e))

        axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchBorrowRecordsByDate?&branchId="+currentBranchId+
            "&startDate="+startDate.toJSON()+"&endDate="+endDate.toJSON()).then(res =>
            setBorrowRecords(res.data)).catch((e) => console.log(e))
        
        console.log("reserve records:")
        console.log(reserveRecords)
        console.log("borrow records")
        console.log(borrowRecords)
    }, [startDate]);
    
    const handleChange = (e) =>{
        console.log(e.target.value)
        
    }
    
    const renderTables = () =>{
        return(
            <>
                <MediaStockRecordsByBranchTable branchDetails={currentBranch} stockRecords={stockRecords}/>
                <MediaBorrowRecordsByBranchTable/>
                <MediaReserveRecordsByBranchTable />
            </>
        )
    }
    const renderForm = () =>{
        return(
            <>
                <DatePicker
                    selected={startDate} onChange={(date) => setStartDate(date)}
                    dateFormat="yyyy/MM/dd"
                />
                <DatePicker
                    selected={endDate} onChange={(date) => setEndDate(date)}
                    dateFormat="yyyy/MM/dd"
                />
                <form>
                    <select
                        onChange={handleChange}
                        name={"mediaSelect"}
                    >
                        <option value={""}>Please Select</option>
                        <option value={"all"}>All media</option>
                        {stockRecords.map(function (record) {
                            return (
                                <option value={""}>{record.mediaModelFormatConnection.mediaModel.title}</option>
                            )
                        })}
                    </select>
                </form>
                {renderTables()}
                </>
    )
    }
    return(
        <>
            {renderForm()}
        </>
    )
    }

    export default MediaReports