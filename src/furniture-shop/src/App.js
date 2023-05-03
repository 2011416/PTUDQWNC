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
import Categories from './pages/admin/Category/Categories';
import Roles from './pages/admin/Roles';
import Users from './pages/admin/User/Users';

import Edit from './pages/admin/Product/Edit';
import CategoryEdit from './pages/admin/Category/CategoryEdit';
import UserEdit from './pages/admin/User/UserEdit';

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
          <Route path='/admin/users' element={<Users />} />
          <Route path='/admin/users/edit' element={<UserEdit />} />
          <Route path='/admin/users/edit/:id' element={<UserEdit />} />
          <Route path='/admin/categories' element={<Categories />} />
          <Route path='/admin/categories/edit' element={<CategoryEdit />} />
          <Route path='/admin/categories/edit/:id' element={<CategoryEdit/>} />
          <Route path='/admin/products' element={<Products />} />
          <Route path='/admin/products/edit' element={<Edit />} />
          <Route path='/admin/products/edit/:id' element={<Edit />} />
          <Route path='/admin/roles' element={<Roles />} />
        </Route>

        <Route path='/400' element={<BadRequest />} />
        <Route path='*' element={<NotFound />} />
      </Routes>
    </Router>
  );
}


export default App;
