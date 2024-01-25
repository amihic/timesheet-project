import axios from "axios"

const url = "https://localhost:7161/allCategories"

async function getReports() : Promise<Report[]>{
    const res = await axios.get(url)

    console.log(res.data)
    return res.data
}

const ReportService = {
    getReports,
    
}

export default ReportService