import "../CSS/BranchInformation.css";
import MapImage from './images.MapImage.png';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

const BranchInformation = () => {
    const { id } = useParams();
    const [branch, setBranch] = useState(null)

    useEffect(() => {
        fetch("https://localhost:7095/BranchService/api/Branch/${id}")
        .then(response => response.json())
        .then(data => setBranch(data))
        .catch(error => console.error('Error fetching branch:', error));
    }, [id]);

    if (!branch) {
        return <div>Loading</div>;
    }

    return (
        <div>
            <h2>Branch Information</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean sit amet magna condimentum, dapibus lectus vel, pulvinar nulla. Integer cursus tellus sit amet dolor rutrum finibus. Integer nec rhoncus diam. Suspendisse ac ex dignissim, volutpat quam eu, accumsan eros. Morbi euismod felis erat, vel tincidunt sem imperdiet ut. Aliquam dolor tellus, volutpat nec massa vitae, efficitur finibus mi. Donec non ligula at nisi dignissim eleifend eget ac nunc. Nulla gravida vel sem nec dictum.</p>
            <h2>Opening Hours</h2>
            <ul>
                <li>Monday: 09:00 - 17:00</li>
                <li>Tuesday: 09:00 - 17:00</li>
                <li>Wednesday: 09:00 - 17:00</li>
                <li>Thursday: 09:00 - 17:00</li>
                <li>Friday: 09:00 - 17:00</li>
                <li>Saturday: Closed</li>
                <li>Sunday: Closed</li>
            </ul>
            <h2>{branch.branchLocation}</h2>
            <div id="map">
            <script async defer src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap"></script>
            <img src={MapImage} alt = "Map Image" width="700" height="500"></img>
            </div>
        </div>
    )
}
export default BranchInformation;