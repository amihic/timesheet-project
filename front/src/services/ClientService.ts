import axios from "axios";
import AuthService from "./AuthService";

const url = "https://localhost:7161/allClients";

async function getClients(): Promise<Client[]> {
  const authToken = AuthService.getAuthToken();

  var cfg = {
    headers: {
      Authorization: "Bearer " + authToken,
    },
  };

  const res = await axios.get(url, cfg);

  console.log(res.data);
  return res.data;
}

const ClientService = {
  getClients,
};

export default ClientService;
