import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import { Link } from "react-router-dom";
import { DeleteProduct, getProductFilter } from "../../../Services/Repository";
import Loading from "../../../components/Loading";
import ProductFilterPane from "../../../components/admin/ProductFilterPane";
import { useSelector } from "react-redux";

const Products = () => {
  const [productsList, setProductsList] = useState([]),
  productFilter = useSelector((state) => state.productFilter);
console.log(productFilter);
  // const [filterData, setFilterData]= useState([])
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);
  let p=1, ps= 10
  const handleDelete= (e, id)=> {
    e.preventDefault();
    DeleteAnProduct(id);
    async function DeleteAnProduct(id){
      if(window.confirm("Bạn có chắc xóa sản phẩm này")){
        const response = await DeleteProduct(id);
        if(!response)
          alert("Xóa thành công")
          else
          alert("Đã xảy ra lỗi khi xóa")
      }
    }
  }

  useEffect(() => {
    document.title = "Danh sách sản phẩm";
    
    getProductFilter(
   productFilter.keyword,ps,p
  
    ).then((data)  => { 
      if (data) 
        setProductsList(data.items);
      else setProductsList([]);
        setIsVisibleLoading(false);
    });

  }, [productFilter.keyword,productFilter, ps,p]);

  // function handleFilterChanges(newFilter){
  //   console.log('New filter', newFilter);
  //   setProductsList(
  //     {
  //       ...productsList,
  //     keyword: newFilter.keyword
  //     }
  //   )
  // }
  return (
    <>
      <h1>Danh sách sản phẩm</h1>
      <ProductFilterPane />
      {/* <ProductFilterTest onSubmit ={handleFilterChanges}/> */}
      {isVisibleLoading ? (
        <Loading />
      ) : (
        <Table striped responsive bordered>
          <thead>
            <tr>
              <th>Tiêu đề</th>
              <th>Mô tả</th>         
              <th>Giá</th>
              <th>Xóa</th>
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
                      onClick={(e)=> handleDelete(e, item.id)}
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
