import { useEffect, useState } from 'react';
import { Button, Form } from 'react-bootstrap';
import { Link, Navigate, useNavigate, useParams } from 'react-router-dom';

import { decode, isInteger } from '../../../utils/Utiles';

import { getProducts } from '../../../Services/Repository';

const ProductEdit = () => {

    const initialState = {
        id: 0,
        name: '',
        urlSlug: '',
        description: '',
        price: '',
        size: '',
        material: ''
    };

    const [product, setProduct] = useState(initialState);

    const { id } = useParams();

   
    useEffect(() => {
        document.title = 'Thêm/cập nhật sản phẩm';
    }, []);

    return (
        <>
            <h1 className="px-4 py-3 text-danger">Thêm/cập nhật sản phẩm</h1>
            <Form className="mb-5 px-4">
                <Form.Control type="hidden" name="id" value={product.id} />
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
                    <Form.Label className="col-sm-2 col-form-label">Giới thiệu</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            as="textarea"
                            type="text"
                            name="description"
                            title="description"
                        />
                    </div>
                </div>
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Giá</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            as="textarea"
                            type="text"
                            name="price"
                            title="price"
                        />
                    </div>
                </div>
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Kích thước</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            as="textarea"
                            type="text"
                            name="size"
                            title="size"
                        />
                    </div>
                </div>  
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Vật liệu</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            as="textarea"
                            type="text"
                            name="material"
                            title="material"
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
export default ProductEdit;