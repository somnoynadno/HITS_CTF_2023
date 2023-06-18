import './App.css';
import {Route, Routes} from "react-router-dom";
import {NavBar} from "./Components/Navbar";
import {HomePage} from "./Pages/HomePage";
import {CatalogPage} from "./Pages/CatalogPage";
import {AddDishPage} from "./Pages/addDishPage";

function App() {
  return (
        <div className="App">
            <NavBar/>
            <Routes>
                <Route path="/" element={<HomePage/>}/>
                <Route path="/catalog/:id" element={<CatalogPage/>}/>
                <Route path="/add/dish" element={<AddDishPage/>}/>
            </Routes>
        </div>
  );
}

export default App;
