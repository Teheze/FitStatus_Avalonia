using System;
using Avalonia.Controls;
using FitStatus_Avalonia.Views;

namespace FitStatus_Avalonia.ViewModels
{
    public class BmiViewModel
    {
        private BmiView view;

        public BmiViewModel(BmiView view)
        {
            this.view = view;
        }

        public void CalculateBMI()
        {
            double weight, height, bmi;

            TextBox WeightTextBox = view.FindControl<TextBox>("WeightTextBox");
            TextBox HeightTextBox = view.FindControl<TextBox>("HeightTextBox");
            TextBlock BmiResultTextBlock = view.FindControl<TextBlock>("BmiResultTextBlock");
            Border BmiResultBorder = view.FindControl<Border>("BmiResultBorder");

            if (double.TryParse(WeightTextBox.Text, out weight) &&
                double.TryParse(HeightTextBox.Text, out height))
            {
                bmi = weight / Math.Pow(height / 100, 2);

                if (BmiResultTextBlock != null)
                {
                    if (bmi < 18.5)
                    {
                        BmiResultTextBlock.Text = $"Masz niedowagę.\nTwoje BMI wynosi: {bmi.ToString("0.00")}.";
                        BmiResultTextBlock.Foreground = Avalonia.Media.Brushes.LightBlue;
                        BmiResultBorder.BorderBrush = Avalonia.Media.Brushes.LightBlue;
                    }
                    else if (bmi >= 18.5 && bmi < 25)
                    {
                        BmiResultTextBlock.Text = $"Twoja waga jest prawidłowa.\nTwoje BMI wynosi: {bmi.ToString("0.00")}.";
                        BmiResultTextBlock.Foreground = Avalonia.Media.Brushes.LightGreen;
                        BmiResultBorder.BorderBrush = Avalonia.Media.Brushes.LightGreen;
                    }
                    else if (bmi >= 25 && bmi < 30)
                    {
                        BmiResultTextBlock.Text = $"Masz nadwagę.\nTwoje BMI wynosi: {bmi.ToString("0.00")}.";
                        BmiResultTextBlock.Foreground = Avalonia.Media.Brushes.Orange;
                        BmiResultBorder.BorderBrush = Avalonia.Media.Brushes.Orange;
                    }
                    else
                    {
                        BmiResultTextBlock.Text = $"Masz otyłość.\nTwoje BMI wynosi: {bmi.ToString("0.00")}.";
                        BmiResultTextBlock.Foreground = Avalonia.Media.Brushes.Red;
                        BmiResultBorder.BorderBrush = Avalonia.Media.Brushes.Red;
                    }
                }
            }
            else
            {
                if (BmiResultTextBlock != null)
                {
                    BmiResultTextBlock.Text = "Niepoprawne wartości";
                    BmiResultTextBlock.Foreground = Avalonia.Media.Brushes.Black;
                }
            }
        }
    }
}
