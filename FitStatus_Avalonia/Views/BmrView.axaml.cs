using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views
{
    public partial class Bmr_view : UserControl
    {
        private BmrViewModel viewModel;

        public Bmr_view()
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