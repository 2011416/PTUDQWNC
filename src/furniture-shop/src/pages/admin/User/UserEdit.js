import { useEffect, useState } from 'react';
import { Button, Form } from 'react-bootstrap';
import { Link, Navigate, useNavigate, useParams } from 'react-router-dom';

import { decode, isInteger } from '../../../utils/Utiles';

import { getUsers } from '../../../Services/Repository';

const UserEdit = () => {

    const initialState = {
        id: 0,
        name: '',
        urlSlug: '',
        email: '',
        address: '',
        phoneNumber:'',
        roleId: ''
    };

    const [category, setCategory] = useState(initialState);

    const { id } = useParams();

   
    useEffect(() => {
        document.title = 'Thêm/cập nhật chủ đề';
    }, []);

    return (
        <>
            <h1 className="px-4 py-3 text-danger">Thêm/cập nhật chủ đề</h1>
            <Form className="mb-5 px-4">
                <Form.Control type="hidden" name="id" value={category.id} />
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Tên</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            type="text"
                            name="name"
                            required
                        />
                        <Form.Control.Feedback type="invalid">Không được bỏ trống</Form.Control.Feedback>
                    </div>
                </div>
                 <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">email</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            type="text"
                            name="email"
                            title="email"
                            required
                        />
                        <Form.Control.Feedback type="invalid">Không được bỏ trống</Form.Control.Feedback>
                    </div>
                </div>
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Địa chỉ</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            type="text"
                            name="address"
                            title="address"
                            required
                        />
                        <Form.Control.Feedback type="invalid">Không được bỏ trống</Form.Control.Feedback>
                    </div>
                </div>
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Slug</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            type="text"
                            name="urlSlug"
                            title="Url slug"
                            required
                        />
                        <Form.Control.Feedback type="invalid">Không được bỏ trống</Form.Control.Feedback>
                    </div>
                </div>
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Số điện thoại</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            as="textarea"
                            type="text"
                            name="phoneNumber"
                            title="phoneNumber"
                        />
                    </div>
                </div>  
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Vai trò</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            as="textarea"
                            type="text"
                            name="roleId"
                            title="roleId"
                        />
                    </div>
                </div>                         
                <div className="text-center">
                    <Button variant="primary" type="submit">
                        Lưu các thay đổi
                    </Button>
                    <Link to="/admin/categories" className="btn btn-danger ms-2">
                        Hủy và quay lại
                    </Link>
                </div>
            </Form>
        </>
    );
}
export default UserEdit;