import React from 'react'

import { Route, Routes } from 'react-router-dom'

import Home from '../pages/Home'
import Catalog from '../pages/Catalog'
import Cart from '../pages/Cart'
import Product from '../pages/Product'

const Switchs = () => {
  return (
    <Routes>
        <Route path='/' exact element={<Home />}/>
        <Route path='/catalog/:slug' element={<Product/>}/>
        <Route path='/catalog' element={<Catalog />}/>
        <Route path='/cart' element={<Cart />}/>
    </Routes>
  )
}

export default Switchs