using EasySave.View.Composants;
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
        /// <summary>
        /// Get the list of task from model and display then.
        /// </summary>
        public void RefreshTaskList()
        {
            TaskList.Children.Clear();
            foreach (var task in data.GetTasks())
            {
                TaskInfo taskInfo = new TaskInfo(task, TaskEvent);
                TaskList.Children.Add(taskInfo);
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
            var list = TaskList.Children.OfType<TaskInfo>().Where(x => x.Select.IsChecked == true);

            foreach (var task in list)
            {
                options["name"] += task.Name.Content.ToString() + ";";
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

        private void BtnTaskPause_Click(object sender, RoutedEventArgs e)
        {
            TaskEvent(TaskAction.PAUSE_ALL, null);
            var list = TaskList.Children.OfType<TaskInfo>();
            foreach (var task in list)
            {
                task.PauseTask();
            }
        }
    }
}
