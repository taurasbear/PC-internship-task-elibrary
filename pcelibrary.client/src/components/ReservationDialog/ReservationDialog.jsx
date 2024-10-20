import React from 'react';
import { Dialog, DialogTitle, DialogContent, DialogActions, Button, TextField, FormControl, InputLabel, Select, MenuItem } from '@mui/material';
import PropTypes from 'prop-types';

const ReservationDialog = ({ open, onClose, selectedBook, bookTypes, reservationDetails, errorMessage, handleChange, handleSubmit }) => {
    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Reserve &quot;{selectedBook?.title}&quot;</DialogTitle>
            {errorMessage && <div className="error-message">{errorMessage}</div>}
            <DialogContent>
                <FormControl fullWidth margin="normal">
                    <InputLabel>Type</InputLabel>
                    <Select
                        name="bookTypeId"
                        value={reservationDetails.bookTypeId}
                        onChange={handleChange}
                    >
                        {bookTypes.map(bookType => (
                            <MenuItem key={bookType.id} value={bookType.id}>
                                {bookType.bookType}
                            </MenuItem>
                        ))}
                    </Select>
                </FormControl>
                <FormControl fullWidth margin="normal">
                    <InputLabel>Quick Pick Up</InputLabel>
                    <Select
                        name="quickPickUp"
                        value={reservationDetails.quickPickUp}
                        onChange={handleChange}
                    >
                        <MenuItem value={true}>Yes</MenuItem>
                        <MenuItem value={false}>No</MenuItem>
                    </Select>
                </FormControl>
                <TextField
                    name="days"
                    label="For how many days"
                    type="number"
                    fullWidth
                    margin="normal"
                    value={reservationDetails.days}
                    onChange={handleChange}
                />
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button>
                <Button onClick={handleSubmit} color="primary">Reserve</Button>
            </DialogActions>
        </Dialog>
    );
};

ReservationDialog.propTypes = {
    open: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
    selectedBook: PropTypes.object.isRequired,
    bookTypes: PropTypes.array.isRequired,
    reservationDetails: PropTypes.object.isRequired,
    errorMessage: PropTypes.string,
    handleChange: PropTypes.func.isRequired,
    handleSubmit: PropTypes.func.isRequired
};

export default ReservationDialog;