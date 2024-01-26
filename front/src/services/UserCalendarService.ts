import axios from "axios";
import AuthService from "./AuthService";

const url = "https://localhost:7161/workingCalendar";

async function getUserCalendar(): Promise<UserCalendar> {

const authToken = AuthService.getAuthToken();

 var cfg = {
    headers: {
       Authorization: "Bearer " + authToken
    }
 }

const res = await axios.get(url, cfg);

  console.log(res.data);
  return res.data;
}


const CategoryService = {
    getUserCalendar,
};

export default CategoryService;
