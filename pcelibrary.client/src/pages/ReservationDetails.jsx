import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import React, { useState, useEffect } from 'react';
import { fetchData } from '../utils/fetchData';

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
                <div key={index}>
                    <p>Book Type: {bookReservation.bookType ?? "NOT FOUND"}</p>
                    <p>Quick Pick Up: {bookReservation.quickPickUp ? 'Yes' : 'No'}</p>
                    <p>Days: {bookReservation.days ?? "NOT FOUND"}</p>
                    <p>Price: {bookReservation.price ?? "NOT FOUND"}</p>
                    <p>ImagePath: {bookReservation.imagePath ?? "NOT FOUND"}</p>
                </div>
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