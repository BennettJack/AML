import React from "react";
import Header from "../../Components/Header";
import Footer from "../../Components/Footer";
import NewBookSubmissionForm from "../../Components/NewMediaComponents/NewBookSubmissionForm";


const NewMediaSubmission = () => {
    return (
        <div>
            <Header />
            <h1>Add Media</h1>
            <NewBookSubmissionForm />
            <Footer />
        </div>
    )
}
export default NewMediaSubmission;