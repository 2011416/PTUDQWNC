import { useState, useEffect, useRef } from "react";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Link } from 'react-router-dom';
import { useSelector, useDispatch } from "react-redux";
import { reset, updateKeyword } from "../../redux/Redux";
import { getCategoriesFilter } from "../../Services/Repository";

const CategoryFilterPane = () => {
    // const postFilter = useSelector(state => state.postFilter),
    // dispatch = useDispatch(),
    // [filter, setFilter] = useState({} 
    const categoryFilter= useSelector((state)=> state.productFilter)
    const dispatch= useDispatch()

    const[filter, setFilter]= useState({})
    const handleReset = (e) => {
        dispatch(reset());
    }


    const handleSubmit = (e) => {
        e.preventDefault();
    };
    useEffect(()=>{
        getCategoriesFilter().then((data)=>{
            if(data){
                setFilter(data)
            }
            else{
                setFilter({})
            }
        })
    })

    return (
        <Form method="get"
        onSubmit={handleSubmit}
      className="row gy-2 gx-3 align-items-center p-2">
        <Form.Group className='col-auto'>
            <Form.Label className='visually-hidden'>
                Keyword
            </Form.Label>
            <Form.Control
                type='text'
                placeholder="Nhập từ khóa..."
                name="keyword"
                value={categoryFilter.keyword}
                onChange={e => dispatch(updateKeyword(e.target.value))} />                
        </Form.Group>     
        <Form.Group className='col-auto'>
            {/* <Button variant="primary" type='submit'>
                Tìm/Lọc
            </Button> */}
            <Button variant="warning mx-2" onClick={handleReset}>
                    Bỏ lọc
            </Button>
            <Link to='/admin/categories/edit' className='btn btn-success ms-2'>Thêm mới</Link>
            </Form.Group>
        </Form>
    );
}

export default CategoryFilterPane;

    
    