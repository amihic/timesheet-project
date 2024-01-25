import { useEffect, useState } from "react"
import ClientService from "../../services/ClientService"
import Clients from "../../components/Clients/Clients"

function ClientsPage()
{
    const [clients, setClients] = useState<Client[]>([])

    useEffect(()=>{
        ClientService.getClients().then(res => setClients(res))
    },[])
    
    return <Clients clients={clients}/>

}

export default ClientsPage