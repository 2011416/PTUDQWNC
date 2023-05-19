import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import { Link } from "react-router-dom";
import { deleteCategory, getCategories } from "../../../Services/Repository";
import Loading from "../../../components/Loading";
import CategoryFilterPane from "../../../components/admin/CategoryFilterPane";
import { DeleteCategory } from "../../../Services/Repository";

const Categories = () => {
  const [categoriesList, setCategoriesList] = useState([]);
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);
  let k = "",
    p = 1,
    ps = 10;

    const handleDelete= (e, id)=> {
      e.preventDefault();
      DeleteAnCategory(id);
      async function DeleteAnCategory(id){
        if(window.confirm("Bạn có chắc xóa chủ đề này")){
          const response = await DeleteCategory(id);
          if(!response)
            alert("Xóa thành công")
            else
            alert("Đã xảy ra lỗi khi xóa")
        }
      }
    }

  useEffect(() => {
    document.title = "Danh sách chủ đề";
    getCategories(k, ps, p).then((data) => {
      if (data) 
      setCategoriesList(data.items);
      else setCategoriesList([]);
      setIsVisibleLoading(false);
    });
  }, [categoriesList,k, ps, p]);

  return (
    <>
      <h1>Danh sách chủ đề</h1>
      <CategoryFilterPane />
      {isVisibleLoading ? (
        <Loading />
      ) : (
        <Table striped responsive bordered>
          <thead>
            <tr>
              <th>Tiêu đề</th>
              <th>Mô tả</th>
              <th>Slug</th>
              <th>Xóa</th>
            </tr>
          </thead>
          <tbody>
            {categoriesList.length >= 0 ? (
              categoriesList.map((item, index) => (
                <tr key={index}>
                  <td>
                    <Link
                      to={`/admin/categories/edit/${item.id}`}
                      className="text-bold"
                    >
                      {item.name}
                    </Link>
                  </td>
                  <td>
                    {" "}
                    <p className="text-muted">{item.description}</p>
                  </td>
                  <td>{item.urlSlug}</td>
                  <td>
                    <button
                      type="button"
                      className="btn btn-danger"
                      size='small'
                      onClick={(e)=> handleDelete(e, item.id)}
                    >
                      Xóa
                    </button>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={4}>
                  <h4 className="text-danger text-center">
                    Không tìm thấy chủ đề nào
                  </h4>
                </td>
              </tr>
            )}
          </tbody>
        </Table>
      )}
    </>
  );
};
export default Categories;
