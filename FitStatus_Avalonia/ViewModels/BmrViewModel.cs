using System;
using Avalonia.Controls;
using FitStatus_Avalonia.Models;
using FitStatus_Avalonia.Views;

namespace FitStatus_Avalonia.ViewModels
{
    public class BmrViewModel
    {
        private BmrView _view;

        public BmrViewModel(BmrView view)
        {
            this._view = view;
        }

        public void CalculateBmr()
        {
            double weight, height, bmr;
            int age;

            TextBox weightTextBox = _view.FindControl<TextBox>("WeightTextBox");
            TextBox heightTextBox = _view.FindControl<TextBox>("HeightTextBox");
            ComboBox genderComboBox = _view.FindControl<ComboBox>("GenderComboBox");
            ComboBox activityComboBox = _view.FindControl<ComboBox>("ActivityComboBox");
            ComboBox goalComboBox = _view.FindControl<ComboBox>("GoalComboBox");
            TextBlock bmrResultTextBlock = _view.FindControl<TextBlock>("BmrResultTextBlock");
            TextBox ageTextBox = _view.FindControl<TextBox>("AgeTextBox");

            if (double.TryParse(weightTextBox.Text, out weight) &&
                double.TryParse(heightTextBox.Text, out height) &&
                int.TryParse(ageTextBox.Text, out age))
            {
                double activityFactor;
                if (activityComboBox.SelectedIndex == 0)
                    activityFactor = 1.2;
                else if (activityComboBox.SelectedIndex == 1)
                    activityFactor = 1.375;
                else if (activityComboBox.SelectedIndex == 2)
                    activityFactor = 1.55;
                else if (activityComboBox.SelectedIndex == 3)
                    activityFactor = 1.725;
                else
                    activityFactor = 1.9;

                int genderFactor = (genderComboBox.SelectedIndex == 0) ? 5 : -161;

                double bmrFormula = weight * 10 + height * 6.25 - age * 5 + genderFactor;
                bmr = bmrFormula * activityFactor;

                if (bmrResultTextBlock != null)
                {
                    if (goalComboBox.SelectedIndex == 0)
                    {
                        bmr *= 0.85;
                        bmrResultTextBlock.Text = $"Twoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.\nAby schudnąć, powinieneś spożywać około {bmr.ToString("0")} kcal dziennie.";
                        AddBmrRecord($"Aby schudnąć, musi spożywać około {bmr.ToString("0")} kcal dziennie.\n\nTwoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.", weight, height, age, genderFactor);
                    }
                    else if (goalComboBox.SelectedIndex == 1)
                    {
                        bmrResultTextBlock.Text = $"Twoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.\nAby utrzymać wagę, powinieneś spożywać około {bmr.ToString("0")} kcal dziennie.";
                        AddBmrRecord($"Aby utrzymać wagę, musi spożywać około {bmr.ToString("0")} kcal dziennie.\n\nTwoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.", weight, height, age, genderFactor);
                    }
                    else if (goalComboBox.SelectedIndex == 2)
                    {
                        bmr *= 1.15;
                        bmrResultTextBlock.Text = $"Twoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.\nAby przybrać na masie, powinieneś spożywać około {bmr.ToString("0")} kcal dziennie.";
                        AddBmrRecord($"Aby przybrać na masie, musi spożywać około {bmr.ToString("0")} kcal dziennie.\n\nTwoja podstawowa przemiana materii wynosi: {bmrFormula.ToString("0")} kcal.", weight, height, age, genderFactor);
                    }
                }
            }
            else
            {
                if (bmrResultTextBlock != null)
                {
                    bmrResultTextBlock.Text = "Niepoprawne wartości";
                }
            }
        }
        private void AddBmrRecord(string bmr, double weight, double height, int age, int genderFactor)
        {
            DateTime time = DateTime.Now;
            string gender = (genderFactor == 5) ? "Mężczyzna" : "Kobieta";
            
            Bmr bmrRecord = new Bmr { Weight = weight, Height = height, Age = age, Gender = gender ,Info = bmr, Time = time };

            DataAccess.AddBmrRecord(bmrRecord);
        }
    }
}
