

type ReportsProps = {
    reports: ReportUser[];
  };
  
  function Reports({ reports }: ReportsProps) {
    return (

<div className="wrapper">
			<section className="content">
				<h2><i className="ico report"></i>Reports</h2>
				<div className="grey-box-wrap reports">
					<ul className="form">
						<li>
							<label>Team member:</label>
							<select>
								<option>All</option>
							</select>
						</li>
						<li>
							<label>Category:</label>
							<select>
								<option>All</option>
							</select>
						</li>						
					</ul>
					<ul className="form">
						<li>
							<label>Client:</label>
							<select>
								<option>All</option>
							</select>
						</li>						
						<li>
							<label>Start date:</label>
							<input type="text" className="in-text datepicker hasDatepicker" id="dp1706192448978"/>
						</li>
					</ul>
					<ul className="form last">
						<li>
							<label>Project:</label>
							<select>
								<option>All</option>
							</select>
						</li>
						<li>
							<label>End date:</label>
							<input type="text" className="in-text datepicker hasDatepicker" id="dp1706192448979"/>
						</li>
						<li>
							<a href="javascript:;" className="btn orange right">Reset</a>
							<a href="javascript:;" className="btn green right">Search</a>
						</li>
					</ul>
				</div>
				
				<table>
				<thead>
					<tr>
					<th>Date</th>
					<th>Client</th>
					<th>Project</th>
					<th>Category</th>
					<th>Description</th>
					<th>Time</th>
					{/* <th>Project</th>
					<th>Role</th>
					<th>Description</th>
					<th className="small">Hours</th> */}
					</tr>
				</thead>
				<tbody>
					{reports.map((item, index) => (
					<tr key={index}>
						<td>{item.date}</td>
						<td>{item.client.name}</td>
						<td>{item.project.name}</td>
						<td>{item.category.name}</td>
						<td>{item.description}</td>
						<td>{item.time}</td>
						{/* <td>{item.project}</td>
						<td>{item.role}</td>
						<td>{item.description}</td>
						<td className="small">{item.hours}</td> */}
					</tr>
					))}
				</tbody>
				</table>
				<div className="total">
					<span>Report total: <em>7.5</em></span>
				</div>
				<div className="grey-box-wrap reports">
					<div className="btns-inner">
						<a className="btn white">
							<span>Print report</span>
						</a>
						<a className="btn white">
							<span>Create PDF</span>
						</a>
						<a className="btn white">
							<span>Export to excel</span>
						</a>
					</div>
				</div>
			</section>			
		</div>
    );
  }

  export default Reports;