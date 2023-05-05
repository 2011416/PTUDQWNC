import { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Link, Navigate, useNavigate, useParams } from "react-router-dom";

import { decode, isInteger } from "../../../utils/Utiles";

import {
  AddOrUpdatedCategory,
  GetCategoryById,
} from "../../../Services/Repository";

const CategoryEdit = () => {
  const initialState = {
    id: 0,
    name: "",
    urlSlug: "",
    description: "",
  };

  const [category, setCategory] = useState(initialState);

  let { id } = useParams();
  id = id ?? 0;

  useEffect(() => {
    document.title = "Thêm/cập nhật chủ đề";
    GetCategoryById(id).then((data) => {
      if (data) {
        setCategory({
          ...data,
        });
      } 
      else {
        setCategory(initialState);
      }
    })
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
      let form = new FormData(e.target);
      AddOrUpdatedCategory(form).then((data) => {
        console.log(data);
        if (!data) 
            alert("Lưu thành công!");
        else 
            alert("Đã xảy ra lỗi!!");
      });
    }

  if (id && !isInteger(id))
    return <Navigate to={`/400?redirectTo=/admin/categories`} />;

  return (
    <>
      <h1 className="px-4 py-3 text-danger">Thêm/cập nhật chủ đề</h1>
      <Form
        method="post"
        encType="multipart/form-data"
        onSubmit={handleSubmit}
        className="mb-5 px-4"
      >
        <Form.Control type="hidden" name="id" value={category.id} />
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">Tên</Form.Label>
          <div className="col-sm-10">
            <Form.Control
              type="text"
              name="name"
              required
              value={category.name || ""}
              onChange={(e) =>
                setCategory({
                  ...category,
                  name: e.target.value
                })}/>
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
              value={category.urlSlug || ""}
              onChange={(e) =>
                setCategory({
                  ...category,
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
          <Form.Label className="col-sm-2 col-form-label">Mô tả</Form.Label>
          <div className="col-sm-10">
            <Form.Control
              as="textarea"
              type="text"
              name="description"
              title="description"
              value={category.description|| ''}
              onChange={e=> setCategory({
                ...category,
                description: e.target.value
              })}/>
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
};
export default CategoryEdit;
