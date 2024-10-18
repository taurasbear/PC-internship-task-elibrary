import '../styles/BookItem.css'

const BookItem = ({ book, onBookClick }) => {

    return (
        <div className="book-item" onClick={() => onBookClick(book)}>
            <li key={book.id}>
                <img src={book.imagePath} alt={book.title} />
                <h3>{book.title}</h3>
                <p>{book.year}</p>
            </li>
        </div>
    );
}

export default BookItem