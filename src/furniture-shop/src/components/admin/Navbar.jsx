import React from "react";
import { Navbar as Nb, Nav } from 'react-bootstrap';
import {
    Link
} from 'react-router-dom';

const Navbar = () => {
    return (
        <Nb collapseOnSelect expand='sm' bg='white' variant='light'
        className='border-bottom shadow'>
            <div className='container-fluid'>
				<Nb.Brand href='/admin'>Admin FurnitureShop</Nb.Brand>
				<Nb.Toggle aria-controls='responsive-navbar-nav' />
				<Nb.Collapse id='responsive-navbar-nav'
					className='d-sm-inline-flex justify-content-between'>
					<Nav className='mr-auto flex-grow-1'>
						<Nav.Item>
							<Link
								to='/admin/categories' className='nav-link text-dark'>
								Chủ đề
							</Link>
						</Nav.Item>
						<Nav.Item>
							<Link
								to='/admin/users' className='nav-link text-dark'>
								Tài khoản
							</Link>
						</Nav.Item>
						<Nav.Item>
							<Link to='/admin/products'
								className='nav-link text-dark'>
								Sản phẩm
							</Link>
						</Nav.Item>
						<Nav.Item>
							<Link to='/admin/deliveries'
								className='nav-link text-dark'>
								Đơn
							</Link>
						</Nav.Item>	
						<Nav.Item>
						<div className="header__menu__right">
                         <div className="header__menu__item header__menu__right__item">
                            <Link to="/login">
                          <i className="bx bx-user">Đăng nhập</i>
                            </Link>
                         </div>
                     </div>
						</Nav.Item>									
					</Nav>
				</Nb.Collapse>
			</div>
        </Nb>
    )
}

export default Navbar;
		