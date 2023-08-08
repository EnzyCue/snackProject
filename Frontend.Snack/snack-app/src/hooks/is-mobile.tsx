import { useEffect, useState } from "react";

const getIsMobile = () => window.innerWidth <= 640;

export default function useIsMobile() {
  const [isMobile, setIsMobile] = useState(getIsMobile());

  useEffect(() => {
    const onResize = () => {
      setIsMobile(getIsMobile());
    };

    window.addEventListener("resize", onResize);
    // This is the destructor that runs when a component is unmounted.
    return () => {
      window.removeEventListener("resize", onResize);
    };
  }, []);

  return isMobile;
}
