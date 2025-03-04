import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { getAllProduct } from './api.js';


function App() {

    const [product, setproduct] = useState([])

useEffect(()=>{
getAllProduct().then(a=>{
    console.log("bbbb")
setproduct(a.data)});

},[])


    return (
        <div>


            <h1>PRODUCTS</h1>
            {

               !product|| product.length == 0 ? <div>טוען נתנוים.....</div> :
                    <ul>
                        {product.map((s,i) => <li key={i}>{s.name}  |  {s.description}  |   {s.price}</li>)}
                    </ul>
            }
        </div>
    );
}

export default App;