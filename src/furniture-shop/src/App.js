import React from 'react'

import Layout from './components/Layout';
import AdminLayout from './components/admin/AdminLayout';
import * as adminIndex from './pages/admin/Index';

import { BrowserRouter as Router, Routes,Route } from 'react-router-dom';

import Home from './pages/Home';
import Catalog from './pages/Catalog'
import Cart from './pages/Cart'
import ViewProduct from './pages/ViewProduct'
import Contact from './pages/Contact'
import About from './pages/About'

import Products from './pages/admin/Product/Product';
import Categories from './pages/admin/Categories';
import Tags from './pages/admin/Tags';
import Producers from './pages/admin/Producers';
import Edit from './pages/admin/Product/Edit';

import NotFound from './pages/NotFound';
import BadRequest from './pages/BadRequest'

function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<Layout />}>
            <Route path='/' element={<Home />}/>
            <Route path='/home' element={<Home />}/>
            <Route path='/catalog/:slug' element={<ViewProduct />}/>
            <Route path='/catalog' element={<Catalog />}/>
            <Route path='/cart' element={<Cart />}/>
            <Route path='/contact' element={<Contact />}/>
            <Route path='/about' element={<About />}/>
        </Route>
        
        <Route path='/admin' element={<AdminLayout />} >
          <Route path='/admin' element={<adminIndex.default />} />
          <Route path='/admin/producers' element={<Producers />} />
          <Route path='/admin/categories' element={<Categories />} />
          <Route path='/admin/products' element={<Products />} />
          <Route path='/admin/products/edit' element={<Edit />} />
          <Route path='/admin/products/edit/:id' element={<Edit />} />
          <Route path='/admin/tags' element={<Tags />} />
        </Route>

        <Route path='/400' element={<BadRequest />} />
        <Route path='*' element={<NotFound />} />
      </Routes>
    </Router>
  );
}


export default App;
