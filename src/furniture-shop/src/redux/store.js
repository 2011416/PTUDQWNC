import { configureStore } from '@reduxjs/toolkit'

import productModalReducer from './product-modal/productModalSlice'

import cartItemsSlide from './shopping-cart/cartItemsSlide'
import { reducer } from './Redux'

export const store = configureStore({
    reducer: {
        productModal: productModalReducer,
        cartItems: cartItemsSlide,
        productFilter: reducer
    },
})