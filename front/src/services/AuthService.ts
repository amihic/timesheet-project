import axios from "axios"

const url = 'localhost:7161/api'

async function login(email:string, password:string) {
    const res = await axios.post(url + "/login", {
        email:email,
        password:password
    },
    {
        headers:{
            Authorization: "Bearer " + localStorage.getItem("token")
        }
    }
    )
    localStorage.setItem("token", res.data)
}

const AuthService = {
    login
}

export default AuthService