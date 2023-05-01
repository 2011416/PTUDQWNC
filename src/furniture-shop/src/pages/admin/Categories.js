import React, {useEffect, useState } from "react";
import Table from 'react-bootstrap/Table';
import { Link } from 'react-router-dom';
import { getCategories } from "../../Services/Repository";
import Loading from "../../components/Loading";
import CategoryFilterPane from "../../components/admin/CategoryFilterPane";

const Categories = () => {
    const [categoriesList, setCategoriesList] = useState([]);
    const [isVisibleLoading, setIsVisibleLoading] = useState(true);

    useEffect(() => {
        document.title = 'Danh sách chủ đề';

        getCategories().then((data) => {     
            if (data) 
                setCategoriesList(data.items);
            else 
                setCategoriesList([]);
            setIsVisibleLoading(false);
        });
    }, []);

    return (
        <>
            <h1>Danh sách chủ đề </h1>
            <CategoryFilterPane />
            {isVisibleLoading ? <Loading /> :
                <Table striped responsive bordered>
                    <thead>
                        <tr>
                            <th>Tiêu đề</th>
                            <th>Slug</th>
                            <th>Mô tả</th>
                        </tr>
                    </thead>
                    <tbody>
                        {categoriesList.length > 0 ? categoriesList.map((item, index) => 
                                <tr key={index}>
                                    <td>
                                        <Link to={`/admin/categories/edit/${item.id}`} 
                                        className='text-bold'>
                                            {item.name}
                                        </Link>
                                        <p className="text-muted">{item.description}</p>
                                    </td>
                                    <td>{item.urlSlug}</td>
                                    <td>{item.description}</td>
                                </tr>
                            ) : 
                            <tr>
                                <td colSpan={4}>
                                    <h4 className="text-danger text-center">Không tìm thấy chủ đề nào</h4>
                                </td>
                            </tr>}
                    </tbody>
                </Table>
            }
        </>
    );
}

export default Categories;