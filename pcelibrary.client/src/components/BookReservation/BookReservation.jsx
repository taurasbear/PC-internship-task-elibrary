import React from "react";
import "./BookReservation.css";
import PropTypes from 'prop-types';

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

BookReservation.propTypes = {
    bookReservation: PropTypes.shape({
        title: PropTypes.string.isRequired,
        imagePath: PropTypes.string.isRequired,
        bookType: PropTypes.string.isRequired,
        quickPickUp: PropTypes.bool.isRequired,
        days: PropTypes.number.isRequired,
        price: PropTypes.number.isRequired
    }).isRequired
}

export default BookReservation;