import React from "react";
import { Navbar as Nb, Nav } from "react-bootstrap";
import { Link } from "react-router-dom";
const Navbar = () => {
  return (
    <Nb
      collapseOnSelect
      expand="sm"
      bg="white"
      variant="light"
      className="border-bottom shadow"
    >
      <div className="container-fluid">
        <Nb.Brand href="/admin">admin FurnitureShop</Nb.Brand>
        <Nb.Toggle aria-controls="responsive-navbar-nav" />
        <Nb.Collapse
          id="responsive-navbar-nav"
          className="d-sm-inline-flex
justify-content-between"
        >
          <Nav className="mr-auto flex-grow-1">
            <Nav.Item>
              <Link to="/admin/categories" className="nav-link text-dark">
                Chủ đề
              </Link>
            </Nav.Item>
            <Nav.Item>
              <Link to="/admin/producers" className="nav-link text-dark">
                Nhà sản xuất
              </Link>
            </Nav.Item>
            <Nav.Item>
              <Link to="/admin/tags" className="nav-link text-dark">
                Thẻ
              </Link>
            </Nav.Item>
            <Nav.Item>
              <Link to="/admin/products" className="nav-link text-dark">
                Sản phẩm
              </Link>
            </Nav.Item>
          </Nav>
        </Nb.Collapse>
      </div>
    </Nb>
  );
};

export default Navbar;
