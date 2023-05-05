import { useState, useEffect, useRef } from "react";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Link } from 'react-router-dom';
import { useSelector, useDispatch } from "react-redux";
import { reset, updateUserId } from "../../redux/Reducer";
import { getProductFilter } from "../../Services/Repository";

const ProductFilterPane = () => {
    const productFilter = useSelector((state) => state.productFilter),
    dispatch = useDispatch()
    // [filter, setFilter] = useState({} 

    const keywordRef = useRef();
    const [filter, setFilter] = useState({
        userList:[]
    });
    const current = new Date(),
    [keyword, setKeyword] = useState('')

    const handleClearFilter = () => {
        setKeyword('');
    };

    const handleReset = (e) => {
        dispatchEvent(reset());
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    };
    useEffect(() => {
        getProductFilter().then((data) => {
            if(data){
                setFilter({
                    userList: data.userId
                })
            }else{
                setFilter({
                    userList:[]
                })
        }}
        )    })

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
                value={productFilter.keyword}
                onChange={e => dispatch(setKeyword(e.target.value))} />                
        </Form.Group>  
        
        {/* <Form.Group className='col-auto'>
    <Form.Label className='visually-hidden'>
    CategoryId
    </Form.Label>
    <Form.Select name='userId'
    value={productFilter.userId}
    onChange={e => dispatch(updateUserId(e.target.value))}
    title='user Id'
    >
    <option value=''>-- Chọn người dùng --</option>
    {filter.userList.length > 0 &&
    filter.userList.map((item, index) =>
    <option key={index} value={item.value}>{item.text}</option>

    )}
    </Form.Select>
    </Form.Group>    
        <Form.Group className='col-auto'>
            <Button variant="primary" type='submit'>
                Tìm/Lọc
            </Button>
            <Button variant="warning mx-2" onClick={handleClearFilter}>
                    Bỏ lọc
            </Button>
            <Link to='/admin/products/edit' className='btn btn-success ms-2'>Thêm mới</Link>
            </Form.Group> */}
        </Form>
    );
}

export default ProductFilterPane;

    
    