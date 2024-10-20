import React, { useState } from 'react';
import BookItem from '../BookItem/BookItem';
import ReservationDialog from '../ReservationDialog/ReservationDialog';
import { fetchData, postData } from '../../utils/fetchData';
import PropTypes from 'prop-types';
import './BookList.css';

const BookList = ({ books }) => {
    const defaultReservationDetails = {
        bookTypeId: '',
        quickPickUp: false,
        days: '',
    };

    const [reservationId, setReservationId] = useState(sessionStorage.getItem('reservationId') || null);
    const [selectedBook, setSelectedBook] = useState(null);
    const [bookTypes, setBookTypes] = useState([]);
    const [openDialog, setOpenDialog] = useState(false);
    const [reservationDetails, setReservationDetails] = useState(defaultReservationDetails);
    const [errorMessage, setErrorMessage] = useState('');

    const handleBookClick = async (book) => {
        setSelectedBook(book);
        await fetchData(`api/booktypes?bookId=${book.id}`, setBookTypes);
        setOpenDialog(true);
    };

    const handleClose = () => {
        setOpenDialog(false)
        setSelectedBook(null);
        setReservationDetails(defaultReservationDetails);
        setErrorMessage('');
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setReservationDetails(prevstate => ({
            ...prevstate,
            [name]: value
        }));
    };

    const handleSubmit = async () => {
        try {
            if (!validateReservationDetails()) {
                return;
            }
            console.log('Sending reservation Details:', reservationDetails);
            console.log('with reservationId:', reservationId);
            const data = await postData('api/bookreservations', { ...reservationDetails, reservationId });
            console.log('Received data:', data);
            console.log('data.ReservationId:', data.reservationId);
            setReservationId(data.reservationId);
            sessionStorage.setItem('reservationId', data.reservationId);
            handleClose();
        }
        catch (error) {
            if (error.message) {
                setErrorMessage(error.message);
            } else {
                console.error('An unexpected error occurred:', error);
            }
        }

    }

    const validateReservationDetails = () => {
        if (!reservationDetails.bookTypeId) {
            setErrorMessage('Please select a book type.');
            return false;
        }
        if (!reservationDetails.days || reservationDetails.days <= 0) {
            setErrorMessage('Please enter correct number of days.');
            return false;
        }
        return true;
    }

    return (
        <div>
            <div className='book-list'>
                {books.map(book => (<BookItem key={book.id} book={book} onBookClick={handleBookClick} />))}
            </div>
            <ReservationDialog
                open={openDialog}
                onClose={handleClose}
                selectedBook={selectedBook}
                bookTypes={bookTypes}
                reservationDetails={reservationDetails}
                errorMessage={errorMessage}
                handleChange={handleChange}
                handleSubmit={handleSubmit}
            />
        </div>
    );
};

BookList.propTypes = {
    books: PropTypes.array.isRequired
}

export default BookList;