import { Dialog, DialogContent, DialogTitle, Stack } from "@mui/material";
import useOpenProductsStore from "../../../stores/open-product-store";
import ProductSkeleton from "../product-skelelton/product-skeleton";
import { useEffect } from "react";

export default function ProductDialog() {
  const openProductsStore = useOpenProductsStore((state) => state);

  return (
    <Dialog
      PaperProps={{
        sx: {
          maxHeight: "50vh",
          minHeight: "50vh",
        },
      }}
      open={openProductsStore.open}
      onClose={() => openProductsStore.setOpen(false)}
    >
      <DialogTitle>Current Offers</DialogTitle>
      <DialogContent>
        {[...Array(10)].map(() => {
          return <ProductSkeleton />;
        })}
      </DialogContent>
    </Dialog>
  );
}
