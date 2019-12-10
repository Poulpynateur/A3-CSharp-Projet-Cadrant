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
            this.data = data;

            InitializeComponent();
            RefreshTaskList();
        }

        /// <summary>
        /// Display log in LogTextWrapper.
        /// </summary>
        /// <param name="statut">Define the color</param>
        /// <param name="text">Text to write</param>
        public void DisplayText(Statut statut, string text)
        {
            LogTextWrapper.Children.Add(new Composants.Log(statut, text));
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
            paramWindow = new ParamWindow(data, ParamEvent);
            paramWindow.ShowDialog();
        }
    }
}