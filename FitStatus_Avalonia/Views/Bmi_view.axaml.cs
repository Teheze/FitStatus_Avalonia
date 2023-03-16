using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia.Views;

public partial class Bmi_view : UserControl
{
    public Bmi_view()
    {
        InitializeComponent();
        WeightTextBox = this.Find<TextBox>("WeightTextBox");
        HeightTextBox = this.Find<TextBox>("HeightTextBox");
        BmiResultTextBlock = this.Find<TextBlock>("ResultTextBlock");
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private void OnConfirmButtonBmiClicked(object sender, RoutedEventArgs e)
    {
        double weight, height, bmi;

        if (double.TryParse(WeightTextBox.Text, out weight) &&
            double.TryParse(HeightTextBox.Text, out height))
        {
            bmi = weight / Math.Pow(height / 100, 2);

            TextBlock BmiResultTextBlock = this.FindControl<TextBlock>("BmiResultTextBlock");

            if (BmiResultTextBlock != null)
            {
                if (bmi < 18.5)
                {
                    BmiResultTextBlock.Text = $"Masz niedowagę.\nTwoje BMI wynosi: {bmi.ToString("0.00")}.";
                }
                else if (bmi >= 18.5 && bmi < 25)
                {
                    BmiResultTextBlock.Text = $"Twoja waga jest prawidłowa.\nTwoje BMI wynosi: {bmi.ToString("0.00")}.";
                }
                else if (bmi >= 25 && bmi < 30)
                {
                    BmiResultTextBlock.Text = $"Masz nadwagę.\nTwoje BMI wynosi: {bmi.ToString("0.00")}.";
                }
                else
                {
                    BmiResultTextBlock.Text = $"Masz otyłość.\nTwoje BMI wynosi: {bmi.ToString("0.00")}.";
                }
            }
        }
        else
        {
            TextBlock BmiResultTextBlock = this.FindControl<TextBlock>("BmiResultTextBlock");

            if (BmiResultTextBlock != null)
            {
                BmiResultTextBlock.Text = "Niepoprawne wartości";
            }
        }
    }

}