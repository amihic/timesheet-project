import axios from "axios";
import AuthService from "./AuthService";

const url = "https://localhost:7161/allCategories";

async function getCategories(): Promise<Category[]> {

 var cfg = {
    headers: {
       Authorization: "Bearer " + AuthService.getAuthToken()
    }
 }

const res = await axios.get(url, cfg);


  console.log(res.data);
  return res.data;
}

const CategoryService = {
  getCategories,
};

export default CategoryService;
