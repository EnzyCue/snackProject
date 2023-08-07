import { Drawer, Stack, Typography } from "@mui/material";
import useOpenProductsStore from "../../../stores/product-store";
import ProductSkeleton from "../product-skelelton/product-skeleton";

export default function ProductDrawer() {
  const openProductsStore = useOpenProductsStore((state) => state);

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
        {[...Array(10)].map(() => {
          return <ProductSkeleton />;
        })}
      </Stack>
    </Drawer>
  );
}
