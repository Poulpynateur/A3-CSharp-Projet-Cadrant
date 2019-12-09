using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasySave.View
{
    /// <summary>
    /// MainWindow.xaml quick save logic.
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Execute a quick save, get info from the different input box.
        /// </summary>
        /// <param name="sender">ExecuteQuickSave</param>
        /// <param name="e">Cancel the event</param>
        private void ExecuteQuickSave_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                { "encrypt", (QuickSaveEncrypt.IsChecked == true)? "yes" : "no" },
                { "name",  QuickName.Text},
                { "source",  QuickSourcePath.Text},
                { "target",  QuickTargetPath.Text}
            };

            if (RadioMirrorSave.IsChecked == true)
                QuickSaveEvent(QuickSaveAction.MIRROR, options);

            if (RadioDifferentialSave.IsChecked == true)
                QuickSaveEvent(QuickSaveAction.DIFFERENTIAL, options);
        }

        /// <summary>
        /// Open folder context window : <see cref="GetFolderPath(System.Windows.Controls.TextBox)"/>
        /// </summary>
        /// <param name="sender">BtnQuickSourcePath</param>
        /// <param name="e">Cancel the event</param>
        private void BtnQuickSourcePath_Click(object sender, RoutedEventArgs e)
        {
            GetFolderPath(QuickSourcePath);
        }

        /// <summary>
        /// Open folder context window : <see cref="GetFolderPath(System.Windows.Controls.TextBox)"/>
        /// </summary>
        /// <param name="sender">BtnQuickTargetPath</param>
        /// <param name="e">Cancel the event</param>
        private void BtnQuickTargetPath_Click(object sender, RoutedEventArgs e)
        {
            GetFolderPath(QuickTargetPath);
        }
    }
}
