import { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Link, Navigate, useNavigate, useParams } from "react-router-dom";

import { decode, isEmptyOrSpaces, isInteger } from "../../../utils/Utiles";

import { AddOrUpdatedProduct, GetProductById } from "../../../Services/Repository";

const ProductEdit = () => {
  const initialState = {
    id: 0,
    name: "",
    urlSlug: "",
    description: "",
    price: "",
    size: "",
    material: "",
    selectCategories: "",
    urlImage:"",
    collection:"",
    imageFile:"",
    userId:0
  };

  const [product, setProduct] = useState(initialState);

  let { id } = useParams();
  id = id ?? 0;

  useEffect(() => {
    document.title = "Thêm/cập nhật sản phẩm";
    GetProductById(id).then((data)=> {
        if(data){
            setProduct({
                ...data,
                selectCategories: data.categories.map(cate=> cate?.name).join('\r\n'),

            })
        }
        else{
                setProduct(initialState);
        }
    })
    
  }, []);
  const [validated, setValidated]= useState(false);
 
  const handleSubmit = (e) => {
    e.preventDefault();
   if(e.currentTarget.checkValidity() ===false){
    // e.StopPropagation();
      setValidated(true);
   }

    else{
      let form = new FormData(e.target);
    AddOrUpdatedProduct(form).then(data => {
        console.log(data)
        if(data)
            alert('Lưu thành công!');
        else
            alert('Đã xảy ra lỗi!!');
    });
    }
    
}
if(id&& !isInteger(id))
    return(
        <Navigate to = {`/400?redirectTo=/admin/products`}/>
         
    )

  return (
    <>
      <h1 className="px-4 py-3 text-danger">Thêm/cập nhật sản phẩm</h1>
      <Form 
      method="post"
      encType="multipart/form-data"
      onSubmit={handleSubmit} noValidate validated={validated}
      className="mb-5 px-4">
        <Form.Control type="hidden" name="id" value={product.id} />
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">Tên</Form.Label>
          <div className="col-sm-10">
            <Form.Control type="text" name="name" required 
            value={product.name|| ''} 
            onChange={e=> setProduct({
                ...product,
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
              value= {product.urlSlug|| ''}
              onChange={e=> setProduct({
                ...product,
                urlSlug: e.target.value
              })}
            />
            
            <Form.Control.Feedback type="invalid">
              Không được bỏ trống
            </Form.Control.Feedback>
          </div>
        </div>
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">UserId</Form.Label>
          <div className="col-sm-10">
            <Form.Control
              type="text"
              name="UserID"
              title="User ID"
              required
              value= {product.userId|| ''}
              onChange={e=> setProduct({
                ...product,
                userId: e.target.value
              })}
            />
            
            <Form.Control.Feedback type="invalid">
              Không được bỏ trống
            </Form.Control.Feedback>
          </div>
        </div>
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">collection</Form.Label>
          <div className="col-sm-10">
            <Form.Control
              type="text"
              name="collection"
              title="Collection"
              required
              value= {product.collection|| ''}
              onChange={e=> setProduct({
                ...product,
                collection: e.target.value
              })}
            />
            
            <Form.Control.Feedback type="invalid">
              Không được bỏ trống
            </Form.Control.Feedback>
          </div>
        </div>
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">
            Giới thiệu
          </Form.Label>
          <div className="col-sm-10">
            <Form.Control
              as="textarea"
              type="text"
              name="description"
              title="description"
              value={decode(product.description|| '')}
              onChange={e=> setProduct({
                ...product,
                description: e.target.value
              })}
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
              value={product.price||''}
              onChange={e=> setProduct({
                ...product,
                price: e.target.value
              })}
            />
          </div>
        </div>
        <div className="row mb-3">
          <Form.Label className="col-sm-2 col-form-label">
            Kích thước
          </Form.Label>
          <div className="col-sm-10">
            <Form.Control as="textarea" type="text" name="size" title="size" 
            value={product.size|| ''}
            onChange={e=> setProduct({
                ...product,
                size: e.target.value
            })}
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
              value={product.material||''}
              onChange={e=> setProduct({
                ...product,
                material: e.target.value
              })}
            />
          </div>
        </div>
        <div className='row mb-3'>
                  <Form.Label className='col-sm-2 col-form-label'>
                      Loại
                  </Form.Label>
                  <div className='col-sm-10'>
                      <Form.Control 
                          as={'textarea'}
                          rows={5}
                          type='text'
                          required
                          name='selectedCategories'
                          title='Selected Categories'
                          value={product.selectCategories || ''}
                          onChange={e => setProduct({
                              ...product,
                              selectCategories: e.target.value
                          })}/>
                  </div>
              </div>

              {!isEmptyOrSpaces(product.urlImage) && <div className="row mb-3">
                <Form.Label className="col-sm-2 col-form-label">
                    Hình hiện tại
                </Form.Label>
                <div className="col-sm-10">
                <img src={product.urlImage} alt={product.name}/>

                </div>
                    

                </div>}
                <div className='row mb-3'>
                  <Form.Label className='col-sm-2 col-form-label'>
                      Chọn hình ảnh
                  </Form.Label>
                  <div className='col-sm-10'>
                      <Form.Control
                          type='file'
                          name='imageFile'
                          accept='image/*'
                          title='Image File'
                          onChange={(e) => {
                            const file = e.target.files[0];
                            setProduct({
                              ...product,
                              urlImage: URL.createObjectURL(file)
                          })
                          }}/>
                  </div>
                  </div>
        <div className="text-center">
          <Button variant="primary" type="submit">
            Lưu các thay đổi
          </Button>
          <Link to="/admin/products" className="btn btn-danger ms-2">
            Hủy và quay lại
          </Link>
        </div>
      </Form>
    </>
  );
};
export default ProductEdit;
