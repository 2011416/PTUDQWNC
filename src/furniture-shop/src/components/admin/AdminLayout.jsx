import { Outlet } from "react-router-dom";
import Navbar from "./Navbar"

const AdminLayout = () => {
  return (
    <>
      <Navbar />
      <div className="container">
        <div className="main">
          <Outlet />
        </div>
      </div>
    </>
  );
};

export default AdminLayout;
