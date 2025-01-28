import axios from "axios";
import React, { useEffect, useState } from "react";
import Product from "./Product";

interface Build {
  id: number;
  name: string;
  userId: number;
  cpuId: number | null;
  gpuId: number | null;
  motherBoardId: number | null;
  ramId: number | null;
  caseId: number | null;
  powerSupplyId: number | null;
  hddId: number | null;
  sddId: number | null;
  totalPrice: number;
}


export default function BuildsDropdown() {
  const [builds, setBuilds] = useState<Build[]>([]);
  const [selectedBuild, setSelectedBuild] = useState<Build | null>(null);
  const [products, setProducts] = useState<Products[]>([]);
  const userId = localStorage.getItem("UserId");

  useEffect(() => {
    const fetchBuilds = async () => {
      const BEARER_TOKEN = localStorage.getItem("AccessToken");
      if (!userId || !BEARER_TOKEN) {
        console.error("UserId or AccessToken not found in local storage");
        return;
      }

      try {
        const response = await axios.get(
          `http://localhost:5218/build?userId=${userId}`,
          {
            headers: {
              Authorization: `Bearer ${BEARER_TOKEN}`,
            },
          }
        );

        setBuilds(response.data);
      } catch (error) {
        console.error("Error fetching builds:", error);
      }
    };

    fetchBuilds();
  }, [userId]);

  const handleSelectBuild = async (buildId: number) => {
    const build = builds.find((b) => b.id === buildId) || null;
    setSelectedBuild(build);

    if (build) {
      const productIds = [
        build.cpuId,
        build.gpuId,
        build.motherBoardId,
        build.ramId,
        build.caseId,
        build.powerSupplyId,
        build.hddId,
        build.sddId,
      ].filter((id): id is number => id !== 0);

      try {
        const productResponses = await Promise.all(
          productIds.map((id) =>
            axios.get(`http://localhost:5218/product/${id}`)
          )
        );

        const productsData = productResponses.map((res) => res.data);
        setProducts(productsData);
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    }
  };
  var totalPrice = 0;
  products.forEach((product) => {
    totalPrice += product.currentPrice;
  });
  return (
    <div className="bg-gray-900 min-h-screen">
      <div className="bg-white border rounded-lg shadow-lg p-4 max-w-md mx-auto">
        <h2 className="text-xl font-bold mb-4 text-gray-800">Select a Build</h2>
        <div className="relative">
          <select
            className="block w-full p-2 border border-gray-300 rounded-lg focus:outline-none focus:ring focus:border-blue-300"
            onChange={(e) => handleSelectBuild(Number(e.target.value))}
            defaultValue=""
          >
            <option value="" disabled>
              Select a build...
            </option>
            {builds.map((build) => (
              <option key={build.id} value={build.id}>
                {build.name}
              </option>
            ))}
          </select>
        </div>
        {selectedBuild && (
          <div className="mt-4 p-4 border rounded-lg bg-gray-50">
            <h3 className="text-lg font-bold text-gray-700">
              {selectedBuild.name}
            </h3>
         
            <p className="text-gray-600">Build ID: {selectedBuild.id}</p>
            <h4 className="mt-4 text-md font-semibold text-gray-700">
              Products:
            </h4>
            <ul className="list-disc pl-5 text-gray-600">
              {products.length > 0 ? (
                products.map((product) => (
                  <li className="p-4" key={product.id}>
                    <a href={product.productUrl}>{product.name}</a> - {product.currentPrice} L.E
                  </li>
                ))
              ) : (
                <li>No products available</li>
              )}
            </ul>
            <div>Total Price : {totalPrice} L.E</div>
          </div>
        )}
      </div>
    </div>
  );
}
