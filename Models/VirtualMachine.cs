using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureControlPanel.DataAccess;
using System.Management.Automation;

namespace AzureControlPanel.Models
{
	public class VirtualMachine
	{
		public VirtualMachine(string name)
		{
			Name = name;
		}

		private VirtualMachine(DataRow dr)
		{
			Initialize(dr);
		}

		private void Initialize(DataRow dr)
		{
			Name = dr["Name"].ToString();
			ServiceName = dr["ServiceName"].ToString();
			Status = dr["Status"].ToString();
		}

		public string Name { get; set; }

		public string ServiceName { get; set; }

		public string Status { get; set; }

		public enum Statuses
		{
			StoppedDeallocated = 1,
			RoleStateUnknown = 2,
			StartingVM = 3,
			ReadyRole = 4
		}

		public static List<VirtualMachine> GetAll()
		{
			var v = new VirtualMachines();
			var returnList = new List<VirtualMachine>();

			foreach (DataRow dr in v.GetAll().Rows)
			{
				returnList.Add(new VirtualMachine(dr));
			}

			return returnList;
		}

		public string Start()
		{
			var v = new VirtualMachines();

			return v.Start(Name);
		}

		public static string StartAll()
		{
			var v = new VirtualMachines();

			return v.StartAll();
		}

		public string Stop()
		{
			var v = new VirtualMachines();

			return v.Stop(Name);
		}

		public static string StopAll()
		{
			var v = new VirtualMachines();

			return v.StopAll();
		}
	}
}
