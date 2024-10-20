import React, { useEffect, useState } from 'react';
import BookTypeDropdown from '../components/BookTypeDropdown/BookTypeDropdown';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import BookList from '../components/BookList/BookList';
import { fetchData } from '../utils/fetchData';
import { useNavigate } from 'react-router-dom';
import '../styles/ReserveBooks.css';

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

    const handleFilterChange = (filterName, filterValue) => {
        setFilters(prevFilters => ({
            ...prevFilters,
            [filterName]: filterValue
        }));
    }

    useEffect(() => {
        populateBooks()
    }, [filters])

    return (
        <div className='reserve-books'>
            <div>
                <h1>E-Library</h1>
            </div>
            <div className='content-container'>
                <div className='book-filters'>
                    <h2 className='filters-title'>Select Book Filters</h2>
                    <div className='filters-inputs'>
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
                </div>
                <BookList books={books} />
            </div>
            <div className="view-reservation">
                <Button variant="contained" onClick={handleViewReservation}>
                    View Book Reservations
                </Button>
            </div>
        </div>
    );
}

export default ReserveBooks