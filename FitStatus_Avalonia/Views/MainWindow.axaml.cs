using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Data.Core;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Reactive;
using FitStatus_Avalonia.ViewModels;
using ReactiveUI;


namespace FitStatus_Avalonia.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentControl.Content = new MainView();
            HeaderText.Text = "STRONA GŁÓWNA";
            Background = (Brush)Resources["MainWindowBrush"]!;
        }
        private void ToggleSplitView(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void MenuShowView(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? content = button.Content.ToString();

            switch (content)
            {
                case "BMI":
                    ContentControl.Content = new BmiView();
                    HeaderText.Text = "BMI";
                    Background = (Brush)Resources["BmiBrush"]!;
                    break;
                case "BMR":
                    ContentControl.Content = new BmrView();
                    HeaderText.Text = "BMR";
                    Background = (Brush)Resources["BmrBrush"]!;
                    break;
                case "Trening":
                    ContentControl.Content = new TrainingView();
                    HeaderText.Text = "TRENING";
                    Background = (Brush)Resources["TrainingBrush"]!;
                    break;
            }


            MySplitView.IsPaneOpen = false;
        }
        private void MainViewSvg(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new MainView();
            HeaderText.Text = "STRONA GŁÓWNA";
            Background = (Brush)Resources["MainWindowBrush"]!;
        }
    }
}