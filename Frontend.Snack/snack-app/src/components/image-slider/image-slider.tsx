import ImageGallery from "react-image-gallery";
import "./image-slider.css";

export function ImageSlider() {
  const images = [
    {
      original: "https://picsum.photos/id/1018/1000/600/",
      thumbnail: "https://picsum.photos/id/1018/250/150/",
      sizes: 100,
    },
    {
      original: "https://picsum.photos/id/1015/1000/600/",
      thumbnail: "https://picsum.photos/id/1015/250/150/",
      originalHeight: 100,
    },
    {
      original: "https://picsum.photos/id/1019/1000/600/",
      thumbnail: "https://picsum.photos/id/1019/250/150/",
      originalHeight: 100,
    },
  ];

  return (
    <div className="w-full h-1/4">
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
      />
    </div>
  );
}
