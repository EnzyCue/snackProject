import { Drawer, Stack, Typography } from "@mui/material";
import useOpenProductsStore from "../../../stores/open-product-store";
import MultipleSkeletons from "../product-skelelton/multiple-skleletons";
import useProductsStore from "../../../stores/products-store";
import ProductResult from "../product-result/product-result";

export default function ProductDrawer() {
  const openProductsStore = useOpenProductsStore((state) => state);
  const productComparisons = useProductsStore(
    (state) => state.productComparisons
  );

  return (
    <Drawer
      PaperProps={{
        sx: {
          height: "60%",
          maxWidth: "700px",
          marginX: "auto",
        },
      }}
      open={openProductsStore.open}
      onClose={() => openProductsStore.setOpen(false)}
      anchor="bottom"
    >
      <Typography
        sx={{ textAlign: "center" }}
        variant="h1"
        fontSize={20}
        paddingY={1}
        fontWeight={700}
      >
        Current Offers
      </Typography>
      <Stack
        sx={{ overflowY: "scroll" }}
        flexDirection="column"
        alignItems="center"
      >
        {!productComparisons ? (
          <MultipleSkeletons amount={10} keyPrefix="drawer" />
        ) : (
          productComparisons.map((productItem, index) => {
            return (
              <ProductResult
                productComparison={productItem}
                key={`result-${index}`}
              />
            );
          })
        )}
      </Stack>
    </Drawer>
  );
}
