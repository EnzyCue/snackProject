import { Skeleton, Stack } from "@mui/material";

export default function ProductSkeleton() {
  return (
    <Stack spacing={1}>
      <Skeleton
        animation="wave"
        variant="text"
        sx={{ fontSize: "1rem", marginBottom: "-1em" }}
        width={415}
        height={50}
      />
      <Stack flexDirection="row">
        <Skeleton
          animation="wave"
          variant="text"
          sx={{
            fontSize: "1rem",
            marginBottom: "-3.5em",
            marginRight: "0.1em",
          }}
          width={220}
        />
        <Skeleton
          animation="wave"
          variant="text"
          sx={{ fontSize: "1rem", marginBottom: "-3.5em" }}
          width={220}
        />
      </Stack>
      <Stack flexDirection="row">
        <Skeleton
          animation="wave"
          width={220}
          height={200}
          sx={{ marginRight: "0.1em" }}
        />
        <Skeleton animation="wave" width={220} height={200} />
      </Stack>
    </Stack>
  );
}
