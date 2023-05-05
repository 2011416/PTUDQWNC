import { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Link, Navigate, useNavigate, useParams } from "react-router-dom";

import { decode, isInteger } from "../../../utils/Utiles";

import { AddOrUpdatedUser, GetUserById } from "../../../Services/Repository";

const UserEdit = () => {
  const initialState = {
    id: 0,
    name: "",
    urlSlug: "",
    email: "",
    address: "",
    phoneNumber: "",
  };

  const [user, setUser] = useState(initialState);

  let { id } = useParams();
  id = id ?? 0;

  useEffect(() => {
    document.title = "Thêm/cập nhật người dùng";
    GetUserById(id).then((data) => {
      if (data) {
        setUser({
          ...data,
        });
      } else {
        setUser(initialState);
      }
    });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    let form = new FormData(e.target);
    AddOrUpdatedUser(form).then((data) => {
      if (data) alert("Lưu thành công!");
      else alert("Đã xảy ra lỗi!!");
    });
  };

  if (id && !isInteger(id))
    return <Navigate to={`/400?redirectTo=/admin/users`} />;

  return (
    <>
      <h1 className="px-4 py-3 text-danger">Thêm/cập nhật người dùng</h1>
      <Form
        className="mb-5 px-4"
        method="post"
        encType="multipart/form-data"
        onSubmit={handleSubmit}
      >
        <Form.Control type="hidden" name="id" value={user.id} />
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">Tên</Form.Label>
          <div className="col-sm-10">
            <Form.Control
              type="text"
              name="name"
              required
              value={user.name || ""}
              onChange={(e) =>
                setUser({
                  ...user,
                  name: e.target.value,
                })
              }
            />
            <Form.Control.Feedback type="invalid">
              Không được bỏ trống
            </Form.Control.Feedback>
          </div>
        </div>
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">Email</Form.Label>
          <div className="col-sm-10">
            <Form.Control
              type="text"
              name="email"
              title="email"
              required
              value={user.urlSlug || ""}
              onChange={(e) =>
                setUser({
                  ...user,
                  urlSlug: e.target.value,
                })
              }
            />
            <Form.Control.Feedback type="invalid">
              Không được bỏ trống
            </Form.Control.Feedback>
          </div>
        </div>
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">Địa chỉ</Form.Label>
          <div className="col-sm-10">
            <Form.Control type="text" name="address" title="address" required
            value={user.adress || ""}
            onChange={(e) =>
              setUser({
                ...user,
                adress: e.target.value,
              })
            } />
            <Form.Control.Feedback type="invalid">
              Không được bỏ trống
            </Form.Control.Feedback>
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
              value={user.urlSlug || ""}
              onChange={(e) =>
                setUser({
                  ...user,
                  urlSlug: e.target.value,
                })
              }
            />
            <Form.Control.Feedback type="invalid">
              Không được bỏ trống
            </Form.Control.Feedback>
          </div>
        </div>
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">
            Số điện thoại
          </Form.Label>
          <div className="col-sm-10">
            <Form.Control
              as="textarea"
              type="text"
              name="phoneNumber"
              title="phoneNumber"
              value={user.phoneNumber || ""}
              onChange={(e) =>
                setUser({
                  ...user,
                  phoneNumber: e.target.value,
                })
              }
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
};
export default UserEdit;
