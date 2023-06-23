using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views
{
    public partial class Bmi_view : UserControl
    {
        private BmiViewModel viewModel;

        public Bmi_view()
        {
            InitializeComponent();
            viewModel = new BmiViewModel(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnConfirmButtonBmiClicked(object sender, RoutedEventArgs e)
        {
            viewModel.CalculateBMI();
        }
    }
}