import { IProduct } from "../../../models/product";
import {
  Box,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import { IProductComparison } from "../../../models/product-comparison";
import Paper from "@mui/material/Paper";

interface IProductResultProps {
  productComparison: IProductComparison;
}

export default function ProductResult(props: IProductResultProps) {
  const { productComparison } = props;

  return (
    <Stack flexDirection="column" sx={{ marginBottom: "1em" }}>
      <Typography paddingX={1} fontWeight={700} sx={{ textAlign: "center" }}>
        {productComparison.coles.name}
      </Typography>

      <Stack flexDirection="row">
        <Box>
          <img src={productComparison.woolworths.image} className="w-32 h-32" />
        </Box>
        <Box
          flexGrow={1}
          sx={{ display: "flex" }}
          justifyContent="center"
          flexDirection="column"
        >
          <TableContainer component={Paper}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Store Name</TableCell>
                  <TableCell align="right">Price</TableCell>
                  <TableCell align="right">Savings</TableCell>
                  <TableCell align="right">Price Per 100g</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {Object.keys(productComparison).map((key) => {
                  const product =
                    productComparison[key as keyof IProductComparison];

                  return (
                    <TableRow
                      key={key}
                      sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                    >
                      <TableCell component="th" scope="row">
                        {key}
                      </TableCell>
                      <TableCell align="right">{product.price}</TableCell>
                      <TableCell align="right">{product.saveAmount}</TableCell>
                      <TableCell align="right">
                        {product.pricePerHundredGrams}
                      </TableCell>
                    </TableRow>
                  );
                })}
              </TableBody>
            </Table>
          </TableContainer>
        </Box>
      </Stack>
    </Stack>
  );
}
