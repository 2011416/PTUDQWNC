import axios from "axios";

export async function getProducts() {
  try {
    const response = await axios.get(
      `https://localhost:7226/api/product?PageSize=10&PageNumber=1`
    );

    const data = response.data;
    if 
        (data.isSuccess) return data.result;
    else 
        return null;

  } catch (error) {
    console.log("Error", error.message);
    return null;
  }
}
