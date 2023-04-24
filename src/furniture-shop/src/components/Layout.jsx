import React from 'react'

import { BrowserRouter} from 'react-router-dom'

import Header from './Header'
import Footer from './Footer'

import Switchs from '../routes/Switchs'


const Layout = () => {
  return (
    <BrowserRouter>
      <div>
        <div className="container">
          <Header/>
          <div className="main">
            <Switchs/>
          </div>
        </div>
        <Footer/>
      </div>
    </BrowserRouter>      
  )
}

export default Layout