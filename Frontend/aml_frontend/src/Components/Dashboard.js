import React from "react";
import { Link } from "react-router-dom";
import '../CSS/Dashboard.css';

const Dashboard = () => {
    return (
        <div className ="dashboardContainer">
            <div className ="buttonsContainer">
                <form>
                    <button type="button">Branch Information</button>
                    <Link to="/Queries" className="button">Member Queries</Link>
                    <button type="button">Branch Members</button>
                    <button type="button">Media Usage</button>
                    <button type="button">Media Transfers</button>
                    <button type="button">Media Management</button>
                </form>
            </div>
            <div className ="infoContainer">
                <h2>Branch Information</h2>
                <h3>Opening Hours</h3>
                <form>
                    <label for="mon">Monday: </label>
                    <input type="text" id="mon" name="hours" value="08:30 - 17:30"></input>
                    <label for="tue">Tuesday: </label>
                    <input type="text" id="tue" name="hours" value="08:30 - 17:30"></input>
                    <label for="wed">Wedsnesday: </label>
                    <input type="text" id="wed" name="hours" value="08:30 - 17:30"></input>
                    <label for="thu">Thursday: </label>
                    <input type="text" id="thu" name="hours" value="08:30 - 17:30"></input>
                    <label for="fri">Friday: </label>
                    <input type="text" id="fri" name="hours" value="08:30 - 17:30"></input>
                    <label for="sat">Saturday: </label>
                    <input type="text" id="sat" name="hours" value="Closed"></input>
                    <label for="sun">Sunday: </label>
                    <input type="text" id="sun" name="hours" value="Closed"></input>
                    <div>
                        <input type="submit" value="Change Hours"></input>
                    </div>
                </form>
            </div>
        </div>
    )
}
export default Dashboard;