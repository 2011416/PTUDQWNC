import { useState, useEffect } from "react";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Link } from 'react-router-dom';
import { useSelector, useDispatch } from "react-redux";
import { reset } from "../../redux/Reducer";

const ProductFilterPane = () => {
    // const postFilter = useSelector(state => state.postFilter),
    // dispatch = useDispatch(),
    // [filter, setFilter] = useState({} 



    const current = new Date(),
    [keyword, setKeyword] = useState(''),
    [authorId, setAuthorId] = useState(''),
    [categoryId, setCategoryId] = useState(''),
    [year, setYear] = useState(current.getFullYear()),
    [month, setMonth] = useState(current.getMonth()),
    [postFilter, setPostFilter] = useState({
        authorList: [],
        categoryList: [],
        monthList: [],
    });

    const handleReset = (e) => {
        dispatchEvent(reset());
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    };

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
                value={keyword}
                onChange={e => setKeyword(e.target.value)} />                
        </Form.Group>
        {/* <Form.Group className='col-auto'>
            <Form.Label className='visually-hidden'>
                Year
            </Form.Label>
            <Form.Control
             type='number'
             placeholder='Nhập năm...'
             name='year'
             value={year}
             max={year}
             onChange={e => setYear(e.target.value)}
             />
        </Form.Group> */}
        {/* <Form.Group className='col-auto'>
            <Form.Label className='visually-hidden'>
                Month
            </Form.Label>
            <Form.Select
             name='month'
             value={month}
             onChange={e => setMonth(e.target.value)}
             title='Month'
            >
                <option value=''>-- Chọn tháng --</option>
                {postFilter.monthList.length > 0 &&
                 postFilter.monthList.map((item, index) =>
                 <option key={index} value={item.value}>{item.text}</option>
                 )}
            </Form.Select>
        </Form.Group> */}
        <Form.Group className='col-auto'>
            <Button variant="primary" type='submit'>
                Tìm/Lọc
            </Button>
            <Link to='/admin/products/edit' className='btn btn-success ms-2'>Thêm mới</Link>
            </Form.Group>
        </Form>
    );
}

export default ProductFilterPane;

    
    