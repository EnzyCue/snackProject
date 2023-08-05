import {
  Dialog,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import useOpenProductsStore from "../../../stores/product-store";

export default function ProductDialog() {
  const openProductsStore = useOpenProductsStore((state) => state);

  return (
    <Dialog
      open={openProductsStore.open}
      onClose={() => openProductsStore.setOpen(false)}
    >
      <DialogTitle>Current Offers</DialogTitle>
      <DialogContent>
        <DialogContentText>
          You can set my maximum width and whether to adapt or not.
        </DialogContentText>
      </DialogContent>
    </Dialog>
  );
}
