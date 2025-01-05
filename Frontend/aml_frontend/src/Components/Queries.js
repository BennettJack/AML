import '../CSS/Queries.css';
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Queries = () => {
    const [branches, setBranches] = useState([]);

    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetAllBranches")
        .then(res => setBranches(res.data))
        .catch((e) => console.log(e));
    }, []);

    return (
        <div className="QueriesContainer">
            <div className = "QueryButtons">
                <form>
                    <button type="button">Query</button>
                    <button type="button">Query</button>
                    <button type="button">Query</button>
                    <button type="button">Query</button>
                    <button type="button">Query</button>
                </form>
            </div>
            <div className = "QueryView">
                <form>
                    <h2>Query</h2>
                    <h3>Member Query: </h3>
                    <textarea name="QueryMessage" rows="10" cols="30">Query Message Here</textarea>
                    <h3>Response: </h3>
                    <textarea name="QueryResponse" rows="10" cols="30">Type Query Response Here...</textarea>
                    <div>
                        <button type="submit">Confirm</button>
                        <button>Close Query</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default Queries;