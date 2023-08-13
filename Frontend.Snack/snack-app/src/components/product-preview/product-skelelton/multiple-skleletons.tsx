import ProductSkeleton from "./product-skeleton";

interface IMultipleSkeletonsProps {
  amount: number;
  keyPrefix: string;
}

export default function MultipleSkeletons(props: IMultipleSkeletonsProps) {
  return (
    <>
      {[...Array(props.amount)].map((obj, index) => {
        return <ProductSkeleton key={`${props.keyPrefix}-skeleton-${index}`} />;
      })}
    </>
  );
}
