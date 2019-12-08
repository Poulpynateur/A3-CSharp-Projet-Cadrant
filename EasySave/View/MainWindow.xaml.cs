using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EasySave.Helpers;
using EasySave.Model;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EasySave.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        private IModel model;
        private TaskWindow taskWindow;
        
        public event QuickSaveEventHandler QuickSaveEvent;
        //Bubble event
        public event TaskEventHandler TaskEvent
        {
            add { this.taskWindow.TaskEvent += value; }
            remove { this.taskWindow.TaskEvent -= value; }
        }

        public MainWindow(IModel model)
        {
            this.model = model;
            this.taskWindow = new TaskWindow();

            //Hide the task popup then task event are fired
            TaskEvent += (state, options) =>
            {
                taskWindow.Hide();
            };

            InitializeComponent();
            RefreshTaskList();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            taskWindow.parentClosing = true;
            taskWindow.Close();
        }

        public void RefreshTaskList()
        {
            TaskList.Children.Clear();
            foreach(Tuple<string, string> task in model.GetTasksNames())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = task.Item1;
                checkBox.ToolTip = task.Item2;
                TaskList.Children.Add(checkBox);
            }
        }

        /// <summary>
        /// Display text to console.
        /// </summary>
        /// <param name="statut">Define the color</param>
        /// <param name="text">Text to write</param>
        public void DisplayText(Statut statut, string text)
        {
            LogTextWrapper.Children.Add(new Log(statut, text));
        }

        private void GetFolderPath(TextBox display)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                display.Text = dialog.FileName;
            }
        }

        private void ExecuteQuickSave_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                { "name",  QuickName.Text},
                { "source",  QuickSourcePath.Text},
                { "target",  QuickTargetPath.Text}
            };

            if(RadioMirrorSave.IsChecked == true)
                QuickSaveEvent(QuickSaveAction.MIRROR, options);

            if(RadioDifferentialSave.IsChecked == true)
                QuickSaveEvent(QuickSaveAction.DIFFERENTIAL, options);
        }

        private void BtnQuickSourcePath_Click(object sender, RoutedEventArgs e)
        {
            GetFolderPath(QuickSourcePath);
        }

        private void BtnQuickTargetPath_Click(object sender, RoutedEventArgs e)
        {
            GetFolderPath(QuickTargetPath);
        }

        private void BtnTaskAdd_Click(object sender, RoutedEventArgs e)
        {
            taskWindow.Show();
        }

        private Dictionary<string, string> GetSelectedTasks()
        {
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                { "name", "" }
            };
            var list = TaskList.Children.OfType<CheckBox>().Where(x => x.IsChecked == true);

            foreach (var task in list)
            {
                options["name"] += task.Content.ToString() + ";";
            }
            return options;
        }

        private void BtnTaskRemove_Click(object sender, RoutedEventArgs e)
        {
            taskWindow.RemoveTask(GetSelectedTasks());
        }

        private void BtnTaskExecute_Click(object sender, RoutedEventArgs e)
        {
            taskWindow.ExecuteTask(GetSelectedTasks());
        }
    }
}