import {React, useEffect, useState} from "react";
import '../CSS/LibraryList.css';
import axios from 'axios';
import { Link } from 'react-router-dom';

const Branches = () => {
    const [branches, setBranches] = useState([]);

    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetBranches")
        .then(res => setBranches(res.data))
        .catch(error => console.error('Error fetching branches:', error));
    }, []);

    return (
        <>
            <div className ="List">
            <h2>Find Your Local Library: </h2>
                <ul>
                    {branches.map(branch => (
                    <li key={branch.branchId}>
                        <Link to={`/BranchInformation/${branch.branchId}`}></Link>
                        {branch.branchLocation}
                    </li>
                    /*<li>Bristol Library</li>
                    <li>Derby Library</li>
                    <li>London Library</li>
                    <li>Leeds Library</li>
                    <li>Liverpool Library</li>
                    <li>Manchester Library</li>
                    <li>Newcastle Library</li>
                    <li>Plymouth Library</li>
                    <li>Sheffield Library</li>
                    <li>Southampton Library</li>
                    <li>York Library</li>*/
                ))}
                </ul>
            </div>
        </>
    )
}

export default Branches;