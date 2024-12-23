import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "../pages/Home/Home";
//import BookDetails from "../pages/BookDetails/BookDetails";
//import ManageBooks from "../pages/ManageBooks/ManageBooks";
//import Login from "../pages/Login/Login";
//import Signup from "../pages/Signup/Signup";
//import NotFound from "../pages/NotFound";
/*
const AppRoutes = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/book/:id" element={<BookDetails />} />
        <Route path="/manage-books" element={<ManageBooks />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Signup />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
    </Router>
  );
};
*/

const AppRoutes = () => {
    return (
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
        </Routes>
      </Router>
    );
  };
export default AppRoutes;