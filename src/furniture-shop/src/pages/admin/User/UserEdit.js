import { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Link, Navigate, useNavigate, useParams } from "react-router-dom";

import { decode, isInteger } from "../../../utils/Utiles";

import { AddOrUpdatedUser, GetUserById } from "../../../Services/Repository";

const UserEdit = () => {

    const initialState = {
        id: 0,
        name: '',
        urlSlug: '',
        email: '',
        adress: '',
        phoneNumber:'',
        roleId: '',
        password:''
    };

    const [user, setUser] = useState(initialState);
  const [validated, setValidated]= useState(false);

    let { id } = useParams();
    id= id??0;
   
    useEffect(() => {
        document.title = 'Thêm/cập nhật người dùng';
        GetUserById(id).then((data)=> {
            if(data){
                setUser({
                    ...data

                })
            }
            else{
                setUser(initialState)
            }
        })
    }, []);
     const handleSubmit = (e) => {
    e.preventDefault();
   if(e.currentTarget.checkValidity() ===false){
    e.StopPropagation();
      setValidated(true);
   }

    else{
      let form = new FormData(e.target);
      console.log(form)
    AddOrUpdatedUser(form).then((data) => {
        console.log(data)
        if(data)
            alert('Lưu thành công!');
        else
            alert('Đã xảy ra lỗi!!');
    }).catch(err=> console.error(err));
    }
    
}

if(id&& !isInteger(id))
    return(
        <Navigate to = {`/400?redirectTo=/admin/products`}/>
         
    )

    return (
        <>
            <h1 className="px-4 py-3 text-danger">Thêm/cập nhật người dùng</h1>
            <Form 
            method='post'
            encType="multipart/form-data" 
            onSubmit={handleSubmit} noValidate validated={validated}
            className="mb-5 px-4">
                <Form.Control type="hidden" name="id" value={user.id} />
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">Tên</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            type="text"
                            name="name"
                            required
                            value={user.name|| ''}
                            onChange={e=> setUser({
                                ...user,
                                name: e.target.value
                            })}
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
                            value={user.email}
                            onChange={e=> setUser(
                                {
                                    ...user,
                                email: e.target.value
                                }
                            )}
                            required
                        />
                        <Form.Control.Feedback type="invalid">Không được bỏ trống</Form.Control.Feedback>
                    </div>
                </div>
                <div className="row mb-3">
                    <Form.Label className="col-sm-2 col-form-label">password</Form.Label>
                    <div className="col-sm-10">
                        <Form.Control
                            type="text"
                            name="password"
                            title="password"
                            value={user.password}
                            onChange={e=> setUser(
                                {
                                    ...user,
                                password: e.target.value
                                }
                            )}
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
                            value={user.adress}
                            onChange={e=> setUser({
                                ...user,
                                adress: e.target.value
                            })}
                        
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
                            value={user.urlSlug}
                            onChange={e=> setUser(
                                {
                                    ...user,
                                    urlSlug: e.target.value
                                }
                            )}
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
                            value={user.phoneNumber}
                            onChange={e=> setUser(
                                {
                                    ...user,
                                    phoneNumber: e.target.value
                                }
                            )}

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
                            value={user.roleId}
                            onChange={e=> setUser(
                                {
                                    ...user,
                                    roleId: e.target.value
                                }
                            )}
                        />
                    </div>
                </div>                         
                <div className="text-center">
                    <Button variant="primary" type="submit">
                        Lưu các thay đổi
                    </Button>
                    <Link to="/admin/users" className="btn btn-danger ms-2">
                        Hủy và quay lại
                    </Link>
                </div>
            </Form>
        </>
    );
}
export default UserEdit;
