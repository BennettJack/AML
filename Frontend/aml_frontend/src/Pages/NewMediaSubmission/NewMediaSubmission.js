import React, {useEffect, useState, useRef} from "react";
import Header from "../../Components/Header";
import Footer from "../../Components/Footer";
import NewBookSubmissionForm from "../../Components/NewMediaComponents/NewBookSubmissionForm";
import axios from "axios";


const NewMediaSubmission = () => {
    const [selectedMediaType, setSelectedMediaType] = useState("")
    const [mediaTypes, setMediaTypes] = useState([
        "book",
        "motionPicture",
        "cdDvd",
        "journal",
        "periodical",
        "multiMediaGame"
    ])
    
    useEffect(() => {
        //console.log(selectedMediaType)
    }, [selectedMediaType])
    
    const handleMediaTypeChange = (e) => {
        setSelectedMediaType(e.target.value)
    }
    
    const renderForm = () => {
        console.log("test")
        switch (selectedMediaType) {
            case "book":
                return (
                    <NewBookSubmissionForm />
                )
            case "motionPicture":
                return(
                    <p>Motion Picture</p>
                )
            case "cdDvd":
                return(
                    <p>Cd Dvd</p>
                )
            case "journal":
                return(
                    <p>Journal</p>
                )
            case "periodical":
                return (
                    <p>Periodical</p>
                )
            case "multiMediaGame":
                return (
                    <p>Multimedia game</p>
                )
            default:
                return (
                    <p>Please select a media type</p>
                )
        }
    }
    
    return (
        <div>
            <Header />
            <h1>Add Media</h1>
            <div>
                <label>Media Type</label>
                <select onChange={handleMediaTypeChange}>
                    <option value={""} selected={true}>
                        Please select media type</option>
                    {mediaTypes.map(function(mediaType){
                        return(
                            <option value={mediaType}>{mediaType}</option>
                        )
                    })}
                </select>
            </div>
            {renderForm()}
            
            <Footer />
        </div>
    )
}
export default NewMediaSubmission;