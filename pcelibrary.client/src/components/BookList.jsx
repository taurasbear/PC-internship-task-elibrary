import { useState } from 'react';
import BookItem from './BookItem';
import ReservationDialog from './ReservationDialog';
import { fetchData } from '../utils/fetchData';

const BookList = ({ books }) => {

    const [selectedBook, setSelectBook] = useState(null);
    const [bookTypes, setBookTypes] = useState([]);
    const [openDialog, setOpenDialog] = useState(false);
    const [reservationDetails, setReservationDetails] = useState({
        type: '',
        quickPickUp: false,
        days: ''
    });

    const handleBookClick = async (book) => {
        setSelectBook(book);
        console.log('book', book);
        console.log('bookid', book.id);
        await fetchData(`api/booktypes?bookId=${book.id}`, setBookTypes);
        console.log('book types:', bookTypes);
        setOpenDialog(true);
    };

    const handleClose = () => {
        setOpenDialog(false)
        setSelectBook(null);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setReservationDetails(prevstate => ({
            ...prevstate,
            [name]: value
        }));
    };

    const handleSubmit = () => {
        // post request to backend
        console.log('Reservation Details:', reservationDetails);
        handleClose();
    }

    return (
        <div>
            <ul>
                {books.map(book => (<BookItem key={book.id} book={book} onBookClick={handleBookClick} />))}
            </ul>

            <ReservationDialog
                open={openDialog}
                onClose={handleClose}
                selectedBook={selectedBook}
                bookTypes={bookTypes}
                reservationDetails={reservationDetails}
                handleChange={handleChange}
                handleSubmit={handleSubmit}
            />
        </div>
    );
};

export default BookList;