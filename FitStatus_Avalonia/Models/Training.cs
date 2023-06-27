using System;

namespace FitStatus_Avalonia.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}