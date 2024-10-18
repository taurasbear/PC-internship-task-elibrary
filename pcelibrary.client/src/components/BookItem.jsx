import '../styles/BookItem.css'

const BookItem = ({ book }) => {

    return (
        <div className="book-item">
            <img src={book.imagePath} alt={book.title} />
            <h3>{book.title}</h3>
            <p>{book.year}</p>
        </div>
    );
}

export default BookItem