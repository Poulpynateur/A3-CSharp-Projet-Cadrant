using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasySave.View
{
    /// <summary>
    /// MainWindow.xaml task logic.
    /// </summary>
    public partial class MainWindow
    {
        private void BtnTaskAdd_Click(object sender, RoutedEventArgs e)
        {
            taskWindow = new TaskWindow(TaskEvent);
            taskWindow.ShowDialog();
        }

        /// <summary>
        /// Get the list of task from model and display then.
        /// </summary>
        public void RefreshTaskList()
        {
            TaskList.Children.Clear();
            foreach (Tuple<string, string> task in model.GetTasksNames())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = task.Item1;
                checkBox.ToolTip = task.Item2;
                TaskList.Children.Add(checkBox);
            }
        }

        /// <summary>
        /// Get all the task that are selected.
        /// </summary>
        /// <returns>A dictionnary with a key "name" that contain the list of task name separated by ';'</returns>
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

        /// <summary>
        /// Remove a task <see cref="TaskWindow.RemoveTask(Dictionary{string, string})"/>
        /// </summary>
        /// <param name="sender">BtnTaskRemove</param>
        /// <param name="e">Cancel the event</param>
        private void BtnTaskRemove_Click(object sender, RoutedEventArgs e)
        {
            TaskEvent(TaskAction.REMOVE, GetSelectedTasks());
        }

        /// <summary>
        /// Remove a task <see cref="TaskWindow.ExecuteTask(Dictionary{string, string})"/>
        /// </summary>
        /// <param name="sender">BtnTaskExecute</param>
        /// <param name="e">Cancel the event</param>
        private void BtnTaskExecute_Click(object sender, RoutedEventArgs e)
        {
            TaskEvent(TaskAction.EXECUTE, GetSelectedTasks());
        }
    }
}
