import { Dialog, DialogTitle, DialogContent, DialogActions, Button, TextField, FormControl, InputLabel, Select, MenuItem } from '@mui/material';

const ReservationDialog = ({ open, onClose, selectedBook, bookTypes, reservationDetails, handleChange, handleSubmit }) => {
    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Reserve {selectedBook?.name}</DialogTitle>
            <DialogContent>
                <FormControl fullWidth margin="normal">
                    <InputLabel>Type</InputLabel>
                    <Select
                        name="type"
                        value={reservationDetails.type}
                        onChange={handleChange}
                    >
                        {bookTypes.map(bookType => (
                            <MenuItem key={bookType.bookType} value={bookType.bookType}>
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

export default ReservationDialog;