import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
//import App from './App.jsx'
import ReserveBooks from './ReserveBooks.jsx'
import './index.css'

createRoot(document.getElementById('root')).render(
    <StrictMode>
        <ReserveBooks />
    </StrictMode>,
)
