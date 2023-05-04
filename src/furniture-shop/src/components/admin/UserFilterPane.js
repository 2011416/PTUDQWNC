import { useState, useEffect, useRef } from "react";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Link } from 'react-router-dom';
import { useSelector, useDispatch } from "react-redux";
import { reset } from "../../redux/Reducer";

const months = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

const UserFilterPane = () => {
    // const postFilter = useSelector(state => state.postFilter),
    // dispatch = useDispatch(),
    // [filter, setFilter] = useState({} 


    const keywordRef = useRef();
    const yearRef = useRef();
    const monthRef = useRef();

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

    const handleClearFilter = () => {
        setKeyword('');
        setYear('');
        setMonth('');
        monthRef.current.value = '';
    };

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
        <Form.Group className='col-auto'>
            <Form.Label className='visually-hidden'>
                AuthorId
            </Form.Label>
            <Form.Select name='authorId'
                value={authorId}
                onChange={e => setAuthorId(e.target.value)}
                title='Author Id'
            >
             <option value=''>-- Chọn người dùng --</option>
              {postFilter.authorList.length > 0 && 
              postFilter.authorList.map((item, index) =>
               <option key={index} value={item.value}>{item.text}</option>
              )}  
            </Form.Select>          
        </Form.Group>
        <Form.Group className='col-auto'>
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
        </Form.Group>
        <Form.Group className="col-auto">
                <Form.Label className="visually-hidden">Tháng</Form.Label>
                <Form.Select ref={monthRef} title="Tháng" name="month">
                    <option value="">-- Chọn tháng --</option>
                    {months.map((month) => (
                        <option key={month} value={month}>
                            Tháng {month}
                        </option>
                    ))}
                </Form.Select>
        </Form.Group>
        <Form.Group className='col-auto'>
            <Button variant="primary" type='submit'>
                Tìm/Lọc
            </Button>
            <Button variant="warning mx-2" onClick={handleClearFilter}>
                    Bỏ lọc
            </Button>
            <Link to='/admin/users/edit' className='btn btn-success ms-2'>Thêm mới</Link>
            </Form.Group>
        </Form>
    );
}

export default UserFilterPane;

    
    