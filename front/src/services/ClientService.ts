import axios from "axios"

const url = "https://localhost:7161/allClients"

async function getClients() : Promise<Client[]>{
    const res = await axios.get(url)

    console.log(res.data)
    return res.data
}

const ClientService = {
    getClients,

}

export default ClientService