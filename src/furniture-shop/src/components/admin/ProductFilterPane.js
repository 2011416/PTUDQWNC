import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { reset, updateKeyword } from "../../redux/Redux";
import { getProductFilter } from "../../Services/Repository";
import { Button, Form } from "react-bootstrap";
import { Link } from "react-router-dom";



const ProductFilterPane = () => {
  const productFilter = useSelector((state) => state.productFilter),
    dispatch = useDispatch(),
    [filter, setFilter] = useState({
    });
  const handleReset = (e) => {
    dispatch(reset());
  };


  useEffect(() => {
    getProductFilter().then((data) => {
      if (data) {
        setFilter(
        data);
      } else {
        setFilter({
        });
      }
    });
  }, []);
  return (
    <Form method='get'
    onReset={handleReset}
    className='row gy-2 gx-3 align-items-center p-2'>
    <Form.Group className='col-auto'>
    <Form.Label className='visually-hidden'>
    Keyword
    </Form.Label>
    <Form.Control
    type='text'
    placeholder='Nhập từ khóa...'
    name='keyword'
    value={productFilter.keyword}
    onChange={e => dispatch(updateKeyword(e.target.value))} />
    </Form.Group>
   
    
    <Form.Group className='col-auto'>
    <Button variant='danger' type='reset'>
    Xóa lọc
    </Button>
    <Link to='/admin/products/edit' className='btn btn-success ms-2'>Thêm
    mới</Link>
    </Form.Group>
    </Form>
    );
    }
export default ProductFilterPane;
