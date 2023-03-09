using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
// using CommunityToolkit.Mvvm.ComponentModel;
// using CommunityToolkit.Mvvm.Input;

namespace FitStatus_Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Bmi => "Twoje BMI wynosi: 24.9";
}