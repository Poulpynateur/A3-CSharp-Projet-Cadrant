using EasySave.Model;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
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

namespace EasySave.View.Composants
{
    /// <summary>
    /// Logique d'interaction pour TaskInfo.xaml
    /// </summary>
    public partial class TaskInfo : UserControl
    {
        private TaskEventHandler TaskEvent;
        private bool pause;

        public TaskInfo(Task task,TaskEventHandler taskEvent)
        {
            this.pause = false;
            this.TaskEvent = taskEvent;

            InitializeComponent();

            Name.Content = task.Name;
            CreatedAt.Content = task.CreatedAt.ToString();
            SaveType.Content = task.JobName;
            Source.Content = task.Options["source"];
            Target.Content = task.Options["target"];
        }

        public void Refresh(Progress progress)
        {
            ProgressWrapper.Visibility = Visibility.Visible;

            ProgressFile.Content = progress.FileInProgress;
            ProgressBar.Maximum = progress.FilesNumber;
            ProgressBar.Value = progress.FilesDone;

            if (progress.FilesNumber == progress.FilesDone)
                ProgressWrapper.Visibility = Visibility.Collapsed;
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if(pause)
            {
                TaskEvent(TaskAction.RESTART, new Dictionary<string, string>
                {
                    {"name", Name.Content.ToString()}
                });
                BtnPause.Content = "Pause";
                pause = false;
            }  
            else
            {
                TaskEvent(TaskAction.PAUSE, new Dictionary<string, string>
                {
                    {"name", Name.Content.ToString()}
                });
                BtnPause.Content = "Restart";
                pause = true;
            }
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            TaskEvent(TaskAction.STOP, new Dictionary<string, string>
                {
                    {"name", Name.Content.ToString()}
                });
            ProgressWrapper.Visibility = Visibility.Collapsed;
        }
    }
}
