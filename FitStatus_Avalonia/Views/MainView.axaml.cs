using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views
{
    public partial class MainView : UserControl
    {
        private MainViewModel viewModel;

        public MainView()
        {
            InitializeComponent();
            viewModel = new MainViewModel(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}