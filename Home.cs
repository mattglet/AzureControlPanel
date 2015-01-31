using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AzureControlPanel.Models;

namespace AzureControlPanel
{
	public partial class Home : Form
	{
		private const int WM_QUERYENDSESSION = 0x11;
		private bool _isSystemShutdown = false;

		public Home()
		{
			InitializeComponent();
			LoadVMs();
		}

		private void LoadVMs()
		{
			_vmList.DataSource = VirtualMachine.GetAll();

			// An exception will be thrown if there's an issue
			Log("VM list successfully retrieved.");
		}

		protected void VMList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridViewRow row = _vmList.Rows[e.RowIndex];
			var statusCell = row.Cells["Status"];
			var actionCell = row.Cells["Action"];

			actionCell.Style.BackColor = Color.Transparent;

			if (statusCell.Value.ToString() == VirtualMachine.Statuses.StoppedDeallocated.ToString())
			{
				actionCell.Value = "Start";
			}
			else if (statusCell.Value.ToString() == VirtualMachine.Statuses.ReadyRole.ToString())
			{
				actionCell.Value = "Stop";
			}
		}

		protected void VMList_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			var row = _vmList.Rows[e.RowIndex];
			var clickedCell = row.Cells[e.ColumnIndex];
			var actionValue = clickedCell.Value.ToString();
			var vmName = row.Cells["Name"].Value.ToString();

			if (ShowMessageBox(string.Format("Are you sure you want to {0} the {1} VM?", actionValue, vmName), DialogResult.Yes))
			{
				if (actionValue == "Start")
				{
					StartVM(vmName);
				}
				else if (actionValue == "Stop")
				{
					StopVM(vmName);
				}

				LoadVMs();
			}
		}

		private void RefreshMenuItem_Click(object sender, EventArgs e)
		{
			LoadVMs();
		}

		private void StartAllMenuItem_Click(object sender, EventArgs e)
		{
			if (ShowMessageBox("Are you sure you want to Start all VMs?", DialogResult.Yes))
			{
				Log("Attempting to Start all VMs...");
				Log(VirtualMachine.StartAll());
				LoadVMs();
			}
		}

		private void StopAllMenuItem_Click(object sender, EventArgs e)
		{
			if (ShowMessageBox("Are you sure you want to Stop all VMs?", DialogResult.Yes))
			{
				Log("Attempting to Stop all VMs...");
				Log(VirtualMachine.StopAll());
				LoadVMs();
			}
		}

		private void StartVM(string vmName)
		{
			Log(string.Format("Attempting to start {0}...", vmName));

			var vm = new VirtualMachine(vmName);

			Log(vm.Start());
		}

		private void StopVM(string vmName)
		{
			Log(string.Format("Attempting to stop {0}", vmName));

			var vm = new VirtualMachine(vmName);

			Log(vm.Stop());
		}

		private void Log(string log)
		{
			_console.AppendText(string.Format("{0} - {1}{2}", DateTime.Now.ToString(), log, Environment.NewLine));
		}

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == WM_QUERYENDSESSION)
			{
				//MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot");
				_isSystemShutdown = true;
				m.Result = (IntPtr)0;
			}

			// If this is WM_QUERYENDSESSION, the closing event should be raised in the base WndProc.
			m.Result = (IntPtr)0;
			base.WndProc(ref m);
		} 

		private void Home_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_isSystemShutdown || true)
			{
				// Reset in case the shutdown is canceled
				_isSystemShutdown = false;

				if (HasActiveVM)
				{
					if (ShowMessageBox("You still have a VM that is still running. Are you sure you want to close the Control Panel?", DialogResult.Yes))
					{
						e.Cancel = false;
					}
					else
					{
						e.Cancel = true;
					}
				}
				else
				{
					e.Cancel = false;
				}
			}
		}

		public bool HasActiveVM
		{
			get
			{
				var hasActiveVM = false;

				foreach (DataGridViewRow row in _vmList.Rows)
				{
					if (row.Cells["Status"].Value.ToString() != VirtualMachine.Statuses.StoppedDeallocated.ToString())
					{
						hasActiveVM = true;
						break;
					}
				}

				return hasActiveVM;
			}
		}

		private bool ShowMessageBox(string message, DialogResult trueResult)
		{
			return MessageBox.Show(message, "Azure Control Panel", MessageBoxButtons.YesNo) == trueResult;
		}
	}
}
