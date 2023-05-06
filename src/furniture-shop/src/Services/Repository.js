import { delete_api, get_api, post_api } from "./Method";

export async function getProducts(PageNumber= 1, PageSize=5, Keyword="") {
  return get_api(`https://localhost:7226/api/product?PageSize=5&PageNumber=1`)
}
export function getFilter(){
  return get_api(`https://localhost:7226/api/product/get-filter`)
}
export function getProductFilter(keyword = '', pageSize = 3, pageNumber = 1, sortColumn = '',
sortOrder = '') {
let url = new URL('https://localhost:7226/api/product/get-product-filter');
keyword !== '' && url.searchParams.append('Keyword', keyword);

sortColumn !== '' && url.searchParams.append('SortColumn', sortColumn);
sortOrder !== '' && url.searchParams.append('SortOrder', sortOrder);
url.searchParams.append('PageSize', pageSize);
url.searchParams.append('PageNumber', pageNumber);
return get_api(url.href);
}
export function getCategoriesFilter(keyword = '', pageSize = 3, pageNumber = 1, sortColumn = '',
sortOrder = '') {
let url = new URL('https://localhost:7226/api/categories');
keyword !== '' && url.searchParams.append('Keyword', keyword);

sortColumn !== '' && url.searchParams.append('SortColumn', sortColumn);
sortOrder !== '' && url.searchParams.append('SortOrder', sortOrder);
url.searchParams.append('PageSize', pageSize);
url.searchParams.append('PageNumber', pageNumber);
return get_api(url.href);
}
export function getUserFilter(keyword = '', pageSize = 3, pageNumber = 1, sortColumn = '',
sortOrder = '') {
let url = new URL('https://localhost:7226/api/user');
keyword !== '' && url.searchParams.append('Keyword', keyword);

sortColumn !== '' && url.searchParams.append('SortColumn', sortColumn);
sortOrder !== '' && url.searchParams.append('SortOrder', sortOrder);
url.searchParams.append('PageSize', pageSize);
url.searchParams.append('PageNumber', pageNumber);
return get_api(url.href);
}
export function getDelveriesFilter(keyword = '', pageSize = 3, pageNumber = 1, sortColumn = '',
sortOrder = '') {
let url = new URL('https://localhost:7226/api/deliveries');
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

export async function GetProductById(id=0){
  return get_api(`https://localhost:7226/api/product/${id}`)
}

export async function AddOrUpdatedProduct(formData){
  return post_api('https://localhost:7226/api/product', formData)
}
export async function DeleteProduct(id =0){
  return delete_api(`https://localhost:7226/api/product/${id}`)
}

export async function GetProductBySlug(slug=''){
  return get_api(`https://localhost:7226/api/product/byslug/${slug}`)
}

export async function GetCategoryById(id=0){
  return get_api(`https://localhost:7226/api/categories/id/${id}`)
}

export async function AddOrUpdatedCategory(formData){
  return post_api('https://localhost:7226/api/categories', formData)
}
export async function DeleteCategory(id =0){
  return delete_api(`https://localhost:7226/api/categories/${id}`)
}

export async function GetUserById(id=0){
  return get_api(`https://localhost:7226/api/user/${id}`)
}

export async function AddOrUpdatedUser(formData){
  return post_api('https://localhost:7226/api/user', formData)
}
export async function DeleteUser(id =0){
  return delete_api(`https://localhost:7226/api/user/${id}`)
}

export async function GetDeliveryById(id=0){
  return get_api(`https://localhost:7226/api/deliveries/id/${id}`)
}

export async function AddOrUpdateDelivery(formData){
  return post_api('https://localhost:7226/api/deliveries', formData)
}
export async function DeleteDelivey(id =0){
  return delete_api(`https://localhost:7226/api/deliveries/${id}`)
}

