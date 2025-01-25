import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Signin from './Components/Signin'
import Signup from './Components/Signup'
import Navbar from './Components/Navbar'
import Auth from './auth'
import Home from './Components/Home'
import { useEffect } from 'react'

function App() {
  useEffect(() => {
    const checkAuth = async () => {
      const isAuthenticated = await Auth();
      if (!isAuthenticated) {
        console.log("User not authenticated, redirecting to sign-in...");
      }
    }
  checkAuth();
  },[]);
  return (
    <>
      
      <Navbar/>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/sign-in" element={ <Signin/>} />
          <Route path="/sign-up" element={ <Signup/>} />

        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
