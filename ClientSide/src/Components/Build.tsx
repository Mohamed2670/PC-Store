import React, { useState, useEffect } from "react";
import BuildSummary from "./BuildSummary";
import { useNavigate } from "react-router-dom";
import BuildCard from "./BuildCard";

// Main PC Builder Page
export default function Build({
  setBuildCategory,
  productBuild,
}: {
  setBuildCategory: React.Dispatch<React.SetStateAction<string>>;
  productBuild: ProductBuild[];
}) {
  const [selectedParts, setSelectedParts] = useState<any[]>([]);
  const navigate = useNavigate();

  const components = [
    { id: 1, categoryId: "1", name: "motherboard" },
    { id: 2, categoryId: "2", name: "graphic card" },
    { id: 3, categoryId: "3", name: "ram" },
    { id: 4, categoryId: "4", name: "processors" },
    { id: 5, categoryId: "6", name: "computer case" },
    { id: 6, categoryId: "7", name: "power supply" },
    { id: 7, categoryId: "17", name: "ssd" },
    { id: 8, categoryId: "18", name: "m.2" },
    { id: 9, categoryId: "23", name: "monitors" },
  ];

  // Function to handle part selection
  function handleSelect(option: any) {
    // Add selected part to the selectedParts state
    setSelectedParts((prev) => [
      ...prev,
      { id: option.id, categoryId: option.categoryId, name: option.name },
    ]);
    // Navigate to the category page
    navigate(`/products`);
  }

  return (
    <div className="min-h-screen bg-gray-900">
      <div className="mx-auto p-6">
        <h1 className="text-2xl font-bold text-center mb-8 text-white">
          Let's Build Your PC
        </h1>

        <div className="flex flex-col md:flex-row gap-6 justify-center items-center">
          {/* Left Section: BuildCard Components */}
          <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
            {components.map((option) => (
              <BuildCard
                key={option.id}
                cateName={option.name}
                cateId={option.categoryId}
                onSelect={handleSelect}
                setBuildCategory={setBuildCategory}
                productBuild={productBuild}
              />
            ))}
          </div>

          {/* Right Section: BuildSummary */}
          <div className="md:w-1/3">
            <BuildSummary />
          </div>
        </div>
      </div>
    </div>
  );
}
