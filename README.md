# Smart Vending Machine Manager

## Requirements
- Windows 10/11
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Quick Start
1. Install the .NET 8 SDK if not already installed (link above)
2. Double-click `run.bat`
3. The script will automatically restore packages, build, and launch the app

## What to Test:

### 1. Read List of Sample Vending Machines
- View the pre-loaded vending machines in the list
- Click on different machines to see their details
- Observe the status indicators (Online/Offline/Needs Restock/Maintenance Required)

### 2. Add/Update/Delete Vending Machines
- **Add**: Use the "Add New Vending Machine" section to create new vending machines
- **Update**: Select a vending machine location at the lists, edit its details at details panel, and click "Update" to proceed or "Clear" to reset
- **Delete**: Select a vending machine location and click "Delete"

### 3. Observe Activity Log
- Watch the Activity Logs section for real-time operation tracking
- Each CRUD operation is logged with timestamps