import { useEffect, useState } from 'react';
import BookItem from './components/BookItem'
import BookTypeDropdown from './components/BookTypeDropdown';
import TextField from '@mui/material/TextField';

const BookList = () => {

    const [books, setBooks] = useState([]);
    const [filters, setFilters] = useState({
        title: "",
        year: "",
        type: ""
    });

    const populateBooks = async () => {
        const query = new URLSearchParams(filters).toString();
        const url = `api/books?${query}`;
        fetch(url)
            .then(response => response.json())
            .then(data => setBooks(data))
            .catch(error => console.error('Error fetching books:', error))
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
            {books.map(book => (<BookItem key={book.id} book={book}></BookItem>))}
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
                    value={filters.year}
                    onChange={(e) => handleFilterChange("year", e.target.value)}
                    fullWidth
                />
                <BookTypeDropdown onBookTypeChange={(e) => handleFilterChange("type", e.target.value)} />
            </div>
        </div>
    );
}

export default BookList