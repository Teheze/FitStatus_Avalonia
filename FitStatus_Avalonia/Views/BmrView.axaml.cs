using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views
{
    public partial class BmrView : UserControl
    {
        private BmrViewModel viewModel;

        public BmrView()
        {
            InitializeComponent();
            viewModel = new BmrViewModel(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnConfirmButtonBmrClicked(object sender, RoutedEventArgs e)
        {
            viewModel.CalculateBMR();
        }
    }
}