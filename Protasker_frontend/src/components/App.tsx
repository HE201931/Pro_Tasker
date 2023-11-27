import "./App.scss"

import {Route, Routes} from "react-router-dom"
import {Suspense, lazy} from "react"

const Tasks = lazy(() => import("../pages/Tasks/Tasks"));
const Graph = lazy(() => import("../pages/Graph/Graph"));

import Navbar from "../components/Navbar/Navbar";

function App() {
  return (
    <Suspense fallback={<p>loading...</p>}>
      <Navbar />
      <Routes>
          <Route index element={<Tasks />} />
          <Route path="/graph" element={<Graph />}/>
          <Route path="*" element={<p style={{paddingTop:"100px"}}>no pages...</p>} />
      </Routes>
    </Suspense>
  )
}

export default App