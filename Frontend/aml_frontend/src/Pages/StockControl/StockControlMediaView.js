import {React, useEffect, useState} from "react";
import axios from "axios";
import {useParams} from "react-router-dom";

const StockControlMediaView = () => {
    let { id } = useParams();
    
    
return (
        <>
            <p>{id}</p>
        </>
    )
}

export default StockControlMediaView