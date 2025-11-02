using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using SmartVendingMachineManager.Models;

namespace SmartVendingMachineManager.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Machine> machines = new();

        [ObservableProperty]
        private ObservableCollection<ActivityLogs> activityLogs = new();

        [ObservableProperty]
        private Machine? selectedMachine;

        [ObservableProperty]
        private Machine? editMachine;

        [ObservableProperty]
        private string newMachineLocation = "New Location";

        [ObservableProperty]
        private string newMachineStatus = "Offline";

        [ObservableProperty]
        private int newMachineTotalItems = 0;

        [ObservableProperty]
        private int newMachineCapacity = 60;

        private int nextId = 1;

        private string newMachineId;
        public string NewMachineId { get => newMachineId; set => SetProperty(ref newMachineId, value); }

        public List<string> StatusOptions { get; } = new List<string>
        {
            "Offline",
            "Online",
            "Needs Restock",
            "Maintenance Required"
        };

        private void Log(string machineId, string action, string description)
        {
            var log = new ActivityLogs(machineId, action, description);
            Application.Current.Dispatcher.Invoke(() =>
            {
                ActivityLogs.Insert(0, log);

                // Keep only last 100 logs
                if (ActivityLogs.Count > 100)
                    ActivityLogs.RemoveAt(ActivityLogs.Count - 1);
            });
        }

        private bool CanUpdateMachine() =>
            EditMachine != null && !string.IsNullOrWhiteSpace(EditMachine.Location);

        private bool CanDeleteMachine() => SelectedMachine != null;

        public MainViewModel()
        {
            LoadSampleData();
            Log("", "System:", "Application started successfully");
        }

        private void LoadSampleData()
        {
            Machines.Add(new Machine
            {
                MachineId = (nextId++).ToString(),
                Location = "Subang Jaya",
                Status = "Online",
                TotalItems = 50,
                Capacity = 100
            });
            Machines.Add(new Machine
            {
                MachineId = (nextId++).ToString(),
                Location = "Shah Alam",
                Status = "Offline",
                TotalItems = 80,
                Capacity = 120
            });
            Machines.Add(new Machine
            {
                MachineId = (nextId++).ToString(),
                Location = "Kuala Lumpur",
                Status = "Maintenance Required",
                TotalItems = 50,
                Capacity = 200
            });
            Machines.Add(new Machine
            {
                MachineId = (nextId++).ToString(),
                Location = "Petaling Jaya",
                Status = "Needs Restock",
                TotalItems = 5,
                Capacity = 200
            });

            Log("", "System", "Load 4 sample vending machines");
        }

        [RelayCommand]
        private void AddMachine()
        {
            var newMachine = new Machine
            {
                MachineId = (nextId++).ToString(),
                Location = string.IsNullOrWhiteSpace(NewMachineLocation) ? "New Location" : NewMachineLocation,
                Status = NewMachineStatus,
                TotalItems = NewMachineTotalItems,
                Capacity = NewMachineCapacity
            };

            Machines.Add(newMachine);
            SelectedMachine = newMachine;

            OnPropertyChanged(nameof(newMachineId));

            Log(newMachine.MachineId, "Add Machine", $"Added new machine VM-{newMachine.MachineId}");
        }

        [RelayCommand(CanExecute = nameof(CanUpdateMachine))]
        private void UpdateMachine()
        {
            if (SelectedMachine != null && EditMachine != null)
            {
                var changes = new List<string>();

                if (SelectedMachine.Location != EditMachine.Location)
                    changes.Add($"Location: '{SelectedMachine.Location}' → '{EditMachine.Location}'");

                if (SelectedMachine.Status != EditMachine.Status)
                    changes.Add($"Status: '{SelectedMachine.Status}' → '{EditMachine.Status}'");

                if (SelectedMachine.TotalItems != EditMachine.TotalItems)
                    changes.Add($"Stock: {SelectedMachine.TotalItems} → {EditMachine.TotalItems}");

                if (SelectedMachine.Capacity != EditMachine.Capacity)
                    changes.Add($"Capacity: {SelectedMachine.Capacity} → {EditMachine.Capacity}");

                // Apply updates
                SelectedMachine.Location = EditMachine.Location;
                SelectedMachine.Status = EditMachine.Status;
                SelectedMachine.TotalItems = EditMachine.TotalItems;
                SelectedMachine.Capacity = EditMachine.Capacity;

                // Log the update
                if (changes.Any())
                {
                   Log(SelectedMachine.MachineId, "Update Machine",
                        $"Updated machine at '{SelectedMachine.Location}': " + string.Join("; ", changes));
                }

                MessageBox.Show("Machine updated successfully!", "Success",
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        [RelayCommand(CanExecute = nameof(CanDeleteMachine))]
        private void DeleteMachine()
        {
            if (SelectedMachine != null &&
                            MessageBox.Show($"Are you sure you want to delete the machine at '{SelectedMachine.Location}'?",
                                          "Confirm Delete",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var machineId = SelectedMachine.MachineId;
                var location = SelectedMachine.Location;

                Machines.Remove(SelectedMachine);
                SelectedMachine = null;
                EditMachine = null;

                Log(machineId, "Delete Machine", $"Deleted machine at '{location}'");
            }
        }

        [RelayCommand]
        private void ClearSelection()
        {
            SelectedMachine = null;
            EditMachine = null;
            Log("", "Clear Selection", "Cleared selected machine");
        }

        [RelayCommand]
        private void ToggleStatus()
        {
            if (SelectedMachine != null)
            {
                var oldStatus = SelectedMachine.Status;
                var newStatus = oldStatus == "Online" ? "Offline" : "Online";
                SelectedMachine.Status = newStatus;

                Log(SelectedMachine.MachineId, "Toggle Status",
                    $"Changed status from '{oldStatus}' to '{newStatus}' for machine at '{SelectedMachine.Location}'");

                MessageBox.Show($"Status changed to {newStatus}", "Status Updated");
            }
        }

        partial void OnSelectedMachineChanged(Machine? value)
        {
            EditMachine = value?.Clone();
            UpdateMachineCommand.NotifyCanExecuteChanged();
            DeleteMachineCommand.NotifyCanExecuteChanged();
        }

        partial void OnEditMachineChanged(Machine? value)
        {
            UpdateMachineCommand.NotifyCanExecuteChanged();
        }
    }
}