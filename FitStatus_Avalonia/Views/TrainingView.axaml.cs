using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views
{
    public partial class TrainingView : UserControl
    {
        public TrainingView()
        {
            InitializeComponent();
            DataContext = new TrainingViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}