import axios from "axios";
import React, { useEffect, useState } from "react";

export default function BuildSummary() {
  const [build, setBuild] = useState<ProductBuild[]>([]);
  const [buildName, setBuildName] = useState<string>("");

  useEffect(() => {
    const storedSettings = localStorage.getItem("Build");
    if (storedSettings) {
      setBuild(JSON.parse(storedSettings));
    }
  }, []);

  const totalPrice = build.reduce(
    (total: number, part: any) => total + part.price,
    0
  );

  async function handleSave() {
    if (!buildName.trim()) {
      alert("Please enter a build name.");
      return;
    }
    const id = localStorage.getItem("UserId");
    const buildData = {
      name: buildName,
      userId: id,
      cpuId: build.find((part) => part.buildCategory === "4")?.id || 0,
      gpuId: build.find((part) => part.buildCategory === "2")?.id || 0,
      motherBoardId: build.find((part) => part.buildCategory === "1")?.id || 0,
      ramId: build.find((part) => part.buildCategory === "3")?.id || 0,
      caseId: build.find((part) => part.buildCategory === "6")?.id || 0,
      powerSupplyId: build.find((part) => part.buildCategory === "7")?.id || 0,
      hddId: build.find((part) => part.buildCategory === "17")?.id || 0,
      sddId: build.find((part) => part.buildCategory === "18")?.id || 0,
      totalPrice: totalPrice.toFixed(2),
    };

    try {
      const requestUrl = "http://localhost:5218/build";
      const response = await axios.post(requestUrl, buildData);
      console.log(response.data);
      alert("Build saved successfully!");
      localStorage.setItem("Build", "");
      
    } catch (error) {
      console.error("Error saving build:", error);
      alert("Failed to save build.");
    }
  }

  return (
    <div className="bg-white border rounded-lg shadow-lg p-4 max-w-md mx-auto">
      <h2 className="text-xl font-bold mb-4 text-gray-800">Build Summary</h2>
      <ul className="divide-y divide-gray-200">
        {build.map((part: any, index: number) => (
          <li
            key={index}
            className="flex justify-between items-center py-2 text-gray-700"
          >
            <span className="truncate w-2/3" title={part.name}>
              {part.name}
            </span>
            <span className="text-gray-900 font-medium">{part.price} L.E</span>
          </li>
        ))}
      </ul>
      <hr className="my-4 border-gray-300" />
      <div className="flex justify-between text-lg font-bold text-gray-900">
        <span>Total:</span>
        <span>{totalPrice.toFixed(2)} L.E</span>
      </div>
      {/* Build Name Input */}
      <div className="mt-4">
        <label
          htmlFor="buildName"
          className="block text-sm font-medium text-gray-700"
        >
          Build Name
        </label>
        <input
          type="text"
          id="buildName"
          value={buildName}
          onChange={(e) => setBuildName(e.target.value)}
          placeholder="Enter build name"
          className="mt-1 block w-full border border-gray-300 rounded-lg shadow-sm py-2 px-3 focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
        />
      </div>
      {/* Save Button */}
      <button
        onClick={handleSave}
        className="mt-4 w-full bg-blue-600 text-white font-semibold rounded-lg shadow-md py-2 hover:bg-blue-700 hover:shadow-lg focus:outline-none focus:ring-4 focus:ring-blue-300 transition-all duration-300"
      >
        Save
      </button>
    </div>
  );
}