import '../CSS/MediaInfo.css';
import lotrBookSmall from './images/lotrBookSmall.jpg';
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

const MediaInfo = () => {
    const { mediaId } = useParams();
    const [branches, setBranches] = useState([]);

    useEffect(() => {
        axios.get("https://localhost:7095/BranchService/api/Branch/GetAllBranches")
        .then(res => setBranches(res.data))
        .catch((e) => console.log(e));
    }, []);

    const info = {
        image: "image",
        mediaName: "info",
        type: "type",
        genre: "genre",
        author: "author",
        publisher: "publisher",
        publishDate: "publishDate",
        pageCount: "pageCount",
        available: "available"
    };

    return (
        <>
            <div className="MediaInfo">
                <div className="MediaImage">
                    {branches.map(MediaModel => {
                        <div key={MediaModel.MediaModelId}>
                            <img src={MediaModel.FullImageUrl} id="mediaResultImage" alt="media cover" width="113" height="171"></img>
                        </div>
                    })}
                </div>
                <div className ="Info">
                    <div className ="InfoLine1">
                        {branches.map(MediaModel => {
                            <div key={MediaModel.MediaModelId}>
                                <p>Media Name: {MediaModel.Title}</p>
                                <p>Media PublishDate: {MediaModel.PublishDate}</p>
                                <p>Media SerialNumber: {MediaModel.SerialNumber}</p>
                            </div>
                        })}
                        {branches.map(Genre => {
                            <div key={Genre.GenreID}>
                                <p>Media Name: {Genre.GenreName}</p>
                            </div>
                        })}
                    </div>
                    <div className ="InfoLine2">
                        {branches.map(Author => {
                            <div key={Author.AuthorId}>
                                <p>Author: {Author.AuthorName}</p>
                            </div>
                        })}
                        {branches.map(Publisher => {
                            <div key={Publisher.PublisherId }>
                                <p>Publisher: {Publisher.PublisherName }</p>
                            </div>
                        })}
                        {branches.map(Book => {
                            <div key={Book.MediaModelId }>
                                <p>Page Count: {Book.PageCount }</p>
                            </div>
                        })}
                        {branches.map(Publisher => {
                            <div key={Publisher.PublisherId }>
                                <p>Available: {Publisher.PageCount }</p>
                            </div>
                        })}
                    </div>
                </div>
            </div>
            <div className ="MediaDescription">
                {branches.map(MediaModel => {
                    <div key={MediaModel.MediaModelId}>
                        <p>Description</p>
                        <p>{MediaModel.Description}</p>
                    </div>
                })}
            </div>
            <div className="bookButton">
                <button>Book</button>
            </div>
        </>
    )
}

export default MediaInfo;