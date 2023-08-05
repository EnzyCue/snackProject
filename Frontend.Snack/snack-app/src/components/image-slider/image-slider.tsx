import ImageGallery from "react-image-gallery";
import "./image-slider.css";
import styles from "./image-slider.module.css";

export function ImageSlider() {
  const images = [
    {
      original: "/image-1.png",
    },
    {
      original: "https://picsum.photos/id/1015/1000/600/",
      thumbnail: "https://picsum.photos/id/1015/250/150/",
    },
    {
      original: "https://picsum.photos/id/1019/1000/600/",
      thumbnail: "https://picsum.photos/id/1019/250/150/",
    },
  ];

  return (
    <div className="h-full flex justify-start items-center">
      <div className="w-[43em] h-[26em] 2xl:w-[47em] 2xl:h-[30em]">
        <ImageGallery
          items={images}
          useBrowserFullscreen={false}
          useTranslate3D={false}
          autoPlay={true}
          disableKeyDown={true}
          showBullets={true}
          showThumbnails={false}
          showPlayButton={false}
          showNav={false}
          showFullscreenButton={false}
          additionalClass={styles.image}
        />
      </div>
    </div>
  );
}
