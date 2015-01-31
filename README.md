# AzureControlPanel
A super basic app to control the start/stop process of your Azure Virtual Machines.  I created this app to ensure that I don't forget to turn off a VM that doesn't need to run 24/7 (and waste money).

Highlights
=====
* When the app is running, it will prompt you when you either close it or if you shutdown your machine to stop your VMs (it will allow you to cancel your Shutdown, if applicable)
* Start/Stop one VM or all VMs in your Azure account
* Refresh your VM list to update the up/down status
* Logging console to provide feedback about each command you perform

Prerequisites
=====
* Install [Azure Powershell](http://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/#Install)
* [Import](http://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/#use-the-certificate-method) your Azure subscription information

Usage
=====
* Compile the solution, copy all bin/debug folder contents to a folder where you'll run the app going forward.
* Run AzureControlPanel.exe to display your VM list
* If you have a "StoppedDeallocated" VM, click the Start link to start it
* If you have a "ReadyRole" VM, click the Stop link to shut it down and deallocate it
* Use the "Virtual Machines" menu to Refresh the list, or Start/Stop your entire list (you will be required to confirm)

Known Bugs/Issues
=====
* If you click any cell in the row, you will trigger the Action in the Action column (and it will use an incorrect prompt message)
* Every command will lock the UI thread, and make the app seem unresponsive for ~5 seconds
* The UI is really ugly
* I've only tested on my local machine, there might be dependency bugs
