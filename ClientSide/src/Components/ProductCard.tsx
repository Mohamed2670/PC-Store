import { useNavigate } from "react-router-dom";
import Product from "./Product";

interface ProductCardProps {
  id: string;
  name: string;
  buildCategory:string
  price: number;

  imageUrl: string;

  productUrl: string;
  setProductBuild: React.Dispatch<React.SetStateAction<ProductBuild[] >>
}
export default function ProductCard({
    id,
    name,
    buildCategory,
    price,
    imageUrl,
  productUrl,
  setProductBuild,
}: ProductCardProps) {
  const navigate = useNavigate();
    const url = `/products/details/${id}`;
  
    function handleBuild() {
      setProductBuild((prevBuild) => [
        ...(prevBuild || []),
        { id, name, price, productUrl, buildCategory },
      ]);
      console.log(`Stored  ${buildCategory} - ${name}`);
      navigate("/Build")
    }
  
    return (
      <>
        <div className="w-full max-w-sm bg-white border border-gray-200 rounded-lg shadow-sm dark:bg-gray-800 dark:border-gray-700 hover:scale-105 transform transition-all duration-300">
          <a target="_blank" href={url}>
            <img
              className="w-full h-48 object-cover rounded-t-lg"
              src={imageUrl}
              alt={name}
            />
          </a>
          <div className="px-4 pb-4">
            <a target="_blank" href={productUrl}>
              <h5 className="text-xl font-semibold tracking-tight text-gray-900 dark:text-white hover:text-blue-500 truncate">
                {name}
              </h5>
            </a>
            <div className="flex items-center justify-between mt-2">
              <span className="text-2xl font-bold text-gray-900 dark:text-white">
                {price} L.E
              </span>
              {buildCategory && (<div  className="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                <button onClick={handleBuild}>
                
                    Add to Build
                </button>
                </div>
              )}
            </div>
          </div>
        </div>
      </>
    );
  }