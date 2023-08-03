import "./App.css";
import Button from "@mui/material/Button";
import ArrowForwardRoundedIcon from "@mui/icons-material/ArrowForwardRounded";
import { ImageSlider } from "./components/image-slider/image-slider";

function App() {
  return (
    <>
      {/* Root background */}
      <div className="flex flex-row h-full bg-color">
        {/* First left half of screen */}
        <div className="flex flex-col justify-center grow">
          {/* Content info */}
          <div className="ml-0 md:ml-[15%] 2xl:mb-[9em]">
            <h1 className="text-gray-900 text-5xl md:text-6xl text-4xl font-bold leading-none tracking-tight 2xl:text-8xl">
              Snack App
            </h1>
            <p className="text-lg text-gray-900 md:text-xl font-normal md:max-w-xl my-4 md:my-6 ">
              Effortlessly compare snack prices between stores with our app.
              Find the best deals, save money, and navigate your snack shopping
              with real-time updates and an easy-to-use interface. Your smart,
              cost-effective snack shopping companion.
            </p>
            <button className="transition ease-in-out duration-500 delay-75  hover:scale-105 bg-gray-600 hover:bg-gray-900 text-white font-bold py-2 px-4 rounded-l-md rounded-r-xl">
              <div className="flex justify-center content-center 2xl:text-2xl">
                <p>Preview</p>
                <ArrowForwardRoundedIcon
                  sx={{ marginLeft: "0.5rem", fontSize: 35 }}
                />
              </div>
            </button>
          </div>
        </div>
        {/* First Right half of screen */}
        <div className="flex flex-col justify-center grow hidden xl:block">
          <ImageSlider />
        </div>
      </div>
    </>
  );
}

export default App;
