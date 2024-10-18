import { useEffect, useState } from 'react';
import { FormControl, InputLabel, Select, MenuItem } from '@mui/material';

const BookTypeDropdown = ({onBookTypeChange }) => {
    const [bookTypes, setBookTypes] = useState([]);
    const [selectedBookType, setSelectedBookType] = useState([]);

    useEffect(() => {
        const fetchBookTypes = async () => {
            await fetch('api/enums/booktypes')
                .then(response => response.json())
                .then(data => setBookTypes(data))
                .catch(error => console.error("Error fetching book types:", error));
        }

        fetchBookTypes();
    }, [])

    const handleChange = (event) => {
        const selectedType = event.target.value;
        setSelectedBookType(selectedType);
        onBookTypeChange(event);
    };

    return (
        <FormControl fullWidth>
            <InputLabel id="book-type-label">Book Type</InputLabel>
            <Select
                labelId="book-format-label"
                id="book-type"
                value={selectedBookType}
                label="Book Type"
                onChange={handleChange}
            >
                {bookTypes.map((type) => (
                    <MenuItem key={type} value={type}>
                        {type}
                    </MenuItem>
                ))}
                <MenuItem key="all" value="">
                    All
                </MenuItem>
            </Select>
        </FormControl>
    );
}

export default BookTypeDropdown;