import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import { fetchData } from '../utils/fetchData';
import BookReservation from '../components/BookReservation/BookReservation';
import '../styles/ReservationDetails.css';

const ReservationDetails = () => {

    const [reservationDetails, setReservationDetails] = useState({});
    const reservationId = sessionStorage.getItem('reservationId');

    const navigate = useNavigate();

    const handleGoBack = () => {
        navigate('/');
    }

    const fetchReservationDetails = async () => {
        await fetchData(`api/reservations/${reservationId}`, setReservationDetails);
    }

    useEffect(() => {
        if (reservationId) {
            fetchReservationDetails();
        }
    }, [])

    return (
        <div className='reservation-details'>
            <h1>Book Reservations</h1>
            <div className='book-reservations'>
                {reservationDetails.bookReservations?.map((bookReservation, index) => (
                    <BookReservation key={index} bookReservation={bookReservation} />
                ))}
            </div>
            <div>
                <p>Total Price: {reservationDetails.totalPrice}</p>
            </div>
            <Button variant="contained" onClick={handleGoBack}>
                Back
            </Button>
        </div>
    );
}

export default ReservationDetails;