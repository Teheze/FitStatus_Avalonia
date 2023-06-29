using System;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using FitStatus_Avalonia.ViewModels;
using ReactiveUI;
using System.Linq;
using FitStatus_Avalonia.Models;

namespace FitStatus_Avalonia.ViewModels
{
    public class TrainingViewModel : ViewModelBase
    {
        private ObservableCollection<Training> _trainings;
        private ObservableCollection<Exercise> _exercises;
        private string? _trainingName;
        private string? _exerciseName;
        private int _repetitions;
        private int _sets;
        private Training? _selectedTraining;
        private Exercise? _selectedExercise;
        public ReactiveCommand<Unit, Unit> StartTrainingCommand { get; }
        public ReactiveCommand<Unit, Unit> EndTrainingCommand { get; }
        
        public TrainingViewModel()
        {
            _trainings = new ObservableCollection<Training>(DataAccess.LoadTrainings());
            _exercises = new ObservableCollection<Exercise>();

            AddTrainingCommand = ReactiveCommand.Create(AddTraining);
            AddExerciseCommand = ReactiveCommand.Create(AddExerciseToTraining);
            RemoveTrainingCommand = ReactiveCommand.Create(RemoveTraining);
            RemoveExerciseCommand = ReactiveCommand.Create(RemoveExercise);
            UpdateExerciseCommand = ReactiveCommand.Create(UpdateExercise);
            StartTrainingCommand = ReactiveCommand.Create(StartTraining);
            EndTrainingCommand = ReactiveCommand.Create(EndTraining);
        }

        public ObservableCollection<Training> Trainings
        {
            get => _trainings;
            set => this.RaiseAndSetIfChanged(ref _trainings, value);
        }

        public ObservableCollection<Exercise> Exercises
        {
            get => _exercises;
            set => this.RaiseAndSetIfChanged(ref _exercises, value);
        }

        public string? TrainingName
        {
            get => _trainingName;
            set => this.RaiseAndSetIfChanged(ref _trainingName, value);
        }

        public string? ExerciseName
        {
            get => _exerciseName;
            set => this.RaiseAndSetIfChanged(ref _exerciseName, value);
        }

        public int Repetitions
        {
            get => _repetitions;
            set => this.RaiseAndSetIfChanged(ref _repetitions, value);
        }

        public int Sets
        {
            get => _sets;
            set => this.RaiseAndSetIfChanged(ref _sets, value);
        }

        public Training? SelectedTraining
        {
            get => _selectedTraining;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedTraining, value);
                LoadExercisesForTraining();
            }
        }

        public Exercise? SelectedExercise
        {
            get => _selectedExercise;
            set => this.RaiseAndSetIfChanged(ref _selectedExercise, value);
        }

        public ReactiveCommand<Unit, Unit> AddTrainingCommand { get; }
        public ReactiveCommand<Unit, Unit> AddExerciseCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveTrainingCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveExerciseCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateExerciseCommand { get; }

        private void AddTraining()
        {
            var training = new Training { Name = TrainingName };
            DataAccess.AddTraining(training);
            Trainings.Add(training);
        }

        private void AddExerciseToTraining()
        {
            if (SelectedTraining == null) return;

            var exercise = new Exercise
            {
                Name = ExerciseName,
                Repetitions = Repetitions,
                Sets = Sets,
                TrainingId = SelectedTraining.Id 
            };
            DataAccess.AddExerciseToTraining(exercise);
            Exercises.Add(exercise);
        }
        private void RemoveTraining()
        {
            if (SelectedTraining == null) return;

            DataAccess.RemoveTraining(SelectedTraining);
            Trainings.Remove(SelectedTraining);
        }

        private void RemoveExercise()
        {
            if (SelectedExercise == null) return;

            DataAccess.RemoveExercise(SelectedExercise);
            Exercises.Remove(SelectedExercise);
        }

        private void UpdateExercise()
        {
            if (SelectedExercise == null) return;

            SelectedExercise.Name = ExerciseName;
            SelectedExercise.Repetitions = Repetitions;
            SelectedExercise.Sets = Sets;
            DataAccess.UpdateExercise(SelectedExercise);
            
            LoadExercisesForTraining();
        }

        private void LoadExercisesForTraining()
        {
            if (SelectedTraining == null) return;

            var exercises = DataAccess.GetExercisesForTraining(SelectedTraining.Id);
            Exercises.Clear();
            foreach (var exercise in exercises)
            {
                Exercises.Add(exercise);
            }
        }
        private void StartTraining()
        {
            if (SelectedTraining == null) return;

            SelectedTraining.StartTime = DateTime.Now;
            DataAccess.UpdateTraining(SelectedTraining);
        }

        private void EndTraining()
        {
            if (SelectedTraining == null) return;

            SelectedTraining.EndTime = DateTime.Now;
            DataAccess.UpdateTraining(SelectedTraining);
        }
    }
}
