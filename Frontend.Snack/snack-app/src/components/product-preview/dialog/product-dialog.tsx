import { Dialog, DialogContent, DialogTitle, Stack } from "@mui/material";
import useOpenProductsStore from "../../../stores/open-product-store";
import useProductsStore from "../../../stores/products-store";
import MultipleSkeletons from "../product-skelelton/multiple-skleletons";
import ProductResult from "../product-result/product-result";

export default function ProductDialog() {
  const openProductsStore = useOpenProductsStore((state) => state);
  const products = useProductsStore((state) => state.productComparisons);

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
        {!products ? (
          <MultipleSkeletons amount={10} keyPrefix="dialog" />
        ) : (
          products.map((productItem, index) => {
            return (
              <ProductResult
                productComparison={productItem}
                key={`result-${index}`}
              />
            );
          })
        )}
      </DialogContent>
    </Dialog>
  );
}
