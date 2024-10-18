import { useEffect, useState } from 'react';
import BookItem from './components/BookItem'

const BookList = () => {

    const [books, setBooks] = useState([]);
    const populateBooks = async () => {
        fetch('api/books')
            .then(response => response.json())
            .then(data => setBooks(data))
            .catch(error => console.error('Error fetching books:', error))
    }

    useEffect(() => {
        populateBooks()
    }, [])

    return (
        <div className='books'>
            <div>
                <h1>List of books:</h1>
            </div>
            {books.map(book => (<BookItem key={book.id} book={book}></BookItem>))}
        </div>
    );
}

export default BookList