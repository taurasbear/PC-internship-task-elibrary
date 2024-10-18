import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
//import App from './App.jsx'
import BookList from './BookList.jsx'
import './index.css'

createRoot(document.getElementById('root')).render(
    <StrictMode>
        <BookList />
    </StrictMode>,
)
