import React from 'react';
import PropTypes from 'prop-types';
import './BookItem.css';

const BookItem = ({ book, onBookClick }) => {

    return (
        <div className="book-item" onClick={() => onBookClick(book)}>
            <img src={book.imagePath} alt={book.title} />
            <h3>{book.title}</h3>
            <p>{book.year}</p>
        </div>
    );
};

BookItem.propTypes = {
    book: PropTypes.shape({
        id: PropTypes.number.isRequired,
        title: PropTypes.string.isRequired,
        year: PropTypes.number.isRequired,
        imagePath: PropTypes.string.isRequired
    }).isRequired,
    onBookClick: PropTypes.func.isRequired
}

export default BookItem;