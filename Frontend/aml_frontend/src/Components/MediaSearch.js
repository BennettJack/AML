import '../CSS/MediaSearch.css';
import lotrBookSmall from './images/lotrBookSmall.jpg';
import { useForm } from "react-hook-form";
import { useState } from "react";
import { Link } from "react-router-dom";
import React,{Component} from 'react'

/*const formToJSON = (elements) =>
[].reduce.call(
    elements,
    (data, element) => {
        data[element.name] = element.value;
        return data;
    },
    {}
);

const handleFormSubmit = (event) => {
    event.preventDefault();
    const data = formToJSON(form.elements);
    const dataContainer = document.getElementsByClassName('results_display')[0];
    dataContainer.textContent = JSON.stringify(data, null, ' ');
}

const reducerFuntion = (data, element) => {
    data[element.name] = element.value;
    console.Log(JSON.stringify(data));
    return data;
};

const form = document.getElementsByClassName('searchAndFilter')[0];
form.addEventListener('submit', handleFormSubmit);*/


const MediaSearch = () => {
    const {register, handleSubmit} = useForm();
    const [data, setData] = useState("");
    
    const onSubmit = (data) =>
        //alert(JSON.stringify(data));
    console.log(data);

    const [formData , setFormData] = useState({
        search: '',
        mediaType: '',
    });

    const handleChange = (e) => {
        const {name, value } = e.target;
    
        setFormData({
            ...formData,
            [name]: value,
        });
    }

    return (
        <>
            <div className="searchAndFilter"> 
                <form onSubmit={handleSubmit((data) => setData(JSON.stringify(data)))} id="searchForm">
                    <div className="search">
                        <p>Search the catalogue: </p>
                        <label for="search" id="search" name="search"></label>
                        <input {...register("search")} type="text" id="search" name="search" value={formData.name} onChange={handleChange}></input>
                    </div>
                    <div className="filter">
                        <p>Filter by: </p>
                        <div className="filters">
                            <label for="mediaType">Select media type</label>
                            <select {...register("mediaType")} name="mediaType" id="mediaType" value={formData.name} onChange={handleChange}>
                                <option value="books">Books</option>
                                <option value="Journals">Journals</option>
                                <option value="periodicals">periodicals</option>
                                <option value="Disks">Disks</option>
                                <option value="Games">Games</option>
                            </select>
                            <div>
                            <input type="submit" value="Search"></input>
                            <p>{data}</p>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
            <div className ="resultsContainer">
                <div className ="resultHeading">
                    <h2>Results:</h2>
                </div>
                <div className="mediaResult">
                    <section>
                        <article className="mediaResultArticle" a href="./Pages/MediaResult.js"><Link to="./Pages/MediaResult.js"></Link>
                            <div>
                                <img src={lotrBookSmall} id="mediaResultImage" alt="lotr book" width="113" height="171"></img>
                            </div>
                            <div>
                                <p>Media Name</p>
                                <p>Author</p>
                                <p>Publish Date</p>
                            </div>
                        </article>
                    </section>
                    <section>
                        <article className="mediaResultArticle">
                            <div>
                            <img src={lotrBookSmall} id="mediaResultImage" alt="lotr book" width="113" height="171"></img>
                            </div>
                            <div>
                            <p>Media Name</p>
                            <p>Author</p>
                            <p>Publish Date</p>
                            </div>
                        </article>
                    </section>
                    <section>
                        <article className="mediaResultArticle">
                            <div>
                            <img src={lotrBookSmall} id="mediaResultImage" alt="lotr book" width="113" height="171"></img>
                            </div>
                            <div>
                            <p>Media Name</p>
                            <p>Author</p>
                            <p>Publish Date</p>
                            </div>
                        </article>
                    </section>
                </div>
            </div>

            <div class="results">
            <h2 class="results__heading">Form Data</h2>
            
            </div>
        </>
    )
}
export default MediaSearch;