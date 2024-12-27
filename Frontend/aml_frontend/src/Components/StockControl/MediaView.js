import {React, useEffect, useState} from "react";

const MediaView = ({mediaItem}) => {
    
    
    return(
        <div>
            <h2>{mediaItem.title}</h2>
            <img src={"https://localhost:7254/Images/FullImage/" + mediaItem.fullImageUrl}
                 alt={"image of " + mediaItem.title}/>
        </div>
    )
}

export default MediaView