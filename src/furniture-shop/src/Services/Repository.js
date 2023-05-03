import axios from "axios";
import { get_api } from "./Method";

export async function getProducts(PageNumber= 1, PageSize=5, Keyword="") {
  return get_api(`https://localhost:7226/api/product?PageSize=5&PageNumber=1`)
}

export function getProductFilter(keyword = '', pageSize = 10, pageNumber = 1, sortColumn = '',
sortOrder = '') {
let url = new URL('https://localhost:7226/api/product');
keyword !== '' && url.searchParams.append('Keyword', keyword);

sortColumn !== '' && url.searchParams.append('SortColumn', sortColumn);
sortOrder !== '' && url.searchParams.append('SortOrder', sortOrder);
url.searchParams.append('PageSize', pageSize);
url.searchParams.append('PageNumber', pageNumber);
return get_api(url.href);
}

export async function getCategories(PageNumber= 1, PageSize=5, Keyword="") {
  return get_api(`https://localhost:7226/api/categories?PageSize=5&PageNumber=1`)
}

export async function getUsers(PageNumber= 1, PageSize=5, Keyword="") {
  return get_api(`https://localhost:7226/api/user?PageSize=10&PageNumber=1`)
}

export async function getDeliveries(PageNumber= 1, PageSize=5, Keyword="") {
  return get_api(`https://localhost:7226/api/deliveries?PageSize=10&PageNumber=1`)
}

export async function getProductBySlug(slug = '') {
  if (slug !== '')
   return get_api(`https://localhost:7226/api/categories/${slug}`);
  return null;
}

export async function deleteCategory(id = '') {
  if (id !== '')
   return get_api(`https://localhost:7226/api/categories/${id}`);
  return null;
}





