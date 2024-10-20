import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import { fetchData } from '../utils/fetchData';
import BookReservation from '../components/BookReservation/BookReservation';

const ReservationDetails = () => {

    const [reservationDetails, setReservationDetails] = useState({});
    const [reservationId, setReservationId] = useState(sessionStorage.getItem('reservationId'));

    const navigate = useNavigate();

    const handleGoBack = () => {
        navigate('/');
    }

    const fetchReservationDetails = async () => {
        await fetchData(`api/reservations/${reservationId}`, setReservationDetails);
        console.log('---> Reservation Details:', reservationDetails);
    }

    useEffect(() => {
        fetchReservationDetails();
    }, [])

    return (
        <div>
            <h1>Reservation Details</h1>
            <p>Reservation ID: {reservationId}</p>
            {reservationDetails.bookReservations?.map((bookReservation, index) => (
                <BookReservation key={index} bookReservation={bookReservation} />
            ))}
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