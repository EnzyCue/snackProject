import { create } from "zustand";
import { IProductComparison } from "../models/product-comparison";

// stores the product preview data

interface IProductsStore {
  productComparisons: IProductComparison[] | undefined;
  setProductComparison: (products: IProductComparison[]) => void;
}

const useProductsStore = create<IProductsStore>((set) => ({
  productComparisons: undefined,
  setProductComparison: (products: IProductComparison[]) =>
    set(() => ({ productComparisons: products })),
}));
export default useProductsStore;
