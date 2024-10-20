import React, { useEffect, useState } from 'react';
import BookTypeDropdown from '../components/BookTypeDropdown';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import BookList from '../components/BookList';
import { fetchData } from '../utils/fetchData';
import { useNavigate } from 'react-router-dom';

const ReserveBooks = () => {

    const navigate = useNavigate();

    const handleViewReservation = () => {
        navigate('/reservationDetails');
    }

    const [books, setBooks] = useState([]);
    const [filters, setFilters] = useState({
        title: "",
        year: "",
        type: ""
    });

    const populateBooks = async () => {
        const query = new URLSearchParams(filters).toString();
        const url = `api/books?${query}`;
        await fetchData(url, setBooks)
    }

    useEffect(() => {
        populateBooks()
    }, [filters])

    const handleFilterChange = (filterName, filterValue) => {
        setFilters(prevFilters => ({
            ...prevFilters,
            [filterName]: filterValue
        }));
    }

    return (
        <div className='books'>
            <div>
                <h1>List of books:</h1>
            </div>
            <BookList books={books} />
            <div>
                <h2>Select Book Filters</h2>
                <TextField
                    label="Title"
                    value={filters.title}
                    onChange={(e) => handleFilterChange("title", e.target.value)}
                    fullWidth
                />
                <TextField
                    label="Year"
                    type="number"
                    value={filters.year}
                    onChange={(e) => handleFilterChange("year", e.target.value)}
                    fullWidth
                />
                <BookTypeDropdown onBookTypeChange={(e) => handleFilterChange("type", e.target.value)} />
            </div>
            <div className = "view-reservation">
                <Button variant="contained" onClick={handleViewReservation}>
                    View Reservation
                </Button>
            </div>
        </div>
    );
}

export default ReserveBooks