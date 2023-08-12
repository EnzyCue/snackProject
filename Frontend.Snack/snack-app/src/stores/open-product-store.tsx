import { create } from "zustand";

// stores whether the preview is currently being displayed or not

interface IOpenProductsStore {
  open: boolean;
  setOpen: (isOpen: boolean) => void;
}

const useOpenProductsStore = create<IOpenProductsStore>((set) => ({
  open: false,
  setOpen: (isOpen: boolean) => set(() => ({ open: isOpen })),
}));
export default useOpenProductsStore;
