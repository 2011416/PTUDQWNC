import React from 'react'

import { BrowserRouter as Router } from 'react-router-dom';

import Header from './Header'
import Footer from './Footer'

import ProductViewModal from './ProductViewModal'

import Switchs from '../routes/Switchs'

const Layout = () => {
    return (
        <Router>
                <div>
                    <Header/>
                    <div className="container">
                        <div className="main">
                            <Switchs/>
                        </div>
                    </div>
                    <Footer/>
                    <ProductViewModal />
                </div>
        </Router>
    )
}

export default Layout