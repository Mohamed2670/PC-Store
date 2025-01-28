import axios from "axios";
import { useState } from "react";
import { redirect } from "react-router-dom";
interface SignInFormState {
  email: string;
  password: string;
}
const request = "http://localhost:5218/auth/login";
export default function Signin() {
  const [formData, setFormData] = useState<SignInFormState>({
    email: "",
    password: "",
  });

  const [status, setStatus] = useState<string>("");

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));
  };
  const handleSubmit = async (e: React.ChangeEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      setStatus("");
      const response = await axios.post(request, formData);
      console.log(response.data.userId);

      localStorage.setItem("AccessToken", response.data.accessToken);
        localStorage.setItem("RefreshToken", response.data.refreshToken);
        localStorage.setItem("UserId", response.data.userId);
        window.location.href = "/";
    } catch (error: any) {
      setStatus(error.response.data);
      console.log(error.response.data);
    }
  };
  return (
    <>
      <div className="flex items-center justify-center min-h-screen bg-gray-100 dark:bg-gray-900">
        <div className="w-full max-w-md p-6 shadow-lg rounded-2xl bg-white dark:bg-gray-800">
          <h1 className="text-2xl font-bold text-center text-gray-800 dark:text-white mb-4">
            Sign In
          </h1>
          <div className="space-y-4">
            <form onSubmit={handleSubmit}>
              {status && <p className="text-red-700">{status}</p>}
              <div className="space-y-4">
                <input
                  onChange={handleChange}
                  value={formData.email}
                  name="email"
                  type="email"
                  placeholder="Email Address"
                  className="w-full px-4 py-2 border rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none text-white"
                />
                <input
                  onChange={handleChange}
                  value={formData.password}
                  name="password"
                  type="password"
                  placeholder="Password"
                  className="w-full px-4 py-2 border rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none text-white"
                />

                <button className="w-full py-2 text-white bg-blue-600 rounded-md hover:bg-blue-700">
                  Sign In
                </button>
              </div>
            </form>
          </div>
          <p className="mt-4 text-sm text-center text-gray-600 dark:text-gray-400">
            Don't have an account?{" "}
            <a
              href="/sign-up"
              className="text-blue-600 hover:underline dark:text-blue-400"
            >
              Sign Up
            </a>
          </p>
        </div>
      </div>
    </>
  );
}
