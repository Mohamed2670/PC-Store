import axios from "axios";
import { useState } from "react";
interface SignUpFormState {
  name: string;
  email: string;
  password: string;
}
const request = "http://localhost:5218/auth/register";
export default function Signup() {
  const [formData, setFormData] = useState<SignUpFormState>({
    name: "",
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
      const response = await axios.post(request, formData);
        console.log(response);
        
    }
    catch (error: any) {
      console.log(error.response.data);
      console.log(formData.password.length);
      if (formData.name.length < 1) {
        setStatus("missing name field");
      } else if (formData.email.length < 1) {
        setStatus("missing email field");
      } else if (formData.password.length < 1) {
        setStatus("missing password field");
      } else if (formData.password.length < 8) {
        setStatus("Password is too short");
      } else {
        setStatus(error.response.data);
      }
    }
  };
  return (
    <>
      <div className="flex items-center justify-center min-h-screen bg-gray-100 dark:bg-gray-900">
        <div className="w-full max-w-md p-6 shadow-lg rounded-2xl bg-white dark:bg-gray-800">
          <h1 className="text-2xl font-bold text-center text-gray-800 dark:text-white mb-4">
            Sign Up
          </h1>
          <div className="space-y-4">
            <form onSubmit={handleSubmit}>
              <p className="text-red-700">{status}</p>
              <div className="space-y-4">
                <input
                  onChange={handleChange}
                  value={formData.name}
                  name="name"
                  type="text"
                  placeholder="Name"
                  className="w-full px-4 py-2 border rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none text-white"
                />
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
                  Sign Up
                </button>
              </div>
            </form>
          </div>
          <p className="mt-4 text-sm text-center text-gray-600 dark:text-gray-400">
            Already have an account?{" "}
            <a
              href="/"
              className="text-blue-600 hover:underline dark:text-blue-400"
            >
              Sign In
            </a>
          </p>
        </div>
      </div>
    </>
  );
}
