import { create } from "zustand";

interface IOpenProductsStore {
  open: boolean;
  setOpen: (isOpen: boolean) => void;
}

const useOpenProductsStore = create<IOpenProductsStore>((set) => ({
  open: false,
  setOpen: (isOpen: boolean) => set(() => ({ open: isOpen })),
}));
export default useOpenProductsStore;
