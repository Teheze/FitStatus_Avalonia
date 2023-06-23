using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FitStatus_Avalonia.Views;

public partial class Training_view : UserControl
{
    public Training_view()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}