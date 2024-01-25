import { useEffect, useState } from "react"
import TeamMemberService from "../../services/TeamMemberService"
import TeamMembers from "../../components/TeamMembers/TeamMembers"

function TeamMembersPage()
{
    const [teamMembers, setTeamMembers] = useState<TeamMember[]>([])

    useEffect(()=>{
        TeamMemberService.getTeamMembers().then(res=>setTeamMembers(res))
    },[])
    
    return <TeamMembers teamMembers={teamMembers}/>

}

export default TeamMembersPage