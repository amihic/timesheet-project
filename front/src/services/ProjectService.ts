import axios from "axios"

const url = "https://localhost:7161/allProjects"

async function getProjects() : Promise<Project[]>{
    const res = await axios.get(url)

    console.log(res.data)
    return res.data
}

const ProjectService = {
    getProjects,

}

export default ProjectService