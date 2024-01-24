import Clients from "../../components/Clients/Clients"

function ClientsPage()
{
    const calledFromback = {
        username: "KEKEKE"
    }
    return <Clients username={calledFromback.username}/>

}

export default ClientsPage