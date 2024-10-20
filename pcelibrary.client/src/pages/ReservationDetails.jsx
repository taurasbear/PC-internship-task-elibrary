import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import React, { useState } from 'react';

const ReservationDetails = () => {

    const navigate = useNavigate();

    const handleGoBack = () => {
        navigate('/');
    }

    const [reservationId, setReservationId] = useState(sessionStorage.getItem('reservationId'));

    return (
        <div>
            <h1>Reservation Details</h1>
            <p>Reservation ID: {reservationId}</p>
            <Button variant="contained" onClick={handleGoBack}>
                Back
            </Button>
        </div>
    );
}

export default ReservationDetails;