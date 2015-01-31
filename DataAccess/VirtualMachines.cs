using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace AzureControlPanel.DataAccess
{
	public class VirtualMachines
	{
		private string BuildLog(PSDataCollection<ErrorRecord> errors, string successMessage)
		{
			var log = new StringBuilder();

			if (errors.Any())
			{
				foreach (ErrorRecord e in errors)
				{
					log.AppendLine("Error: " + e.Exception.Message);
				}
			}
			else
			{
				log.AppendLine(successMessage);
			}

			return log.ToString();
		}

		public DataTable GetAll()
		{
			using (PowerShell ps = PowerShell.Create())
			{
				ps.AddScript("Get-AzureVM");

				Collection<PSObject> output = ps.Invoke();

				if (ps.Streams.Error.Any())
				{
					throw new Exception("There was a problem getting the VMs:" + ps.Streams.Error[0].ErrorDetails.Message);
				}

				DataTable returnData = new DataTable();
				returnData.Columns.Add("ServiceName");
				returnData.Columns.Add("Name");
				returnData.Columns.Add("Status");

				foreach (PSObject psObject in output)
				{
					DataRow row = returnData.NewRow();
					row["ServiceName"] = psObject.Properties["ServiceName"].Value.ToString();
					row["Name"] = psObject.Properties["Name"].Value.ToString();
					row["Status"] = psObject.Properties["Status"].Value.ToString();
					returnData.Rows.Add(row);
				}

				return returnData;
			}
		}

		public string Start(string name)
		{
			using (PowerShell ps = PowerShell.Create())
			{
				ps.AddCommand("Start-AzureVM");
				ps.AddParameter("ServiceName", name);
				ps.AddParameter("Name", name);

				Collection<PSObject> output = ps.Invoke();

				return BuildLog(ps.Streams.Error, "VM (" + name + ") successfully started.");
			}
		}

		public string StartAll()
		{
			using (PowerShell ps = PowerShell.Create())
			{
				ps.AddScript("Get-AzureVM | ForEach-Object { Start-AzureVM -ServiceName $_.ServiceName -Name $_.Name }");

				Collection<PSObject> output = ps.Invoke();

				return BuildLog(ps.Streams.Error, "All VMs successfully started.");
			}
		}

		public string Stop(string name)
		{
			using (PowerShell ps = PowerShell.Create())
			{
				ps.AddCommand("Stop-AzureVM");
				ps.AddParameter("ServiceName", name);
				ps.AddParameter("Name", name);
				ps.AddParameter("Force");

				Collection<PSObject> output = ps.Invoke();

				return BuildLog(ps.Streams.Error, "VM (" + name + ") successfully stopped.");
			}
		}

		public string StopAll()
		{
			using (PowerShell ps = PowerShell.Create())
			{
				ps.AddScript("Get-AzureVM | ForEach-Object { Stop-AzureVM -ServiceName $_.ServiceName -Name $_.Name -Force }");

				Collection<PSObject> output = ps.Invoke();

				return BuildLog(ps.Streams.Error, "All VMs successfully stopped.");
			}
		}
	}
}
