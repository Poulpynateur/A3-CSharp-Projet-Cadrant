using EasySave.Model;
using EasySave.Model.Job;
using EasySave.View;
using System;
using System.Collections.Generic;
using System.Windows;

namespace EasySave.Controller
{
    /// <summary>
    /// Manage input from view and execute commands from the model.
    /// </summary>
    public class Controller
    {
        private IModel model;
        private IView view;

        /// <summary>
        /// Initialize a new view and a new model.
        /// </summary>
        /// <param name="model">Instantiate a new model/param>
        /// <param name="view">Instantiate a new view</param>
        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;

            this.AssignEvents();
        }

        /// <summary>
        /// Method in order to execute the chosen task.
        /// </summary>
        /// <param name="job">Instanciate a new object task/param>
        /// <param name="options">Launch the task with his name as parameter</param>
        private void ExecuteJob(BaseJob job, Dictionary<string, string> options)
        {
            try
            {
                job.Execute(options);
                view.Window.RefreshTaskList();
            }
            catch (Exception e)
            {
                view.Window.DisplayText(Helpers.Statut.ERROR, e.Message);
            }
        }

        /// <summary>
        /// Method in order to execute a quick save.
        /// </summary>
        /// <param name="action">The type of quick-save/param>
        /// <param name="options">Launch the quick-save with all the options</param>
        private void HandleQuickSave(QuickSaveAction action, Dictionary<string, string> options)
        {
            BaseJob job = null;
            switch (action)
            {
                case QuickSaveAction.MIRROR:
                    job = model.GetJobByName("save-mirror");
                    break;
                case QuickSaveAction.DIFFERENTIAL:
                    job = model.GetJobByName("save-differential"); 
                    break;
            }

            ExecuteJob(job, options);
        }

        /// <summary>
        /// Method managing all the tasks.
        /// </summary>*
        /// <param name="action">Selected action to manage the task/param>
        /// <param name="options">Launch the task with all the saved options</param>
        private void HandleTask(TaskAction action, Dictionary<string, string> options)
        {
            BaseJob job = null;
            switch (action)
            {
                case TaskAction.ADD:
                    job = model.GetJobByName("add-task");
                    break;
                case TaskAction.REMOVE:
                    job = model.GetJobByName("remove-task");
                    break;
                case TaskAction.EXECUTE:
                    job = model.GetJobByName("execute-task");
                    break;
            }

            ExecuteJob(job, options);
        }

        private void HandleParam(Dictionary<string, List<string>> parameters)
        {
            if (parameters.ContainsKey("ERP blacklist"))
                model.SetErpBlacklist(parameters["ERP blacklist"]);

            if (parameters.ContainsKey("Encrypt extensions"))
                model.SetEncryptFormat(parameters["encrypt extensions"]);
        }

        /// <summary>
        /// Assign functions to the differents events.
        /// </summary>
        private void AssignEvents()
        {
            view.Window.QuickSaveEvent += new QuickSaveEventHandler(HandleQuickSave);
            view.Window.TaskEvent += new TaskEventHandler(HandleTask);
            view.Window.ParamEvent += new ParamEventHandler(HandleParam);
        }

        /// <summary>
        /// Start the main programm.
        /// </summary>
        public void Start()
        {
            view.Start();
        }
    }
}