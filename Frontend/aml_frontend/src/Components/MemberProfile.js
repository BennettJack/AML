import React from "react";
import Header from "./Header";
import Footer from "./Footer";
import "../CSS/MemberProfile.css";

const MemberProfile = () => {
    const user = {
        firstName: "Bob",
        lastName: "Smith",
        email: "bsmith@email.com",
        location: "Sheffield",
        accountType: "Member",
    };

    return (
        <div className="pageWrapper">
            <Header />
            <main className="profileContainer">
                <h1>Member Profile</h1>
                <h3>User Information</h3>
                <div className="profileDetails">
                    <p><strong>First Name:</strong> {user.firstName}</p>
                    <p><strong>Last Name:</strong> {user.lastName}</p>
                    <p><strong>Email Address:</strong> {user.email}</p>
                    <p><strong>Location:</strong> {user.location}</p>
                    <button className="resetButton">Reset Password</button>
                </div>

                <table className="profileTable">
                    <tbody>
                        <tr>
                            <td><strong>Name:</strong></td>
                            <td>{user.firstName}</td>
                        </tr>
                        <tr>
                            <td><strong>Last Name:</strong></td>
                            <td>{user.lastName}</td>
                        </tr>
                        <tr>
                            <td><strong>Email Address:</strong></td>
                            <td>{user.email}</td>
                        </tr>
                        <tr>
                            <td><strong>Location:</strong></td>
                            <td>{user.location}</td>
                        </tr>
                        <tr>
                            <td><strong>Account Type:</strong></td>
                            <td>{user.accountType}</td>
                        </tr>
                    </tbody>
                </table>
            </main>
            <Footer />
        </div>
    );
};

export default MemberProfile;
