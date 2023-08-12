import { create } from "zustand";
import { IProduct } from "../models/product";

// stores the product preview data

interface IProductsStore {
  products: IProduct[] | undefined;
  setProducts: (products: IProduct[]) => void;
}

const useProductsStore = create<IProductsStore>((set) => ({
  products: undefined,
  setProducts: (products: IProduct[]) => set(() => ({ products: products })),
}));
export default useProductsStore;
