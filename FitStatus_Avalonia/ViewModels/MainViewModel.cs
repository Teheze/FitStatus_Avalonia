using FitStatus_Avalonia.Models;
using Avalonia.Controls;
using ReactiveUI;
using System;
using FitStatus_Avalonia.Views;

namespace FitStatus_Avalonia.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MainView _view;

        private string? _lastTrainingInfo;

        public string? LastTrainingInfo
        {
            get => _lastTrainingInfo;
            set => this.RaiseAndSetIfChanged(ref _lastTrainingInfo, value);
        }

        public MainViewModel(MainView view)
        {
            this._view = view;
            LoadLastTrainingInfo();
            GetLastBmi();
            GetLastBmr();
        }

        private void GetLastBmi()
        {
            TextBlock lastBmiResultTextBlock = _view.FindControl<TextBlock>("LastBmiResultTextBlock");
            var lastBmi = DataAccess.GetLastBmi();
        
            if (lastBmi != null)
            {
                lastBmiResultTextBlock.Text = lastBmi.Info;
            }
            else
            {
                lastBmiResultTextBlock.Text = "Oblicz swoje BMI korzystając z kalkulatora";
            }
        }
        private void GetLastBmr()
        {
            TextBlock lastBmrResultTextBlock = _view.FindControl<TextBlock>("LastBmrResultTextBlock");
            var lastBmr = DataAccess.GetLastBmr();
            string age = "lat";
            if (lastBmr.Age % 10 == 2 || lastBmr.Age % 10 == 3 || lastBmr.Age % 10 == 4 || lastBmr.Age == 2 || lastBmr.Age == 3 || lastBmr.Age == 4)
            {
                age += "a";
            }
            if (lastBmr != null)
            {
                lastBmrResultTextBlock.Text = $"{lastBmr.Gender} {lastBmr.Age} {age} o wzroście {lastBmr.Height} cm i wadze {lastBmr.Weight} kg. \n\n{lastBmr.Info}";
            }
            else
            {
                lastBmrResultTextBlock.Text = "Oblicz swoje BMR korzystając z kalkulatora.";
            }
        }
        private void LoadLastTrainingInfo()
        {
            TextBlock lastTrainingTextBlock = _view.FindControl<TextBlock>("LastTrainingTextBlock");
            var lastTraining = DataAccess.GetLastTraining();

            if (lastTraining != null)
            {
                var trainingDuration = lastTraining.EndTime - lastTraining.StartTime;

                var exercises = DataAccess.GetExercisesForTraining(lastTraining.Id);

                lastTrainingTextBlock.Text = $"{lastTraining.Name}\n\n" +
                                             $"Czas rozpoczęcia: {lastTraining.StartTime}\n" +
                                             $"Czas zakończenia: {lastTraining.EndTime}\n" +
                                             $"Czas trwania: {trainingDuration}\n\n\n\n";
                lastTrainingTextBlock.Text +=   $"Nazwa," +
                                                $" Ilość powtórzeń, " +
                                                $" Ilość serii \n";
                foreach (var exercise in exercises)
                {
                    lastTrainingTextBlock.Text += $"- {exercise.Name}," +
                                                  $" {exercise.Repetitions}," +
                                                  $" {exercise.Sets}\n";
                }
            }
            else
            {
                lastTrainingTextBlock.Text = "Brak wykonanego treningu.\nMusisz zakończyć trening, aby się on tutaj wyświetlił.";
            }
        }

    }
}