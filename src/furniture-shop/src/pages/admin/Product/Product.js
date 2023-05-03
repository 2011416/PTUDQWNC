import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import { Link } from "react-router-dom";
import { getProductFilter, getProducts } from "../../../Services/Repository";
import Loading from "../../../components/Loading";
import ProductFilterPane from "../../../components/admin/ProductFilterPane";

const Products = () => {
  const [productsList, setProductsList] = useState([]);
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);
  let k = "", p = 1, ps = 3;


  useEffect(() => {
    document.title = "Danh sách sản phẩm";
    getProducts(k,ps, p).then((data)  => { 
      if (data) 
        setProductsList(data.items);
      else setProductsList([]);
        setIsVisibleLoading(false);
    });

  }, [k, ps,p]);

  return (
    <>
      <h1>Danh sách sản phẩm</h1>
      <ProductFilterPane/>
      {isVisibleLoading ? (
        <Loading />
      ) : (
        <Table striped responsive bordered>
          <thead>
            <tr>
              <th>Tiêu đề</th>
              <th>Mô tả</th>
           
              <th>Giá</th>
            </tr>
          </thead>
          <tbody>
            {
            productsList.length >=0 ? 
            (
              
              productsList.map((item, index) => (
                
                <tr key={index}>
                  <td>
                    <Link
                      to={`/admin/products/edit/${item.id}`}
                      className="text-bold"
                    >
                      {item.name}
                    </Link>
                   
                  </td>
                <td> <p className="text-muted">{item.description}</p></td>
                  <td>{item.price}</td>
                  <td>
                    <button
                      type="button"
                      className="btn btn-danger"
                      size='small'
                    >
                      Xóa
                    </button>
                  </td>
                </tr>
              ))
            ) 
            : (
              <tr>
                <td colSpan={4}>
                  <h4 className="text-danger text-center">
                    Không tìm thấy sản phẩm nào
                  </h4>
                </td>
              </tr>
            )
            }
          </tbody>
        </Table>
      )}
    </>
  );
};
export default Products;
