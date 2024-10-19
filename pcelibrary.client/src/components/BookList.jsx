import React, { useState } from 'react';
import BookItem from './BookItem';
import ReservationDialog from './ReservationDialog';
import { fetchData } from '../utils/fetchData';

const BookList = ({ books }) => {

    const defaultReservationDetails = {
        bookTypeId: '',
        quickPickUp: false,
        days: ''
    };

    const [selectedBook, setSelectBook] = useState(null);
    const [bookTypes, setBookTypes] = useState([]);
    const [openDialog, setOpenDialog] = useState(false);
    const [reservationDetails, setReservationDetails] = useState(defaultReservationDetails);

    const handleBookClick = async (book) => {
        setSelectBook(book);
        await fetchData(`api/booktypes?bookId=${book.id}`, setBookTypes);
        setOpenDialog(true);
    };

    const handleClose = () => {
        setOpenDialog(false)
        setSelectBook(null);
        setReservationDetails(defaultReservationDetails);
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
        setReservationDetails(defaultReservationDetails);
    }

    return (
        <div>
            <ul>
                {books.map(book => (<BookItem key={book.id} book={book} onBookClick={handleBookClick} />))}
            </ul>

            <ReservationDialog
                open={openDialog}
                onClose={handleClose}
                selectedBook={selectedBook}
                bookTypes={bookTypes}
                reservationDetails={reservationDetails}
                handleChange={handleChange}
                handleSubmit={handleSubmit}
            />
        </div>
    );
};

export default BookList;