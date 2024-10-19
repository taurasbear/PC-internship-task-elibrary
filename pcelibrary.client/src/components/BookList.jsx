import React, { useState, useEffect} from 'react';
import BookItem from './BookItem';
import ReservationDialog from './ReservationDialog';
import { fetchData, postData} from '../utils/fetchData';

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

    const handleSubmit = async () => {
        const data = await postData('api/bookreservations', {...reservationDetails, reservationId});
        console.log('Received data:', data);
        console.log('data.ReservationId:', data.reservationId);
        setReservationId(data.reservationId);
        sessionStorage.setItem('reservationId', data.reservationId);
        handleClose();
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
                handleChange={handleChange}
                handleSubmit={handleSubmit}
            />
        </div>
    );
};

export default BookList;