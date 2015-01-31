using System.Windows.Forms;

namespace AzureControlPanel
{
	partial class Home
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._vmList = new System.Windows.Forms.DataGridView();
			this.Action = new System.Windows.Forms.DataGridViewLinkColumn();
			this._menuStrip = new System.Windows.Forms.MenuStrip();
			this.virtualMachinesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._console = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this._vmList)).BeginInit();
			this._menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// _vmList
			// 
			this._vmList.AllowUserToAddRows = false;
			this._vmList.AllowUserToDeleteRows = false;
			this._vmList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._vmList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action});
			this._vmList.Location = new System.Drawing.Point(13, 49);
			this._vmList.Name = "_vmList";
			this._vmList.ReadOnly = true;
			this._vmList.Size = new System.Drawing.Size(1077, 318);
			this._vmList.TabIndex = 0;
			this._vmList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VMList_CellClick);
			this._vmList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.VMList_CellFormatting);
			// 
			// Action
			// 
			this.Action.HeaderText = "Action";
			this.Action.Name = "Action";
			this.Action.ReadOnly = true;
			this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// _menuStrip
			// 
			this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.virtualMachinesMenuItem});
			this._menuStrip.Location = new System.Drawing.Point(0, 0);
			this._menuStrip.Name = "_menuStrip";
			this._menuStrip.Size = new System.Drawing.Size(1102, 24);
			this._menuStrip.TabIndex = 1;
			this._menuStrip.Text = "menuStrip1";
			// 
			// virtualMachinesMenuItem
			// 
			this.virtualMachinesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshMenuItem,
            this.startAllMenuItem,
            this.stopAllMenuItem});
			this.virtualMachinesMenuItem.Name = "virtualMachinesMenuItem";
			this.virtualMachinesMenuItem.Size = new System.Drawing.Size(107, 20);
			this.virtualMachinesMenuItem.Text = "Virtual Machines";
			// 
			// refreshMenuItem
			// 
			this.refreshMenuItem.Name = "refreshMenuItem";
			this.refreshMenuItem.Size = new System.Drawing.Size(115, 22);
			this.refreshMenuItem.Text = "Refresh";
			this.refreshMenuItem.Click += new System.EventHandler(this.RefreshMenuItem_Click);
			// 
			// startAllMenuItem
			// 
			this.startAllMenuItem.Name = "startAllMenuItem";
			this.startAllMenuItem.Size = new System.Drawing.Size(115, 22);
			this.startAllMenuItem.Text = "Start All";
			this.startAllMenuItem.Click += new System.EventHandler(this.StartAllMenuItem_Click);
			// 
			// stopAllMenuItem
			// 
			this.stopAllMenuItem.Name = "stopAllMenuItem";
			this.stopAllMenuItem.Size = new System.Drawing.Size(115, 22);
			this.stopAllMenuItem.Text = "Stop All";
			this.stopAllMenuItem.Click += new System.EventHandler(this.StopAllMenuItem_Click);
			// 
			// _console
			// 
			this._console.Location = new System.Drawing.Point(13, 374);
			this._console.Multiline = true;
			this._console.Name = "_console";
			this._console.ReadOnly = true;
			this._console.Size = new System.Drawing.Size(1077, 294);
			this._console.TabIndex = 2;
			// 
			// Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1102, 680);
			this.Controls.Add(this._console);
			this.Controls.Add(this._vmList);
			this.Controls.Add(this._menuStrip);
			this.MainMenuStrip = this._menuStrip;
			this.Name = "Home";
			this.Text = "Azure Control Panel";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this._vmList)).EndInit();
			this._menuStrip.ResumeLayout(false);
			this._menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private DataGridView _vmList;
		private DataGridViewLinkColumn Action;
		private MenuStrip _menuStrip;
		private ToolStripMenuItem virtualMachinesMenuItem;
		private ToolStripMenuItem refreshMenuItem;
		private ToolStripMenuItem startAllMenuItem;
		private ToolStripMenuItem stopAllMenuItem;
		private TextBox _console;
	}
}

