type ClientsProps = {
    username:string
}

function Clients({username}:ClientsProps) {
    return <div>NAME: {username}</div>
}

export default Clients