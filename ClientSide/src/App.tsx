import { BrowserRouter, Route, Routes } from "react-router-dom";
import Signin from "./Components/Signin";
import Signup from "./Components/Signup";
import Navbar from "./Components/Navbar";
import Auth from "./Auth";
import Home from "./Components/Home";
import { useEffect, useState } from "react";
import Product from "./Components/Product";
import ProductDetails from "./Components/ProductDetails";
import Build from "./Components/Build";
import Builds from "./Components/Builds";

function App() {
  const [IsAuthorized, setIsAuthorized] = useState(true);
  const [buildCategory, setBuildCategory] = useState("");
  const [productBuild, setProductBuild] = useState<ProductBuild[]>([]);
  useEffect(() => {
    const checkAuth = async () => {
      const isAuthenticated = await Auth();
      setIsAuthorized(isAuthenticated);
      if (!isAuthenticated) {
        console.log("User not authenticated, redirecting to sign-in...");
      }
    };
    checkAuth();
  }, []);
  return (
    <>
      <div className=" ">
        <Navbar IsAuthorized={IsAuthorized} />
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/sign-in" element={<Signin />} />
            <Route path="/builds" element={<Builds />} />
            <Route path="/sign-up" element={<Signup />} />
            <Route path="/Build" element={<Build setBuildCategory={setBuildCategory } productBuild={productBuild} />} />
            <Route path="/products" element={<Product buildCategory={buildCategory} setProductBuild={setProductBuild} />} />
            <Route path="/products/details/:id" element={<ProductDetails />} />
          </Routes>
        </BrowserRouter>
      </div>
    </>
  );
}

export default App;
