import {React, useEffect, useState} from "react";
import axios from "axios";
import "../../CSS/Reports.css"
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import MediaStockRecordsByBranchTable from "../../Components/Reports/MediaStockRecordsByBranchTable";
import MediaBorrowRecordsByBranchTable from "../../Components/Reports/MediaBorrowRecordsByBranchTable";
import MediaReserveRecordsByBranchTable from "../../Components/Reports/MediaReserveRecordsByBranchTable";
import Header from "../../Components/Header";
import Footer from "../../Components/Footer";

const MediaReports = () => {
    const [stockRecords, setStockRecords] = useState([])
    const currentBranchId = 1
    const [currentBranch, setCurrentBranch] = useState({})
    const [selectedMediaItem, setSelectedMediaItem] = useState("all" )  
    const [startDate, setStartDate] = useState(new Date(new Date(new Date().setMonth(new Date().getMonth() -1))))
    const [endDate, setEndDate] = useState(new Date())
    const [reserveRecords, setReserveRecords] = useState([])
    const [borrowRecords, setBorrowRecords] = useState([])
    const [mediaItems, setMediaItems] = useState([])

    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetBranchById?&branchId="+currentBranchId).then(res =>
            setCurrentBranch(res.data)).catch((e) => console.log(e))

        axios.get("https://localhost:7095/InventoryService/api/Stock/GetAllMediaStockRecordsByBranch?&branchId="+currentBranchId).then(res =>
            setStockRecords(res.data)).catch((e) => console.log(e))

        axios.get("https://localhost:7095/InventoryService/api/MediaModel/GetAllMediaItems").then(res =>
            setMediaItems(res.data)).catch((e) => console.log(e))
        
        axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchReserveRecordsByDate?&branchId="+currentBranchId+
            "&startDate="+startDate.toJSON()+"&endDate="+endDate.toJSON()).then(res =>
            setReserveRecords(res.data)).catch((e) => console.log(e))

        axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchBorrowRecordsByDate?&branchId="+currentBranchId+
            "&startDate="+startDate.toJSON()+"&endDate="+endDate.toJSON()).then(res =>
            setBorrowRecords(res.data)).catch((e) => console.log(e))
    }, []);

    useEffect(() => {
        if(selectedMediaItem === "all") {
            axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchReserveRecordsByDate?&branchId=" + currentBranchId +
                "&startDate=" + startDate.toJSON() + "&endDate=" + endDate.toJSON()).then(res =>
                setReserveRecords(res.data)).catch((e) => console.log(e))

            axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchBorrowRecordsByDate?&branchId=" + currentBranchId +
                "&startDate=" + startDate.toJSON() + "&endDate=" + endDate.toJSON()).then(res =>
                setBorrowRecords(res.data)).catch((e) => console.log(e))
        }
        else{
            axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchReserveRecordsByMedia?&mediaId="+selectedMediaItem+"&branchId="+currentBranchId+
                "&startDate="+startDate.toJSON()+"&endDate="+endDate.toJSON()).then(res =>
                setReserveRecords(res.data)).catch((e) => console.log(e))

            axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchBorrowRecordsByMedia?&mediaId="+selectedMediaItem+"&branchId="+currentBranchId+
                "&startDate="+startDate.toJSON()+"&endDate="+endDate.toJSON()).then(res =>
                setBorrowRecords(res.data)).catch((e) => console.log(e))
        }
    }, [startDate]);

    useEffect(() => {
        if(selectedMediaItem === "all"){
            axios.get("https://localhost:7095/InventoryService/api/Stock/GetAllMediaStockRecordsByBranch?&branchId="+currentBranchId).then(res =>
                setStockRecords(res.data)).catch((e) => console.log(e))
            
            axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchReserveRecordsByDate?&branchId=" + currentBranchId +
                "&startDate=" + startDate.toJSON() + "&endDate=" + endDate.toJSON()).then(res =>
                setReserveRecords(res.data)).catch((e) => console.log(e))

            axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchBorrowRecordsByDate?&branchId=" + currentBranchId +
                "&startDate=" + startDate.toJSON() + "&endDate=" + endDate.toJSON()).then(res =>
                setBorrowRecords(res.data)).catch((e) => console.log(e))
            
        }
        else{
            axios.get("https://localhost:7095/InventoryService/api/Stock/GetMediaStockRecordsByBranch?&mediaId="+selectedMediaItem+"&branchId="+currentBranchId).then(res =>
                setStockRecords(res.data)).catch((e) => console.log(e))

            axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchReserveRecordsByMedia?&mediaId="+selectedMediaItem+"&branchId="+currentBranchId+
                "&startDate="+startDate.toJSON()+"&endDate="+endDate.toJSON()).then(res =>
                setReserveRecords(res.data)).catch((e) => console.log(e))

            axios.get("https://localhost:7095/InventoryService/api/Stock/GetBranchBorrowRecordsByMedia?&mediaId="+selectedMediaItem+"&branchId="+currentBranchId+
                "&startDate="+startDate.toJSON()+"&endDate="+endDate.toJSON()).then(res =>
                setBorrowRecords(res.data)).catch((e) => console.log(e))
        }

    }, [selectedMediaItem]);
    
    const handleChange = (e) =>{
        if(e.target.name === "mediaSelect"){
            setSelectedMediaItem(e.target.value)
        }
    }
    
    const renderTables = () =>{
        return(
            <>
                <div className={"reportTableContainer"}>
                    <MediaStockRecordsByBranchTable branchDetails={currentBranch} stockRecords={stockRecords}/>
                    <button tabIndex={4} onClick={(e)=> 
                        handleDownload("Stock Records")}>Download as CSV</button>
                </div>
                <div className={"reportTableContainer"}>
                    <MediaBorrowRecordsByBranchTable branchDetails={currentBranch} borrowRecords={borrowRecords}/>
                    <button tabIndex={5} onClick={(e)=> 
                        handleDownload("Borrow Records")} >Download as CSV</button>
                </div>
                <div className={"reportTableContainer"}>
                    <MediaReserveRecordsByBranchTable branchDetails={currentBranch} reserveRecords={reserveRecords}/>
                    <button tabIndex={6} onClick={(e)=> 
                        handleDownload("Reserve Records")}>Download as CSV</button>
                </div>
            </>
        )
    }
    
    //Reference: Siva Kondapi Venkata, https://stackoverflow.com/questions/66078335/how-do-i-save-a-file-on-my-desktop-using-reactjs
    const downloadFile = async (blob, tableType) => {
        const a = document.createElement('a');
        a.download = tableType + ".xlsx";
        a.href = URL.createObjectURL(blob);
        a.addEventListener('click', (e) => {
            setTimeout(() => URL.revokeObjectURL(a.href), 30 * 1000);
        });
        a.click();
    };
    
    const handlePost = async (tableType, htmlContent) => {
        axios.post("https://localhost:7168/api/Reports/ConvertTableToExcel", {
            htmlContent: JSON.stringify(htmlContent).replace(/\\\\,/g, '\\,')
        }, {
            headers: {
                "Content-Type": "application/json",
            },
            responseType: "arraybuffer"
        }).then(res => {
            const blob = new Blob([res.data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            })

            downloadFile(blob, tableType)
        })
            .catch(error => {
                console.log(error.message);
            });
    }
    
    const handleDownload = async (tableType) =>{
        switch (tableType){
            case "Reserve Records":
                let reserveContent = document.getElementById("reserveTable").outerHTML
                await handlePost(tableType, reserveContent)
                break;
            case "Borrow Records":
                let borrowContent = document.getElementById("borrowTable").outerHTML
                await handlePost(tableType, borrowContent)
                break;
            case "Stock Records":
                let stockContent = document.getElementById("stockTable").outerHTML
                await handlePost(tableType, stockContent)
                break;
        }
    }
    
    const renderForm = () =>{
        return(
            <>
                <Header/>
                <h1 id={"mediaReportsHeader"}>Media Reports</h1>
                <div id={"reportInputsContainer"}>
                    <DatePicker
                        selected={startDate} onChange={(date) => setStartDate(date)}
                        dateFormat="dd/MM/yyyy"
                        tabIndex={1}
                    />
                    <DatePicker
                        selected={endDate} onChange={(date) => setEndDate(date)}
                        dateFormat="dd/MM/yyyy"
                        tabIndex={2}
                    />
                    <form>
                        <select
                            onChange={handleChange}
                            name={"mediaSelect"}
                            id={"mediaSelect"}
                            tabIndex={3}
                        >
                            <option selected={true} value={"all"}>All media</option>
                            {mediaItems.map(function (mediaItem) {
                                return (
                                    <option value={mediaItem.mediaModelId}>{mediaItem.title}</option>
                                )
                            })}
                        </select>
                    </form>
                </div>
                {renderTables()}
                
                <Footer/>
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