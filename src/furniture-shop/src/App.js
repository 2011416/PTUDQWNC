import React from 'react'

import Layout from './components/Layout';
import AdminLayout from './components/admin/AdminLayout';
import * as adminIndex from './pages/admin/DashBoard';

import { BrowserRouter as Router, Routes,Route } from 'react-router-dom';

import Home from './pages/Home';
import Catalog from './pages/Catalog'
import Cart from './pages/Cart'
import Product from './pages/Product'
import Contact from './pages/Contact'
import About from './pages/About'

import NotFound from './pages/NotFound';
import BadRequest from './pages/BadRequest'

function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<Layout />}>
            <Route path='/' element={<Home />}/>
            <Route path='/home' element={<Home />}/>
            <Route path='/catalog/:slug' element={<Product />}/>
            <Route path='/catalog' element={<Catalog />}/>
            <Route path='/cart' element={<Cart />}/>
            <Route path='/contact' element={<Contact />}/>
            <Route path='/about' element={<About />}/>
        </Route>
        
        <Route path='/admin' element={<AdminLayout />} >
          <Route path='/admin' element={<adminIndex.default />} />
        </Route>

        <Route path='/400' element={<BadRequest />} />
        <Route path='*' element={<NotFound />} />
      </Routes>
    </Router>
  );
}


export default App;
