using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartVendingMachineManager.Models
{
    public partial class Machine : ObservableObject
    {
        [ObservableProperty]
        private string machineId = string.Empty;

        [ObservableProperty]
        private string location = string.Empty;

        [ObservableProperty]
        private string status = "Offline";

        [ObservableProperty]
        private int totalItems;

        [ObservableProperty]
        private int capacity;

        public Machine Clone()
        {
            return new Machine {
                MachineId = this.MachineId,
                Location = this.Location,
                Status = this.Status,
                TotalItems = this.TotalItems,
                Capacity = this.Capacity,
            };
        }
    }
}
