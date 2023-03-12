using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;

namespace FitStatus_Avalonia.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ToggleSplitView(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void MenuShowView(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            switch (content)
            {
                case "BMI":
                    ContentControl.Content = new Bmi_view();
                    break;
                case "BMR":
                    ContentControl.Content = new Bmr_view();
                    break;
                case "Trening":
                    ContentControl.Content = new Training_view();
                    break;
            }

            MySplitView.IsPaneOpen = false;
        }
    }
}