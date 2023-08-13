import axios from "axios";
import { IProductComparison } from "../models/product-comparison";

class ProductsApi {
  constructor() {}

  public async getAllProducts(): Promise<IProductComparison[]> {
    return (
      await axios.get<IProductComparison[]>(
        "https://localhost:7185/api/products"
      )
    ).data;
  }
}

export const productsApi = new ProductsApi();
