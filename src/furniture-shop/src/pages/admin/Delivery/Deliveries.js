import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import { Link } from "react-router-dom";
import Loading from "../../../components/Loading";
import { DeleteDelivey, getDeliveries, getDelveriesFilter } from "../../../Services/Repository";
import DeliveryFilterPane from "../../../components/admin/DeliveryFilterPane";
import { useSelector } from "react-redux";

const Deliveries = () => {
  const deliveriesFilter= useSelector((state)=> state.productFilter)

  const [deliveriesList, setDeliveriesList] = useState([]);
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);
  let k = "",
    p = 1,
    ps = 10;

    const handleDelete= (e, id)=> {
      e.preventDefault();
      DeleteAnDelivery(id);
      async function DeleteAnDelivery(id){
        if(window.confirm("Bạn có chắc xóa đơn này")){
          const response = await DeleteDelivey(id);
          if(!response)
            alert("Xóa thành công")
            else
            alert("Đã xảy ra lỗi khi xóa")
        }
      }
    }

    useEffect(() => {
    document.title = "Danh sách đơn";
    getDelveriesFilter(deliveriesFilter.keyword, ps, p).then((data) => {
      if (data) setDeliveriesList(data.items);
      else setDeliveriesList([]);
      setIsVisibleLoading(false);
    });
  }, [deliveriesFilter,k, ps, p]);
  console.log(deliveriesList.items);

  return (
    <>
      <h1>Danh sách đơn</h1>
      <DeliveryFilterPane/>
      {isVisibleLoading ? (
        <Loading />
      ) : (
        <Table striped responsive bordered>
          <thead>
            <tr>
              
              <th>Tên</th>
              <th>Slug</th>
              <th>Ngày</th>
              <th>Xóa</th>
            </tr>
          </thead>
          <tbody>
            {deliveriesList.length >= 0 ? (
              deliveriesList.map((item, index) => (
                <tr key={index}>
                  <td>
                    <Link
                      to={`/admin/deliveries/edit/${item.id}`}
                      className="text-bold"
                    >
                      {item.name}
                    </Link>
                  </td>
                 
                  <td>{item.urlSlug}</td>
                  <td>{item.date}</td>
                  <td>
                    <button
                      type="button"
                      className="btn btn-danger"
                      size='small'
                      onClick={(e)=>{ handleDelete(e, item.id)
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
                    Không tìm thấy đơn nào
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
export default Deliveries;