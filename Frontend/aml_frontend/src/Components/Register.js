import {React, useEffect, useState} from "react";
import Header from "./Header";
import Footer from "./Footer";
import "../CSS/Register.css";
import axios from "axios";

const Register = () => {
    const [branches, setBranches] = useState([])
    
    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetBranches").then(res => 
             setBranches(res.data)).catch((e) => console.log("oops"))
    },[])
    
    const [formData , setFormData] = useState({
        name: '',
        username: '',
        email: '',
        password: '',
        branchId: ''
    });
    
    const handleChange = (e) => {
        const {name, value } = e.target;

        setFormData({
            ...formData,
            [name]: value,
        });
    }
    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post("https://localhost:7095/UserService/api/UserAccount/RegisterNewUser", formData)
            .then(res => console.log(res))
            .catch((e) => console.log(e.message))
    };
    
    return (
        <div className="pageWrapper">
            <Header />
            <main className="registerContainer">
                <h1>Member Registration</h1>
                <form className="registerForm" onSubmit={handleSubmit}>
                    <label>
                        Username:
                        <input 
                            type="text" 
                            name="name"
                            value={formData.name}
                            onChange={handleChange}
                        />
                    </label>
                    <label>
                        Name:
                        <input
                            type="text"
                            name="username"
                            value={formData.username}
                            onChange={handleChange}
                        />
                    </label>
                    <label>
                        Email Address:
                        <input 
                            type="email" 
                            name="email"
                            value={formData.email}
                            onChange={handleChange}
                        />
                    </label>
                    <label>
                        Location:
                        <select
                            name="branchId"
                            value={formData.branchId}
                            onChange={handleChange}
                        >
                            <option value={""} defaultValue={"true"}>Please Select</option>
                            {branches.map(function (branch) {
                                return (
                                    <option value={branch.branchId}>{branch.branchLocation}</option>
                                )
                            })}
                        </select>
                    </label>
                    <label>
                        Password:
                        <input
                            type="password"
                            name="password"
                            value={formData.password}
                            onChange={handleChange}
                        />
                    </label>
                    <label>
                        Confirm Password:
                        <input 
                            type="password" 
                            name="confirmPassword"
                        />
                    </label>
                    <button type="submit">Submit</button>
                </form>
            </main>
            <Footer />
        </div>
    );
};

export default Register;
