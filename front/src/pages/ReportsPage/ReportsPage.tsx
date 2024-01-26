import { useEffect, useState } from "react"
import ReportService from "../../services/ReportService"
import Reports from "../../components/Reports/Reports"

function ReportsPage()
{
    const [reports, setReports] = useState<ReportUser[]>([])

    useEffect(()=>{
        ReportService.getReports().then(res=>setReports(res))
    },[])

    return <Reports reports={reports}/>

}

export default ReportsPage