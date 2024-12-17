import React, {useEffect, useState, useRef} from "react";
import Header from "../../Components/Header";
import Footer from "../../Components/Footer";
import NewBookSubmissionForm from "../../Components/NewMediaComponents/NewBookSubmissionForm";
import axios from "axios";


const NewMediaSubmission = () => {
    const [selectedMediaType, setSelectedMediaType] = useState("")
    const mediaTypes = useRef([
        "book",
        "motionPicture",
        "cdDvd",
        "journal",
        "periodical",
        "multiMediaGame"
    ])
    
    useEffect(() => {
        console.log(selectedMediaType)
    }, [selectedMediaType])
    
    const handleMediaTypeChange = (e) => {
        setSelectedMediaType(e.target.value)
    }
    return (
        <div>
            <Header />
            <h1>Add Media</h1>
            <div>
                <label>Media Type</label>
                <select
                    onChange={handleMediaTypeChange}
                >
                    <option 
                        value={""} 
                        selected={true}
                    >
                        Please select media type</option>
                    <option value={"book"}>Book</option>
                    <option value={"motionPicture"}>Motion Picture</option>
                </select>
            </div>
            <NewBookSubmissionForm />
            <Footer />
        </div>
    )
}
export default NewMediaSubmission;