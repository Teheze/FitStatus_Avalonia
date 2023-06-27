namespace FitStatus_Avalonia.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public string? Name { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }
    }
}