import React, { useEffect, useState } from 'react'

import { useSelector, useDispatch } from 'react-redux'

import ProductView from './ProductView'
import Button from './Button'

import { remove } from '../redux/product-modal/productModalSlice'

import productData from '../assets/fake-data/product'

const ProductViewModal = () => {

    const productSlug = useSelector((state) => state.productModal.value)
    
    const dispatch = useDispatch()

    const [product, setProduct] = useState(undefined)

    //const product = productData.getProductBySlug('tu-tv-5')

    useEffect(() => {
        setProduct(productData.getProductBySlug(productSlug))
    }, [productSlug]);

  return (
    <div className={`product-view__modal ${product === undefined ? '' : 'active'}`}>
        <div className='product-view__modal__content'>
            <ProductView product={product}/>
        </div>
        <div className="product-view__modal__content__close">
            <Button
                size="sm"
                onClick={() => dispatch(remove())}
            >
                đóng
            </Button>
        </div> 
    </div>
  )
}

export default ProductViewModal