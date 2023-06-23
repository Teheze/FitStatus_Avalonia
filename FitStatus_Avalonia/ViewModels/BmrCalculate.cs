using Avalonia.Controls;
using FitStatus_Avalonia.Views;

namespace FitStatus_Avalonia.ViewModels
{
    public class BmrViewModel
    {
        private Bmr_view view;

        public BmrViewModel(Bmr_view view)
        {
            this.view = view;
        }

        public void CalculateBMR()
        {
            double weight, height, bmr;
            int age;

            TextBox WeightTextBox = view.FindControl<TextBox>("WeightTextBox");
            TextBox HeightTextBox = view.FindControl<TextBox>("HeightTextBox");
            ComboBox GenderComboBox = view.FindControl<ComboBox>("GenderComboBox");
            ComboBox ActivityComboBox = view.FindControl<ComboBox>("ActivityComboBox");
            ComboBox GoalComboBox = view.FindControl<ComboBox>("GoalComboBox");
            TextBlock BmrResultTextBlock = view.FindControl<TextBlock>("BmrResultTextBlock");
            TextBox AgeTextBox = view.FindControl<TextBox>("AgeTextBox");

            if (double.TryParse(WeightTextBox.Text, out weight) &&
                double.TryParse(HeightTextBox.Text, out height) &&
                int.TryParse(AgeTextBox.Text, out age))
            {
                double activityFactor;
                if (ActivityComboBox.SelectedIndex == 0)
                    activityFactor = 1.2;
                else if (ActivityComboBox.SelectedIndex == 1)
                    activityFactor = 1.375;
                else if (ActivityComboBox.SelectedIndex == 2)
                    activityFactor = 1.55;
                else if (ActivityComboBox.SelectedIndex == 3)
                    activityFactor = 1.725;
                else
                    activityFactor = 1.9;

                int genderFactor = (GenderComboBox.SelectedIndex == 0) ? 5 : -161;

                double bmrFormula = weight * 10 + height * 6.25 - age * 5 + genderFactor;
                bmr = bmrFormula * activityFactor;

                if (BmrResultTextBlock != null)
                {
                    if (GoalComboBox.SelectedIndex == 0)
                    {
                        bmr *= 0.85;
                        BmrResultTextBlock.Text = $"Twoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.\nAby schudnąć, powinieneś spożywać około {bmr.ToString("0")} kcal dziennie.";
                    }
                    else if (GoalComboBox.SelectedIndex == 1)
                    {
                        BmrResultTextBlock.Text = $"Twoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.\nAby utrzymać wagę, powinieneś spożywać około {bmr.ToString("0")} kcal dziennie.";
                    }
                    else if (GoalComboBox.SelectedIndex == 2)
                    {
                        bmr *= 1.15;
                        BmrResultTextBlock.Text = $"Twoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.\nAby przybrać na masie, powinieneś spożywać około {bmr.ToString("0")} kcal dziennie.";
                    }
                }
            }
            else
            {
                if (BmrResultTextBlock != null)
                {
                    BmrResultTextBlock.Text = "Niepoprawne wartości";
                }
            }
        }
    }
}
