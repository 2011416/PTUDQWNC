import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import { Link } from "react-router-dom";
import { DeleteUser, getUserFilter } from "../../../Services/Repository";
import Loading from "../../../components/Loading";
import UserFilterPane from "../../../components/admin/UserFilterPane";
import { useSelector } from "react-redux";

const Users = () => {
  const [usersList, setUsersList] = useState([]);
  const userFilter = useSelector((state)=> state.productFilter)
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);
  let k = "", p = 1, ps = 10;

  const handleDelete= (e, id)=> {
    e.preventDefault();
    DeleteAnUser(id);
    async function DeleteAnUser(id){
      if(window.confirm("Bạn có chắc xóa người dùng này")){
        const response = await DeleteUser(id);
        if(!response)
          alert("Xóa thành công")
          else
          alert("Đã xảy ra lỗi khi xóa")
      }
    }
  }

  useEffect(() => {
    document.title = "Danh sách tài khoản";
    getUserFilter(userFilter.keyword,ps, p).then((data) => {
      if (data) 
      setUsersList(data.items);
      else setUsersList([]);
      setIsVisibleLoading(false);
    });
  }, [userFilter.keyword, userFilter,k, ps,p]);

  return (
    <>
      <h1>Danh sách tài khoản </h1>
      <UserFilterPane />
      {isVisibleLoading ? (
        <Loading />
      ) : (
        <Table striped responsive bordered>
          <thead>
            <tr>
              <th>Tên</th>
              <th>Email</th>
              <th>Địa chỉ</th>
              <th>Số điện thoại</th>
              <th>Slug</th>
              <th>Xóa</th>
            </tr>
          </thead>
          <tbody>
            {usersList.length > 0 ? (
              usersList.map((item, index) => (
                <tr key={index}>
                  <td>
                    <Link
                      to={`/admin/users/edit/${item.id}`}
                      className="text-bold"
                    >
                      {item.name}
                    </Link>
                    <p className="text-muted">{item.name}</p>
                  </td>
                  <td>{item.email}</td>
                  <td>{item.adress}</td>
                  <td>{item.phoneNumber}</td>
                  <td>{item.urlSlug}</td>
                  <td>
                    <button
                      type="button"
                      className="btn btn-danger"
                      size="small"
                      onClick={(e)=> {handleDelete(e, item.id)
                      window.location.reload(false)
                      }}
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
                    Không tìm thấy tài khoản nào
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

export default Users;