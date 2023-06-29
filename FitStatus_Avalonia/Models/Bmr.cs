using System;

namespace FitStatus_Avalonia.Models
{
    public class Bmr
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Info { get; set; }
        public DateTime? Time { get; set; }
    }
}