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
    /// MainWindow.xaml main logic
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        private IModel model;

        private TaskWindow taskWindow;
        private ParamWindow paramWindow;
        
        /// <summary>
        /// Fired when we have quick save inputs.
        /// </summary>
        public event QuickSaveEventHandler QuickSaveEvent;
        /// <summary>
        /// Fired when we have task inputs, we pass then to the taskWindow.
        /// </summary>
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

        /// <summary>
        /// On close event, close the sub windows.
        /// </summary>
        /// <param name="sender">MainWindow</param>
        /// <param name="e">Cancel the event</param>
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            taskWindow.parentClosing = true;
            taskWindow.Close();

            if (paramWindow != null && paramWindow.IsLoaded == true)
                paramWindow.Close();
        }

        /// <summary>
        /// Display log in LogTextWrapper.
        /// </summary>
        /// <param name="statut">Define the color</param>
        /// <param name="text">Text to write</param>
        public void DisplayText(Statut statut, string text)
        {
            LogTextWrapper.Children.Add(new Log(statut, text));
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
            if(paramWindow == null || paramWindow.IsLoaded == false)
                paramWindow = new ParamWindow(model);

            paramWindow.Show();
        }
    }
}