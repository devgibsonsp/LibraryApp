import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "../pages/Home/Home"; // Replace with the actual path to your Home component
import Dashboard from "../pages/Dashboard/Dashboard"; // Replace with the actual path to your Dashboard component v

const AppRoutes = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/dashboard" element={<Dashboard />} />
      </Routes>
    </Router>
  );
};

export default AppRoutes;