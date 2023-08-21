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
import useIsMobile from "../../../hooks/is-mobile";

interface IProductResultProps {
  productComparison: IProductComparison;
}

export default function ProductResult(props: IProductResultProps) {
  const { productComparison } = props;
  const isMobile = useIsMobile();

  const verticalTable = () => {
    return (
      //4 table rows
      //3 table columns
      <TableContainer component={Paper}>
        <Table size="small">
          <TableBody>
            <TableRow>
              <TableCell variant="head" sx={{ fontWeight: "bold" }}>
                Store Name
              </TableCell>
              <TableCell variant="head" sx={{ fontWeight: "bold" }}>
                Coles
              </TableCell>
              <TableCell variant="head" sx={{ fontWeight: "bold" }}>
                Woolworths
              </TableCell>
            </TableRow>
            <TableRow>
              <TableCell variant="head" sx={{ fontWeight: "bold" }}>
                Price
              </TableCell>
              <TableCell>${productComparison.coles.price.toFixed(2)}</TableCell>
              <TableCell>
                ${productComparison.woolworths.price.toFixed(2)}
              </TableCell>
            </TableRow>
            <TableRow>
              <TableCell variant="head" sx={{ fontWeight: "bold" }}>
                Savings
              </TableCell>
              <TableCell>
                ${productComparison.coles.saveAmount.toFixed(2)}
              </TableCell>
              <TableCell>
                ${productComparison.woolworths.saveAmount.toFixed(2)}
              </TableCell>
            </TableRow>
            <TableRow>
              <TableCell variant="head" sx={{ fontWeight: "bold" }}>
                Prive Per 100g
              </TableCell>
              <TableCell>
                ${productComparison.coles.pricePerHundredGrams.toFixed(2)}
              </TableCell>
              <TableCell>
                ${productComparison.woolworths.pricePerHundredGrams.toFixed(2)}
              </TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    );
  };

  const horizontalTable = () => {
    return (
      <TableContainer component={Paper}>
        <Table size="small">
          <TableHead>
            <TableRow>
              <TableCell sx={{ fontWeight: "bold" }}>Store Name</TableCell>
              <TableCell align="right" sx={{ fontWeight: "bold" }}>
                Price
              </TableCell>
              <TableCell align="right" sx={{ fontWeight: "bold" }}>
                Savings
              </TableCell>
              <TableCell
                align="right"
                sx={{ fontWeight: "bold", textAlign: "center" }}
              >
                Price Per 100g
              </TableCell>
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
                  <TableCell
                    component="th"
                    scope="row"
                    sx={{ fontWeight: "bold" }}
                  >
                    {key}
                  </TableCell>
                  <TableCell align="right">
                    ${product.price.toFixed(2)}
                  </TableCell>
                  <TableCell align="right">
                    ${product.saveAmount.toFixed(2)}
                  </TableCell>
                  <TableCell align="right" sx={{ textAlign: "center" }}>
                    ${product.pricePerHundredGrams.toFixed(2)}
                  </TableCell>
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
    );
  };

  return (
    <Stack flexDirection="column" sx={{ marginBottom: "2em" }}>
      <Typography
        paddingX={1}
        fontWeight={700}
        sx={{ textAlign: "center", marginBottom: "0.5em" }}
      >
        {productComparison.coles.name}
      </Typography>

      <Stack flexDirection="row">
        <Box sx={{ marginTop: "1em" }}>
          <img
            src={productComparison.woolworths.image}
            className="w-24 h-24 md:w-32 md:h-32 min-w-[6em] min-h-[6em]"
          />
        </Box>
        <Box
          flexGrow={1}
          sx={{ display: "flex", marginRight: "1em" }}
          justifyContent="center"
          flexDirection="column"
        >
          {isMobile ? verticalTable() : horizontalTable()}
        </Box>
      </Stack>
    </Stack>
  );
}
