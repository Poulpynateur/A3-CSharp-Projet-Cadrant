using EasySave.Model;
using EasySave.View.Composants;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasySave.View
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private TaskEventHandler TaskEvent;

        /// <summary>
        /// Initialize the task window
        /// </summary>
        public TaskWindow(IData data, Multilang multilang, TaskEventHandler taskEvent)
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.TaskEvent = taskEvent;
            InitializeComponent();

            ShowDialog();
            multilang.RefreshControlText(this, data);
        }

        /// <summary>
        /// Get the path of the folder in the text box
        /// </summary>
        /// <param name="display"></param>
        private void GetFolderPath(TextBox display)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                display.Text = dialog.FileName;
            }
            this.Activate();
        }

        /// <summary>
        /// Event when the button for choosing the source path is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaskSourcePath_Click(object sender, RoutedEventArgs e)
        {
            GetFolderPath(TaskSourcePath);
        }

        /// <summary>
        /// Event when the button for choosing the target path is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaskTargetPath_Click(object sender, RoutedEventArgs e)
        {
            GetFolderPath(TaskTargetPath);
        }

        /// <summary>
        /// Event when the button for executing the task save is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteTaskSave_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                { "type", (RadioMirrorSave.IsChecked == true)? "mirror" : "differential" },
                { "encrypt", (TaskEncrypt.IsChecked == true)? "yes" : "no" },
                { "name",  TaskName.Text},
                { "source",  TaskSourcePath.Text},
                { "target",  TaskTargetPath.Text}
            };

            TaskEvent(TaskAction.ADD, options);
            this.Close();
        }
    }

}
