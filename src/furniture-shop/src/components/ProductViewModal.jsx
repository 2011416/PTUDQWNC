import React from 'react'

import ProductView from './ProductView'
import Button from './Button'

import productData from '../assets/fake-data/product'

const ProductViewModal = () => {

    const product = productData.getProductBySlug('tu-tv-5')

  return (
    <div className="product-view__modal">
        <div className='product-view__modal__content'>
            <ProductView product={product}/>
        </div>
        <div className="product-view__modal__content__close">
            <Button
                size="sm"
            >
                đóng
            </Button>
        </div> 
    </div>
  )
}

export default ProductViewModal