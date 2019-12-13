using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EasySave.Helpers;
using EasySave.Model;
using EasySave.View.Composants;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EasySave.View
{
    /// <summary>
    /// MainWindow.xaml main logic
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        private IData data;

        private Multilang multilang;

        private TaskWindow taskWindow;
        private ParamWindow paramWindow;
        
        /// <summary>
        /// Fired when we have quick save inputs.
        /// </summary>
        public event QuickSaveEventHandler QuickSaveEvent;
        /// <summary>
        /// Fired when we have task inputs.
        /// </summary>
        public event TaskEventHandler TaskEvent;
        /// <summary>
        /// Fired when we change parameters.
        /// </summary>
        public event ParamEventHandler ParamEvent;

        public MainWindow(IData data)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.multilang = new Multilang();
            this.data = data;

            InitializeComponent();
        }

        /// <summary>
        /// When the main window is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            ParamEvent(new Dictionary<string, List<string>>() {
                { "Close", null }
            });
        }

        /// <summary>
        /// When the main window is loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            multilang.RefreshControlText(this, data);
        }

        /// <summary>
        /// Refresh the text controls for the multilanguage 
        /// </summary>
        public void RefreshControlText()
        {
            multilang.RefreshControlText(this, data);
        }


        /// <summary>
        /// Display log in LogTextWrapper.
        /// </summary>
        /// <param name="statut">Define the color</param>
        /// <param name="text">Text to write</param>
        public void DisplayText(Statut statut, string text)
        {
            Dispatcher.BeginInvoke(new ThreadStart(()=>
            {
                LogTextWrapper.Children.Add(new Composants.Log(statut, text));
            }));
        }

        /// <summary>
        /// Display the progress of a task
        /// </summary>
        /// <param name="name">Name of the task</param>
        /// <param name="progress">Progress object</param>
        public void DisplayProgress(string name, Progress progress)
        {
            Dispatcher.BeginInvoke(new ThreadStart(() =>
            {
                TaskInfo info = TaskList.Children.OfType<TaskInfo>().Where((x => x.Name.Content.ToString() == name)).First();

                if (progress.IsPaused)
                {
                    foreach (var task in TaskList.Children.OfType<TaskInfo>())
                        task.PauseTask();
                }

                if (info!=null)
                    info.Refresh(progress);
            }));
        }

        /// <summary>
        /// Open the "Choose folder" context window and set a TextBox with the result.
        /// </summary>
        /// <param name="display">Result target</param>
        private void GetFolderPath(TextBox display)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                display.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// On scroll event, auto scroll down to last log.
        /// </summary>
        /// <param name="sender">LogScrollViewer</param>
        /// <param name="e">Cancel the event</param>
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0)
            {
                LogScrollViewer.ScrollToVerticalOffset(LogScrollViewer.ExtentHeight);
            }
        }

        /// <summary>
        /// On click event, open the param window.
        /// </summary>
        /// <param name="sender">BtnParam</param>
        /// <param name="e">Cancel the event</param>
        private void BtnParam_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            paramWindow = new ParamWindow(data, multilang, ParamEvent);
            multilang.RefreshControlText(paramWindow, data);
            this.IsEnabled = true;
        }

        /// <summary>
        /// On click event, open the add task window and gray out the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTaskAdd_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            taskWindow = new TaskWindow(data, multilang, TaskEvent);
            multilang.RefreshControlText(taskWindow, data);
            this.IsEnabled = true;
        }
    }
}