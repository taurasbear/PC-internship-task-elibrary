import React from "react";
import "./BookReservation.css";

const BookReservation = ({ bookReservation }) => {
    return (
        <div className='book-reservation'>
            <h3>{bookReservation.title}</h3>
            <img src={bookReservation.imagePath} alt={bookReservation.title} />
            <p>Book Type: {bookReservation.bookType}</p>
            <p>Quick Pick Up: {bookReservation.quickPickUp ? 'Yes' : 'No'}</p>
            <p>Days: {bookReservation.days}</p>
            <p>Price: {bookReservation.price}</p>
        </div>
    );
}

export default BookReservation;