import axios from "axios";
import React, { useEffect, useState } from "react";
interface cate {
  id: number;
  name: string;
}
interface PaginationProps {
  pageSize: number;
  pageNumber: number;
}

interface CategoryProps extends PaginationProps {
  setProducts: React.Dispatch<React.SetStateAction<Products[]>>;
  setPredictedProducts: React.Dispatch<React.SetStateAction<Products[]>>;
  setCategoryId: React.Dispatch<React.SetStateAction<string>>;
}
export default function Category({
  pageSize,
  pageNumber,
  setCategoryId,
  setPredictedProducts,
  setProducts,
}: CategoryProps) {
  const [categories, setCategories] = useState<cate[]>([]);
  const [isDrobDown, setIsDrobDown] = useState(false);

  useEffect(() => {
    const getCategories = async () => {
      const reqesteUrl = "http://localhost:5218/category";
      const response = await axios.get(reqesteUrl);
      setCategories(response.data);
      console.log(categories);
    };
    getCategories();
  }, []);
  async function handleSearch(cateId: number) {
    const reqesteUrl = `http://localhost:5218/product/category/${cateId}?page=${pageNumber}&size=${pageSize}`;
    const response = await axios.get(reqesteUrl);
    setProducts(response.data);
    setCategoryId(cateId.toString());
    const response2 = await axios.get(
      `http://localhost:5218/product/category/${cateId}?page=${
        pageNumber + 1
      }&size=${pageSize}`
    );
    setPredictedProducts(response2.data);
    localStorage.setItem("categoryId", cateId.toString());
  }
  return (
    <>
      <div className="relative inline-block">
        <button
          className="px-13 py-2 text-white bg-blue-500 rounded-lg hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-300"
          onClick={() => setIsDrobDown(!isDrobDown)}
        >
          Categories
        </button>
        {isDrobDown && (
          <ul className="absolute right-0 mt-2 bg-white border border-gray-200 rounded-lg shadow-lg dark:bg-gray-800 z-20 max-h-60 overflow-y-auto">
            {categories.map((cate) => (
              <li
                key={cate.id}
                className="px-10 py-2 text-gray-700 cursor-pointer hover:bg-gray-100 dark:text-gray-200 dark:hover:bg-gray-700"
                onClick={() => {
                  handleSearch(cate.id);
                  setIsDrobDown(false); 
                }}
              >
                {cate.name}
              </li>
            ))}
          </ul>
        )}
      </div>
    </>
  );
}
