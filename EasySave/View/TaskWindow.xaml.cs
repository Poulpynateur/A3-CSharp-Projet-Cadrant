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
        public event TaskEventHandler TaskEvent;
        public bool parentClosing { private get; set; }

        public TaskWindow()
        {
            parentClosing = false;
            InitializeComponent();
        }

        private void TaskWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!parentClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
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

        private void btnTaskSourcePath_Click(object sender, RoutedEventArgs e)
        {
            GetFolderPath(TaskSourcePath);
        }

        private void btnTaskTargetPath_Click(object sender, RoutedEventArgs e)
        {
            GetFolderPath(TaskTargetPath);
        }

        private void ExecuteTaskSave_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                { "type", (RadioMirrorSave.IsChecked == true)? "mirror" : "differential" },
                { "name",  TaskName.Text},
                { "source",  TaskSourcePath.Text},
                { "target",  TaskTargetPath.Text}
            };

            TaskEvent(TaskAction.ADD, options);
        }
        public void RemoveTask(Dictionary<string, string> options)
        {
            TaskEvent(TaskAction.REMOVE, options);
        }
        public void ExecuteTask(Dictionary<string, string> options)
        {
            TaskEvent(TaskAction.EXECUTE, options);
        }
    }

}
