using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.Views;

namespace FitStatus_Avalonia.Views;

public partial class Bmr_view : UserControl
{
    public Bmr_view()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}