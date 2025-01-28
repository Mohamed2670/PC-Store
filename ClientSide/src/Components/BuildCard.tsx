import { useEffect, useState } from "react";

export default function BuildCard({
  cateName,
  cateId,
  onSelect,
  setBuildCategory,
  productBuild,
}: {
  cateName: string;
  cateId: string;
  onSelect: (option: any) => void;
  setBuildCategory: React.Dispatch<React.SetStateAction<string>>;
  productBuild: ProductBuild[];
}) {
  const [buildz, setBuildz] = useState<ProductBuild[]>([]);

  useEffect(() => {
    const storedSettings = localStorage.getItem("Build");
    if (storedSettings) {
      setBuildz(JSON.parse(storedSettings));
    }
  }, []);

  useEffect(() => {
    if (productBuild && productBuild.length > 0) {
      localStorage.setItem("Build", JSON.stringify(productBuild));
      setBuildz(productBuild);
    }
  }, [productBuild]);

  function handleBuildCategory() {
    setBuildCategory(cateId);
    onSelect({ name: cateName, categoryId: cateId, id: cateId });
  }

  return (
    <div className="flex flex-col justify-center items-center p-4">
  <button
    onClick={handleBuildCategory}
    className="w-24 h-24 bg-blue-600 text-white font-semibold rounded-lg shadow-lg hover:bg-blue-700 hover:scale-105 hover:shadow-xl focus:outline-none focus:ring-4 focus:ring-blue-300 transition-all duration-300"
  >
    <div className="text-center">{cateName}</div>
  </button>
  {/* Fixed height to avoid layout shifting */}
  <div
    className="mt-2 text-white text-center w-24 truncate overflow-hidden"
    style={{ minHeight: "50px" }} // Adjust height as needed
  >
    {buildz
      .filter((product) => product.buildCategory === cateId)
      .map((product) => (
        <div key={product.id} className="truncate">
          {product.name}
        </div>
      ))}
  </div>
</div>

  );
}