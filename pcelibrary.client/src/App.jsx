import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ReserveBooks from './pages/ReserveBooks';
import ReservationDetails from './pages/ReservationDetails';
import './App.css';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/reservationDetails" element={<ReservationDetails />} />
                <Route path="/" element={<ReserveBooks />} />
            </Routes>
        </Router>
    );
}

export default App;