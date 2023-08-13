import "./App.css";
import ArrowForwardRoundedIcon from "@mui/icons-material/ArrowForwardRounded";
import { ImageSlider } from "./components/image-slider/image-slider";
import { DownloadButtons } from "./components/download-buttons/download-buttons";
import ProductDialog from "./components/product-preview/dialog/product-dialog";
import useOpenProductsStore from "./stores/open-product-store";
import ProductDrawer from "./components/product-preview/drawer/product-drawer";
import useIsMobile from "./hooks/is-mobile";
import useProductsStore from "./stores/products-store";
import { productsApi } from "./api/products-api";

function App() {
  const setOpen = useOpenProductsStore((state) => state.setOpen);
  const productsStore = useProductsStore((state) => state);
  const isMobile = useIsMobile();

  const onPreviewClick = async () => {
    setOpen(true);

    if (!productsStore.products) {
      const products = await productsApi.getAllProducts();
      productsStore.setProducts(products);
    }
    // display the productStore.product data into the preview format.
  };

  return (
    <>
      {/* Root background */}
      <div className="flex flex-row h-full bg-color">
        {/* First left half of screen */}
        <div className="flex flex-col justify-center grow">
          {/* Content info */}
          <div className="ml-0 md:ml-[15%] 2xl:mb-[7em] px-3.5">
            <h1 className="text-gray-900 text-5xl md:text-6xl text-4xl font-bold leading-none tracking-tight 2xl:text-8xl">
              Snack App
            </h1>
            <p className="text-lg text-gray-900 md:text-xl font-normal md:max-w-xl my-4 md:my-6 ">
              Effortlessly compare snack prices between stores with our app.
              Find the best deals, save money, and navigate your snack shopping
              with real-time updates and an easy-to-use interface. Your smart,
              cost-effective snack shopping companion.
            </p>
            <button
              onClick={onPreviewClick}
              className="transition ease-in-out duration-500 hover:scale-105 bg-black hover:bg-gray-900 text-white font-bold py-2 px-4 rounded-l-md rounded-r-xl"
            >
              <div className="flex justify-center content-center 2xl:text-2xl">
                <p>Preview</p>
                <ArrowForwardRoundedIcon
                  id="arrow-icon"
                  sx={{ marginLeft: "0.5rem" }}
                />
              </div>
            </button>
          </div>
        </div>
        {/* First Right half of screen */}
        <div className="flex flex-col justify-center grow hidden xl:block">
          <ImageSlider />
        </div>
        <div className="absolute inset-x-0 bottom-0">
          <DownloadButtons />
        </div>
      </div>
      {isMobile ? <ProductDrawer /> : <ProductDialog />}
    </>
  );
}

export default App;
