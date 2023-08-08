import axios from "axios";
import { IProduct } from "../models/product";

class ProductsApi {
  constructor() {}

  public async getAllProducts(): Promise<IProduct[]> {
    return (await axios.get<IProduct[]>("https://localhost:7185/api/products"))
      .data;
  }
}

export const productsApi = new ProductsApi();
