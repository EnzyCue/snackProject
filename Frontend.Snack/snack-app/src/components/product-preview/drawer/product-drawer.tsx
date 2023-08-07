import { Drawer } from "@mui/material";
import useOpenProductsStore from "../../../stores/product-store";
import ProductSkeleton from "../product-skelelton/product-skeleton";

export default function ProductDrawer() {
  const openProductsStore = useOpenProductsStore((state) => state);

  return (
    <Drawer
      open={openProductsStore.open}
      onClose={() => openProductsStore.setOpen(false)}
      anchor="bottom"
    >
      {[...Array(10)].map(() => {
        return <ProductSkeleton />;
      })}
    </Drawer>
  );
}
