import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import LineChart from "./LineChart";

export default function ProductDetails() {
  const [productDetails, setProductDetails] = useState<Products>();
  const [storeName, setStoreName] = useState("");
  const [priceHistory, setPriceHistory] = useState<Price[]>([]);
  const { id } = useParams<{ id: string }>();
  useEffect(() => {
    const GetProduct = async () => {
      var reqesteUrl = `http://localhost:5218/product/price-history/${id}`;
      var response = await axios.get(reqesteUrl);
      console.log(response.data);
      setPriceHistory(response.data);
      reqesteUrl = `http://localhost:5218/product/${id}`;
      response = await axios.get(reqesteUrl);
      console.log(response.data.storeId);
      setProductDetails(response.data);
      reqesteUrl = `http://localhost:5218/store/${response.data.storeId}`;
      console.log(reqesteUrl);
      response = await axios.get(reqesteUrl);
      console.log(response.data);
      setStoreName(response.data.name);
    };

    GetProduct();
  }, []);
  return (
    <>
      <div className="min-h-screen bg-gray-100 dark:bg-gray-900 flex items-center justify-center">
        <div className="w-4/5 max-w-6xl bg-white dark:bg-gray-800 rounded-lg shadow-lg p-8 flex flex-col md:flex-row gap-8">
          {/* Product Image */}
          <div className="md:w-1/2 flex justify-start">
            <img
              className="w-full h-96 object-cover rounded-lg"
              src={productDetails?.imageUrl}
              alt={productDetails?.name}
            />
          </div>

          {/* Product Details */}
          <div className="md:w-1/2 flex flex-col justify-between">
            <div>
              <h1 className="text-3xl font-bold text-gray-900 dark:text-white mb-6">
                {productDetails?.name}
              </h1>
              <div className="text-2xl font-bold text-green-600 dark:text-green-400 mb-6">
                {productDetails?.currentPrice} L.E
              </div>
              <div className="mb-6">
                <a
                  href={productDetails?.productUrl}
                  target="_blank"
                  rel="noopener noreferrer"
                  className="text-blue-600 dark:text-blue-400 underline hover:text-blue-800 dark:hover:text-blue-200 text-lg"
                >
                  View Product
                </a>
              </div>
            </div>
            <div className="text-lg text-gray-600 dark:text-gray-400">
              Sold by: <span className="font-medium">{storeName}</span>
            </div>
          </div>
        </div>
        <div className="flex items-center justify-center p-4 bg-gray-50 dark:bg-gray-900 shadow-md ">
          <LineChart priceHistory={priceHistory} />
        </div>
      </div>
    </>
  );
}
