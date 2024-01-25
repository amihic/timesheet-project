import { useEffect, useState } from "react"
import Projects from "../../components/Projects/Projects"
import ProjectService from "../../services/ProjectService"

function ProjectsPage()
{
    const [projects, setProjects] = useState<Category[]>([])

    useEffect(()=>{
        ProjectService.getProjects().then(res=>setProjects(res))
    },[])
    
    return <Projects projects={projects}/>

}

export default ProjectsPage