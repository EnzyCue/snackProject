import { IProduct } from "../../../models/product";
import { Stack, Typography } from "@mui/material";
import { IProductComparison } from "../../../models/product-comparison";

interface IProductResultProps {
  productComparison: IProductComparison;
}

export default function ProductResult(props: IProductResultProps) {
  const { productComparison } = props;

  console.log(productComparison);

  console.log(productComparison.coles.name);

  return (
    <Stack>
      <Typography>{productComparison.coles.name} </Typography>
    </Stack>
  );
}
