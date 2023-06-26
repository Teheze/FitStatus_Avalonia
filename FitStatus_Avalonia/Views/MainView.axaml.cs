using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
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