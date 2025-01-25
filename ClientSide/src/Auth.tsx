import axios from "axios";
import { redirect } from "react-router-dom";


export default async function Auth() {
    return await ValidateAccessToken();
}
async function ValidateAccessToken() {
  const API_URL = `http://localhost:5218/auth/token-test`;
  const BEARER_TOKEN = localStorage.getItem("AccessToken");
  try {
    await axios.get(API_URL, {
      headers: {
        Authorization: `Bearer ${BEARER_TOKEN}`,
      },
    });
    return true;
  } catch (error) {
    var ret =  await ValidateRefreshToken();
      console.error("Error:", error);
      return ret;
  }
}
async function ValidateRefreshToken() {
  const API_URL = `http://localhost:5218/auth/access-token`;
  const BEARER_TOKEN = localStorage.getItem("RefreshToken");

  try {
    const response = await axios.post(API_URL, {
      headers: {
        Authorization: `Bearer ${BEARER_TOKEN}`,
      },
    });
    console.log(response.data.userId);

    localStorage.setItem("AccessToken", response.data.accessToken);
    localStorage.setItem("RefreshToken", response.data.refreshToken);
    localStorage.setItem("UserId", response.data.userId);
    return true;
  } catch (error) {
      localStorage.clear();
      return false;
  }
}
