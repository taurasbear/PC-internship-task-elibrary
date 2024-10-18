import React, { useState } from 'react';
import { Dialog, DialogTitle, DialogContent, DialogActions, Button, TextField, FormControl, InputLabel, Select, MenuItem } from '@mui/material';
import BookItem from './BookItem';

const BookList = ({ books }) => {
    const [selectedBook, setSelectBook] = useState(null);
    const [openDialog, setOpenDialog] = useState(false);
    const [reservationDetails, setReservationDetails] = useState({
        type: '',
        quickPickUp: false,
        days: ''
    });

    const handleBookClick = (book) => {
        setSelectBook(book);
        setOpenDialog(true);
    };

    const handleClose = () => {
        setOpenDialog(false)
        setSelectBook(null);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setReservationDetails(prevstate => ({
            ...prevstate,
            [name]: value
        }));
    };

    const handleSubmit = () => {
        // post request to backend
        console.log('Reservation Details:', reservationDetails);
        handleClose();
    }

    return (
        <div>
            <ul>
                {books.map(book => (<BookItem key={book.id} book={book} onBookClick={handleBookClick} />))}
            </ul>

            <Dialog open={openDialog} onClose={handleClose}>
                <DialogTitle>Reserve {selectedBook?.name}</DialogTitle>
                <DialogContent>
                    <FormControl fullWidth margin="normal">
                        <InputLabel>Type</InputLabel>
                        <Select
                            name="type"
                            value={reservationDetails.type}
                            onChange={handleChange}
                        >
                            <MenuItem value="Physical">Physical book</MenuItem>
                            <MenuItem value="Audio">Audiobook</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl fullWidth margin="normal">
                        <InputLabel>Quick Pick Up</InputLabel>
                        <Select
                            name="quickPickUp"
                            value={reservationDetails.quickPickUp}
                            onChange={handleChange}
                        >
                            <MenuItem value={true}>Yes</MenuItem>
                            <MenuItem value={false}>No</MenuItem>
                        </Select>
                    </FormControl>
                    <TextField
                        name="days"
                        label="For how many days"
                        type="number"
                        fullWidth
                        margin="normal"
                        value={reservationDetails.days}
                        onChange={handleChange}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Cancel</Button>
                    <Button onClick={handleSubmit} color="primary">Reserve</Button>
                </DialogActions>
            </Dialog>
        </div>
    );
};

export default BookList;