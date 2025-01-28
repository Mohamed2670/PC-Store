import axios from "axios";
import { ChangeEvent, useEffect, useState } from "react";
import ProductCard from "./ProductCard";
import Searchbar from "./SearchBar";
import Category from "./Category";
import { useParams } from "react-router-dom";
import { build } from "vite";
interface Product {
  id: number;
  name: string;
  price: number;
}

export default function ({
  buildCategory,
  setProductBuild,
}: {
  buildCategory: string;
  setProductBuild: React.Dispatch<React.SetStateAction<ProductBuild[]>>;
}) {
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setSageSize] = useState(20);
  const [products, setProducts] = useState<Products[]>([]);
  const [predictedProducts, setPredictedProducts] = useState<Products[]>([]);
  const [searchInput, setSearchInput] = useState<string>("");
  const [categoryId, setCategoryId] = useState(buildCategory);

  async function HandleSearch(e: React.FormEvent) {
    e.preventDefault();
    if (!searchInput.trim()) return;
    setPageNumber(1);
    setPredictedProducts([]);
    setProducts([]);
    console.log(searchInput);
    const reqesteUrl = `http://localhost:5218/product/search?productName=${searchInput}&page=1&size=20`;
    const response = await axios.get(reqesteUrl);
    setProducts(response.data);
    console.log(response);
    setPageNumber(pageNumber + 1);
    const response2 = await axios.get(reqesteUrl);
    console.log(response2.data);
    setPredictedProducts(response2.data);
    setPageNumber(pageNumber + 1);
  }

  function HandleInputChange(e: ChangeEvent<HTMLInputElement>) {
    setSearchInput(e.target.value);
  }
  useEffect(() => {
    const GetAll = async () => {
      console.log(categoryId);

      const reqesteUrl =
        categoryId != ""
          ? `http://localhost:5218/product/category/${categoryId}?page=${pageNumber}&size=${pageSize}`
          : `http://localhost:5218/product?page=${pageNumber}&size=${pageSize}`;
      const response = await axios.get(reqesteUrl);
      setProducts(response.data);
      setPageNumber(pageNumber + 1);
      const response2 = await axios.get(reqesteUrl);
      console.log(response2.data);
      setPredictedProducts(response2.data);
      setPageNumber(pageNumber + 1);
    };
    GetAll();
  }, []);
  async function handleMore() {
    setProducts((oldProducts) => [...oldProducts, ...predictedProducts]);
    console.log(products);
    const reqesteUrl =
      searchInput.length > 0
        ? `http://localhost:5218/product/search?productName=${searchInput}&page=${pageNumber}&size=${pageSize}`
        : categoryId != ""
        ? `http://localhost:5218/product/category/${categoryId}?page=${pageNumber}&size=${pageSize}`
        : `http://localhost:5218/product?page=${pageNumber}&size=${pageSize}`;
    const response = await axios.get(reqesteUrl);
    console.log(response.data);
    setPredictedProducts(response.data);
    setPageNumber(pageNumber + 1);
  }
  return (
    <>
      <div className="pt-10 px-4 dark:bg-gray-900">
        <div className="flex flex-col md:flex-row gap-6">
          {/* Left Side: Search + Category */}
          <div className="w-full md:w-1/4 space-y-6">
            {/* Search Form */}
            <form className="max-w-full" onSubmit={HandleSearch}>
              <label
                htmlFor="default-search"
                className="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white"
              >
                Search
              </label>
              <div className="relative">
                <div className="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
                  <svg
                    className="w-4 h-4 text-gray-500 dark:text-gray-400"
                    aria-hidden="true"
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 20 20"
                  >
                    <path
                      stroke="currentColor"
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth="2"
                      d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
                    />
                  </svg>
                </div>
                <input
                  type="search"
                  id="default-search"
                  className="block w-full p-4 ps-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                  placeholder="Search for Hardware you want :)"
                  value={searchInput}
                  onChange={HandleInputChange}
                  required
                />
                <button
                  type="submit"
                  className="text-white absolute end-2.5 bottom-2.5 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
                >
                  Search
                </button>
              </div>
            </form>

            {/* Category Component */}
            <div className="dark:bg-gray-900 border-gray-200 rounded-lg shadow-lg p-4 pl-35">
              <h2 className="text-lg font-semibold text-gray-700 dark:text-white mb-4">
                Categories
              </h2>
              <Category
                pageSize={pageSize}
                pageNumber={pageNumber}
                setCategoryId={setCategoryId}
                setPredictedProducts={setPredictedProducts}
                setProducts={setProducts}
              />
            </div>
          </div>

          {/* Right Side: Products */}
          <div className="w-full md:w-3/4">
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
              {products.map((product) => (
                <ProductCard
                  key={product.id}
                  id={product.id}
                  name={product.name}
                  buildCategory={buildCategory}
                  price={product.currentPrice}
                  imageUrl={product.imageUrl}
                  productUrl={product.productUrl}
                  setProductBuild={setProductBuild}
                />
              ))}
            </div>
            {predictedProducts.length > 0 && (
              <div className="flex justify-center mt-6 mb-4">
                <button
                  onClick={handleMore}
                  className="bg-blue-600 text-white font-semibold py-2 px-6 rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-4 focus:ring-blue-300 transition-all duration-300"
                >
                  Load More
                </button>
              </div>
            )}
          </div>
        </div>
      </div>
    </>
  );
}
