import { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Link, Navigate, useNavigate, useParams } from "react-router-dom";

import { decode, isInteger } from "../../../utils/Utiles";

import {
  AddOrUpdateDelivery,
  GetDeliveryById,
} from "../../../Services/Repository";

const DeliveryEdit = () => {
  const initialState = {
    id: 0,
    name: "",
    urlSlug: "",
    date: "",
    selectDeliveries: "",
  };

  const [delivery, setDelivery] = useState(initialState);

  let { id } = useParams();
  id = id ?? 0;

  useEffect(() => {
    document.title = "Thêm/cập nhật đơn";
    GetDeliveryById(id).then((data) => {
      if (data) {
        setDelivery({
          ...data,
        });
      } else {
        setDelivery(initialState);
      }
    });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
      let form = new FormData(e.target);
      AddOrUpdateDelivery(form).then((data) => {
        console.log(data);
        if (data) alert("Lưu thành công!");
        else alert("Đã xảy ra lỗi!!");
      });
    }

  if (id && !isInteger(id))
    return <Navigate to={`/400?redirectTo=/admin/deliveries`} />;

  return (
    <>
      <h1 className="px-4 py-3 text-danger">Thêm/cập nhật đơn</h1>
      <Form
        method="post"
        encType="multipart/form-data"
        onSubmit={handleSubmit}
        noValidate
        className="mb-5 px-4"
      >
        <Form.Control type="hidden" name="id" value={delivery.id} />
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">Tên</Form.Label>
          <div className="col-sm-10">
            <Form.Control
              type="text"
              name="name"
              required
              value={delivery.name || ""}
              onChange={(e) =>
                setDelivery({
                  ...delivery,
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
          <Form.Label className="col-sm-2 col-form-label">Slug</Form.Label>
          <div className="col-sm-10">
            <Form.Control
              type="text"
              name="urlSlug"
              title="Url slug"
              required
              value= {delivery.urlSlug|| ''}
              onChange={e=> setDelivery({
                ...delivery,
                urlSlug: e.target.value
              })}
            />
            <Form.Control.Feedback type="invalid">
              Không được bỏ trống
            </Form.Control.Feedback>
          </div>
        </div>
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">Thời gian</Form.Label>
          <div className="col-sm-10">
            <Form.Control as="textarea" type="text" name="date" title="date"
             required
             value= {delivery.date|| ''}
             onChange={e=> setDelivery({
               ...delivery,
               date: e.target.value
             })}
             />
          </div>
        </div>
        <div className="text-center">
          <Button variant="primary" type="submit">
            Lưu các thay đổi
          </Button>
          <Link to="/admin/deliveries" className="btn btn-danger ms-2">
            Hủy và quay lại
          </Link>
        </div>
      </Form>
    </>
  );
};
export default DeliveryEdit;
