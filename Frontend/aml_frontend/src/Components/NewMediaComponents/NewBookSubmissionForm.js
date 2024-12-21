import {React, useEffect, useState} from "react";
import axios from "axios";
import MultiSelect from 'multiselect-react-dropdown';

function NewBookSubmissionForm() {
    const [genres, setGenres] = useState([])
    const [authors, setAuthors] = useState([])
    const [publishers, setPublishers] = useState([])
    const [formats, setFormats] = useState([])
    useEffect(() => {
        axios.get("https://localhost:7254/api/Attributes/GetGenresList").then(res => setGenres(res.data)).catch((e) => console.log("oops"))
        axios.get("https://localhost:7254/api/Attributes/GetAuthorsList").then(res => setAuthors(res.data)).catch((e) => console.log("oops"))
        axios.get("https://localhost:7254/api/Attributes/GetPublishersList").then(res => setPublishers(res.data)).catch((e) => console.log("oops"))
        axios.get("https://localhost:7254/api/Attributes/GetFormatsList").then(res => setFormats(res.data)).catch((e) => console.log("oops"))
    },[])
    
    useEffect(() => {
        console.log(genres)
        console.log(authors)
        console.log(publishers)
        console.log(formats)
    },[genres])
    

    const [formData, setFormData] = useState({
        title: '',
        description: '',
        authors: [],
        publishDate: '',
        genres: [],
        formats: [],
        publisher: '',
        pageCount: '',
        serial: '',
    });
    
    useEffect(() => {
        console.log(formData.genres)
    }, [formData.genres])
    
    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;

        if (type === 'checkbox') {
            setFormData({
                ...formData,
                formats: {
                    ...formData.formats,
                    [name]: checked,
                },
            });
        } else if (name === 'authors' || name === 'genres') {
            // Handle multi-select dropdown
            const selectedOptions = Array.from(e.target.selectedOptions, option => option.value);
            setFormData({
                ...formData,
                [name]: selectedOptions,
            });
        } else {
            setFormData({
                ...formData,
                [name]: value,
            });
        }
        
        console.log(formData)
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log('Form Data Submitted:', formData);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Book Title:</label>
                <input
                    type="text"
                    name="title"
                    value={formData.title}
                    onChange={handleChange}
                />
            </div>

            <div>
                <label>Description:</label>
                <textarea
                    name="description"
                    value={formData.description}
                    onChange={handleChange}
                />
            </div>

            <div>
                <label>Authors:</label>
                <select
                    name="authors"
                    multiple
                    value={formData.authors}
                    onChange={handleChange}
                >
                    {authors.map(function (author) {
                        return (
                            <option value={author.authorId}>{author.authorName}</option>
                        )
                    })}
                </select>
            </div>

            <div>
                <label>Publish Date:</label>
                <input
                    type="text"
                    name="publishDate"
                    placeholder="25 jan 1990"
                    value={formData.publishDate}
                    onChange={handleChange}
                />
            </div>

            <div>
                <label>Genres:</label>
                <select
                    name="genres"
                    multiple
                    value={formData.genres}
                    onChange={handleChange}
                >
                    {genres.map(function (genre) {
                        return (
                            <option value={genre.genreId}>{genre.genreName}</option>
                        )
                    })}
                </select>
            </div>
            
            <div>
                <MultiSelect value={"test"} onChange={(e) => formData.genres(e.value)} options={genres} optionLabel="name"
                             placeholder="Select Genres" maxSelectedLabels={3} className="w-full md:w-20rem" />
            </div>

            <div>
                <label>Formats:</label>
                <select
                    name="formats"
                    multiple
                    value={formData.formats}
                    onChange={handleChange}
                >
                    {formats.map(function (format) {
                        return (
                            <option value={format.formatId}>{format.formatName}</option>
                        )
                    })}
                </select>
            </div>

            <div>
                <label>Publisher:</label>
                <select
                    name="publisher"
                    value={formData.publisher}
                    onChange={handleChange}
                >
                    <option value="">Select Publisher</option>
                    {publishers.map(function (publisher) {
                        return (
                            <option value={publisher.publisherId}>{publisher.publisherName}</option>
                        )
                    })}
                </select>
            </div>

            <div>
                <label>Page Count:</label>
                <input
                    type="number"
                    name="pageCount"
                    value={formData.pageCount}
                    onChange={handleChange}
                />
            </div>

            <div>
                <label>Serial:</label>
                <input
                    type="number"
                    name="serial"
                    value={formData.serial}
                    onChange={handleChange}
                />
            </div>

            <button type="submit">Submit</button>
        </form>
    );
}

export default NewBookSubmissionForm