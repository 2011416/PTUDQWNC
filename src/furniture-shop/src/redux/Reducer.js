import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    keyword: '',
    authorId: '',
    categoryId: '',
    year: '',
    month: ''
};

const productFilterReducer = createSlice({
    name: 'productFilter',
    initialState,
    reducers: {
        reset: (state, action) => {
        return initialState; 
        },
        updateKeyword: (state, action) => {
            return {
                ...state,
                keyword: action.payload,
            };
        },
        updateUserId: (state, action) => {
            return {
                ...state,
                userId: action.payload,
            };
        },
        updateCategoryId: (state, action) => {
            return {
                ...state,
                authorId: action.payload
            };
        },
        updateMonth: (state, action) => {
            return {
                ...state,
                month: action.payload
            };
        },
        updateYear: (state, action) => {
            return {
                ...state,
                year: action.payload
            };
        },
    },
});

export const {
    reset,
    updateKeyword,
    updateUserId,
    updateCategoryId,
    updateMonth,
    updateYear } = productFilterReducer.actions;

export const reducer = productFilterReducer.reducer;



        