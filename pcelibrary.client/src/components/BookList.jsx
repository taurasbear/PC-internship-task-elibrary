import React, { useState, useEffect } from 'react';
import BookItem from './BookItem';
import ReservationDialog from './ReservationDialog';
import { fetchData, postData } from '../utils/fetchData';

const BookList = ({ books }) => {

    const defaultReservationDetails = {
        bookTypeId: '',
        quickPickUp: false,
        days: '',
    };
    const [reservationId, setReservationId] = useState(sessionStorage.getItem('reservationId') || null);

    const [selectedBook, setSelectBook] = useState(null);
    const [bookTypes, setBookTypes] = useState([]);
    const [openDialog, setOpenDialog] = useState(false);
    const [reservationDetails, setReservationDetails] = useState(defaultReservationDetails);
    const [errorMessage, setErrorMessage] = useState('');

    const handleBookClick = async (book) => {
        setSelectBook(book);
        await fetchData(`api/booktypes?bookId=${book.id}`, setBookTypes);
        setOpenDialog(true);
    };

    const handleClose = () => {
        setOpenDialog(false)
        setSelectBook(null);
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
            if(!validateReservationDetails()){
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

    // useEffect(() =>{
    //     console.log('In Use Effect, Reservation Details (after reservationId set):', reservationDetails);
    //     if(reservationDetails.reservationId){
    //         localStorage.setItem('reservationId', reservationDetails.reservationId);
    //     }
    // }, [reservationDetails.reservationId]);

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
                errorMessage={errorMessage}
                handleChange={handleChange}
                handleSubmit={handleSubmit}
            />
        </div>
    );
};

export default BookList;