using GolfApp.Algorithm;
using GolfApp.Input;
using GolfApp.Output;
using GolfApp.Structures;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GolfUI
{
    public partial class MainWindow : Window
    {
        private State State { get; } = new State();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = State;
        }

        private void LoadTask(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new OpenFileDialog { Filter = "Text files|*.txt", FilterIndex = 1 };
            if (dialogWindow.ShowDialog() == true)
            {
                var filename = dialogWindow.FileName;
                var taskParser = new TextFileTaskParser(filename);

                try
                {
                    State.LoadTask(taskParser.Parse());
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while reading file.");
                }
            }
        }

        private void SaveTask(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new SaveFileDialog { Filter = "Text files|*.txt", DefaultExt = ".txt", AddExtension = true };
            if (dialogWindow.ShowDialog() == true)
            {
                var filename = dialogWindow.FileName;
                var taskParser = new TextFileTaskSaver(filename);
                try
                {
                    taskParser.Save(State.Task);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while saving file.");
                }
            }
        }

        private void FindMatching(object sender, RoutedEventArgs e)
        {
            State.FindPlanarMatching();
        }
        private void ClearTask(object sender, RoutedEventArgs e)
        {
            var result_task = MessageBox.Show($"Are you sure to clear all points?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result_task == MessageBoxResult.Yes)
            {
                State.ClearAll();
            }
            else { }
        }
        private void SaveMatching(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new SaveFileDialog { Filter = "Text files|*.txt", DefaultExt = ".txt", AddExtension = true };
            if (dialogWindow.ShowDialog() == true)
            {
                var filename = dialogWindow.FileName;
                var matchingPrinter = new TextFileMatchingPrinter(filename);

                try
                {
                    matchingPrinter.Print(State.Matching);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while saving file.");
                }
            }
        }

        private void ClearMatching(object sender, RoutedEventArgs e)
        {
            var clear_matching = MessageBox.Show($"Are you sure you want to clear the matching?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (clear_matching == MessageBoxResult.Yes)
            {
                State.ClearMatching();
            }
            else { }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            double value;
            if (!double.TryParse(TextBoxX.Text, out value) || !double.TryParse(TextBoxY.Text, out value))
            {
                MessageBox.Show("Invalid point coordinates ! (Should be double or integer)");
                return;;
            }

            
             

            State.AddPoint();
        }

        private void ButtonClearAll_OnClick(object sender, RoutedEventArgs e)
        {
           var result= MessageBox.Show($"Are you sure to clear all points?","Confirmation",MessageBoxButton.YesNo,MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                State.ClearAll();
            }
            else{ }
        }
            
        private void ButtonGenerate_OnClick(object sender, RoutedEventArgs e)
        {
            int value;
            if (!int.TryParse(TextBoxRandom.Text, out value))
            {
                MessageBox.Show("Invalid number of point coordinates ! (Should be an integer)");
                return;
            }




            State.AddRandomPoints();
        }
         
    }
}
