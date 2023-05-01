import React, {useEffect, useState } from "react";
import Table from 'react-bootstrap/Table';
import { Link, useParams, Navigate } from 'react-router-dom';
import { getUsers } from "../../Services/Repository";
import Loading from "../../components/Loading";

const Users = () => {
    const [usersList, setUsersList] = useState([]);
    const [isVisibleLoading, setIsVisibleLoading] = useState(true);

    useEffect(() => {
        document.title = 'Danh sách tài khoản';

        getUsers().then((data) => {
            if (data) 
                setUsersList(data.items);
            else 
                setUsersList([]);
            setIsVisibleLoading(false);
        });
    }, []);

    return (
        <>
            <h1>Danh sách tài khoản </h1>
            {isVisibleLoading ? <Loading /> :
                <Table striped responsive bordered>
                    <thead>
                        <tr>
                            <th>Tên</th>
                            <th>Email</th>
                            <th>Số điện thoại</th>
                            <th>Địa chỉ</th>
                        </tr>
                    </thead>
                    <tbody>
                        {usersList.length > 0 ? usersList.map((item, index) => 
                                <tr key={index}>
                                    <td>
                                        <Link to={`/admin/users/edit/${item.id}`} 
                                        className='text-bold'>
                                            {item.name}
                                        </Link>
                                        <p className="text-muted">{item.name}</p>
                                    </td>
                                    <td>{item.email}</td>
                                    <td>{item.address}</td>
                                    <td>{item.phoneNumber}</td>
                                    <td>{item.urlSlug}</td>
                                </tr>
                            ) : 
                            <tr>
                                <td colSpan={4}>
                                    <h4 className="text-danger text-center">Không tìm thấy tài khoản nào</h4>
                                </td>
                            </tr>}
                    </tbody>
                </Table>
            }
        </>
    );
}

export default Users;