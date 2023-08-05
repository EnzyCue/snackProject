import {
  Dialog,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import { useState } from "react";

interface IProductDialogProps {
  open: boolean;
  setOpen: React.Dispatch<React.SetStateAction<boolean>>;
}

export default function ProductDialog(props: IProductDialogProps) {
  return (
    <Dialog open={props.open} onClose={() => props.setOpen(false)}>
      <DialogTitle>Current Offers</DialogTitle>
      <DialogContent>
        <DialogContentText>
          You can set my maximum width and whether to adapt or not.
        </DialogContentText>
      </DialogContent>
    </Dialog>
  );
}
