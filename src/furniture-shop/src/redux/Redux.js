import { createSlice } from "@reduxjs/toolkit";

const initialState={
  keyword:"",
  userId:""
}

const productFilterReducer= createSlice(
  {
    name: "productFilter",
    initialState,
    reducers:{
      reset: (state, action)=>{
        return initialState
      },
      updateKeyword:(state, action)=>{
        return{
          ...state,
          keyword: action.payload,
        }
      },
      updateUserId: (state, action)=>{
        return{
          ...state,
          userId: action.payload,
        };
      },
    },
  }
);
export const{
  reset,
  updateKeyword,
  updateUserId
}= productFilterReducer.actions;
export const reducer= productFilterReducer.reducer;