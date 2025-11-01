namespace SmartVendingMachineManager.Models
{
    public class ActivityLogs
    {
        public DateTime Timestamp { get; set; }
        public string MachineId { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ActivityLogs(string machineId, string action, string description)
        {
            Timestamp = DateTime.Now;
            MachineId = machineId;
            Action = action;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Timestamp:HH:mm:ss}: Machine ID: VM-{MachineId} | Action: {Action} | Description: {Description}";
        }
    }
}
