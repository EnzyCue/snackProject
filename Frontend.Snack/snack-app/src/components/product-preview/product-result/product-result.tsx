import { IProduct } from "../../../models/product";
import { Stack, Typography } from "@mui/material";
import { IProductComparison } from "../../../models/product-comparison";
import { ProductImageSlider } from "./product-image-slider";

interface IProductResultProps {
  productComparison: IProductComparison;
}

export default function ProductResult(props: IProductResultProps) {
  const { productComparison } = props;

  return (
    <Stack
      sx={{ overflowY: "scroll" }}
      flexDirection="column"
      alignItems="center"
    >
      <Typography paddingX={1} fontWeight={500} sx={{ textAlign: "center" }}>
        {productComparison.coles.name}
      </Typography>

      <Stack flexDirection="row" alignItems="center">
        <ProductImageSlider
          colesImg={productComparison.coles.image}
          woolworthsImg={productComparison.woolworths.image}
        />
      </Stack>
    </Stack>
  );
}
