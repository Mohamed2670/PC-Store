import { ChangeEvent, useState } from "react";
import axios from "axios";

interface Product {
  // Define your product type here based on your response structure
  id: number;
  name: string;
  price: number;
}

export default function Searchbar() {
  const [searchResult, setSearchResult] = useState<Product[]>([]);
  const [searchInput, setSearchInput] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  async function HandleSearch(e: React.FormEvent) {
    e.preventDefault(); 
    if (!searchInput.trim()) return;

    setLoading(true);
    setError(""); 

    try {
      console.log(searchInput);
      const reqesteUrl = `http://localhost:5218/product/search?productName=${searchInput}&page=1&size=20`;
      const response = await axios.get(reqesteUrl);
      setSearchResult(response.data);
      console.log(response);
    } catch (err) {
      setError("Failed to fetch data. Please try again.");
      console.error(err);
    } finally {
      setLoading(false);
    }
  }

  function HandleInputChange(e: ChangeEvent<HTMLInputElement>) {
    setSearchInput(e.target.value);
  }

  return (
    <div>
      <form className="max-w-md mx-auto" onSubmit={HandleSearch}>
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
            placeholder="Search for HardWare u want :)"
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

      {loading && <div>Loading...</div>}
      {error && <div className="text-red-500">{error}</div>}

      <div>
        {searchResult.length > 0 && (
          <ul>
            {searchResult.map((product) => (
              <li key={product.id}>
                {product.name} - ${product.price}
              </li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}
