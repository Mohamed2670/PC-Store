import '../Home.css';
import { useNavigate } from "react-router-dom";

export default function Home() {
  const navigate = useNavigate();

  function handleProducts() {
    navigate("/products");
  }

  function handleBuilds() {
    navigate("/build");
  }

  return (
    <>
      <div className="home-page-container">
        <div className="text-center pt-20">
          <h1 className="text-5xl font-bold text-gray-800 dark:text-white ">
            Welcome to the PC Builder
          </h1>
          <p className=" text-gray-900 drop-shadow-xl text-2xl dark:text-gray-300 mt-4 font-bold">
            Your one-stop solution for building and comparing PC components.
          </p>
        </div>

        <div className="flex justify-center space-x-4 pt-50">
          <button 
            className="mr-9 px-15 py-4 rounded-lg bg-gray-200 dark:bg-gray-800 text-black dark:text-white hover:bg-gray-300 dark:hover:bg-gray-700"
            onClick={handleProducts}
          >
            Products
          </button>
          <button 
            className="ml-9 px-15 py-4 rounded-lg bg-gray-300 dark:bg-gray-700 text-black dark:text-white hover:bg-gray-400 dark:hover:bg-gray-600"
            onClick={handleBuilds}
          >
            Building
          </button>
        </div>
      </div>
    </>
  );
}
