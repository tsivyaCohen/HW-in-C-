import axios from "axios";

const URL = "https://localhost:7081/api";



export const  getAllProduct = async() => {
    try{
          const res= await axios.get(URL + "/Product")
          console.log("aaa")
      return res;
    }
catch(e){
    throw e;
}
}

