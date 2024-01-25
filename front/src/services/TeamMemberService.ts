import axios from "axios"

const url = "https://localhost:7161/allUsers"

async function getTeamMembers() : Promise<TeamMember[]>{
    const res = await axios.get(url)

    console.log(res.data)
    return res.data
}

const TeamMemberService = {
    getTeamMembers,

}

export default TeamMemberService