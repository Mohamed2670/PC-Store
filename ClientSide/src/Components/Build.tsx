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
    { id: 1, categoryId: "1", name: "Motherboards" },
    { id: 2, categoryId: "2", name: "Graphics Cards" },
    { id: 3, categoryId: "5", name: "RAM" },
    { id: 4, categoryId: "7", name: "Processors" },
    { id: 5, categoryId: "9", name: "Computer Cases" },
    { id: 6, categoryId: "10", name: "Power Supplies" },
    { id: 7, categoryId: "13", name: "Internal Storage" },
    { id: 8, categoryId: "32", name: "Monitors" },
    { id: 9, categoryId: "33", name: "Storage" },
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
