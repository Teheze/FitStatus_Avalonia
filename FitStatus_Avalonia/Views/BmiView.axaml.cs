using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views
{
    public partial class BmiView : UserControl
    {
        private BmiViewModel viewModel;

        public BmiView()
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