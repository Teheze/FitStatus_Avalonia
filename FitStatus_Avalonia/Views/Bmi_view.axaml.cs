using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FitStatus_Avalonia.Views;

public partial class Bmi_view : UserControl
{
    public Bmi_view()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}