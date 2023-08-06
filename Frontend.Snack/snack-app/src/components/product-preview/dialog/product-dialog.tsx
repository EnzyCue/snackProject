import { Dialog, DialogContent, DialogTitle, Stack } from "@mui/material";
import useOpenProductsStore from "../../../stores/product-store";
import ProductSkeleton from "../product-skelelton/product-skeleton";

export default function ProductDialog() {
  const openProductsStore = useOpenProductsStore((state) => state);

  return (
    <Dialog
      open={openProductsStore.open}
      onClose={() => openProductsStore.setOpen(false)}
    >
      <DialogTitle>Current Offers</DialogTitle>
      <DialogContent>
        {[...Array(10)].map(() => {
          return (
            <Stack flexDirection="column">
              <ProductSkeleton />
            </Stack>
          );
        })}
      </DialogContent>
    </Dialog>
  );
}
