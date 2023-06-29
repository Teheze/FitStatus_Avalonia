using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views
{
    public partial class BmiView : UserControl
    {
        private BmiViewModel _viewModel;

        public BmiView()
        {
            InitializeComponent();
            _viewModel = new BmiViewModel(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnConfirmButtonBmiClicked(object sender, RoutedEventArgs e)
        {
            _viewModel.CalculateBMI();
        }
    }
}