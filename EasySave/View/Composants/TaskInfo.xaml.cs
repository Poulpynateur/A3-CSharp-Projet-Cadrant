﻿using EasySave.Model;
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="task">Task object</param>
        /// <param name="taskEvent">TaskEventHandler object</param>
        public TaskInfo(Task task, TaskEventHandler taskEvent)
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

        /// <summary>
        /// Refresh the information of teh task
        /// </summary>
        /// <param name="progress">Progress object</param>
        public void Refresh(Progress progress)
        {
            if(pause == false)
            {
                ProgressBar.Foreground = Brushes.SteelBlue;
                ProgressWrapper.Visibility = Visibility.Visible;
                IsProgressSuccess.Visibility = Visibility.Collapsed;

                ProgressBar.Value = progress.FilesDone;
                ProgressBar.Maximum = progress.FilesNumber;

                if (progress.FilesNumber == progress.FilesDone)
                {
                    ProgressWrapper.Visibility = Visibility.Collapsed;
                    IsProgressSuccess.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Start a task and gray out the start button
        /// </summary>
        private void StartTask()
        {
            BtnPausePause.Visibility = Visibility.Visible;
            BtnPauseStart.Visibility = Visibility.Collapsed;
            ProgressBar.Foreground = Brushes.SteelBlue;
            pause = false;
        }

        /// <summary>
        /// Pause a task and gray out the pause button
        /// </summary>
        public void PauseTask()
        {
            BtnPausePause.Visibility = Visibility.Collapsed;
            BtnPauseStart.Visibility = Visibility.Visible;
            ProgressBar.Foreground = Brushes.Gray;
            pause = true;
        }

        /// <summary>
        /// When the Pause button is clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if(pause)
            {
                TaskEvent(TaskAction.RESTART, new Dictionary<string, string>
                {
                    {"name", Name.Content.ToString()}
                });
                StartTask();
            }  
            else
            {
                TaskEvent(TaskAction.PAUSE, new Dictionary<string, string>
                {
                    {"name", Name.Content.ToString()}
                });
                PauseTask();
            }
        }

        /// <summary>
        /// When the Stop button is clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            TaskEvent(TaskAction.RESTART, new Dictionary<string, string>
                {
                    {"name", Name.Content.ToString()}
                });
            TaskEvent(TaskAction.STOP, new Dictionary<string, string>
                {
                    {"name", Name.Content.ToString()}
                });
            ProgressWrapper.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// When the Name button is clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Name_Click(object sender, RoutedEventArgs e)
        {
            if(TaskDetails.Visibility == Visibility.Collapsed)
                TaskDetails.Visibility = Visibility.Visible;
            else
                TaskDetails.Visibility = Visibility.Collapsed;
        }
    }
}