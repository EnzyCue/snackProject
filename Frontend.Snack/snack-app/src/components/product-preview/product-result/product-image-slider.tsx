import ImageGallery from "react-image-gallery";

interface IProductImageSliderProps {
  colesImg: string;
  woolworthsImg: string;
}

export function ProductImageSlider(props: IProductImageSliderProps) {
  const images = [
    {
      original: props.colesImg,
    },
    {
      original: props.woolworthsImg,
    },
  ];

  return (
    <div className="h-full flex justify-start items-center">
      <div className="w-[23em] h-[13em] 2xl:w-[23em] 2xl:h-[15em]">
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
          //   additionalClass={styles.image}
        />
      </div>
    </div>
  );
}
