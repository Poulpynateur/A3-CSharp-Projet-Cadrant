using EasySave.Model;
using EasySave.Model.Job;
using EasySave.View;
using System;
using System.Collections.Generic;

namespace EasySave.Controller
{
    /// <summary>
    /// Manage input from view and execute commands from the model.
    /// </summary>
    public class Controller
    {
        private IModel model;
        private IView view;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;

            this.AssignEvents();
        }

        private void ExecuteJob(BaseJob job, Dictionary<string, string> options)
        {
           /* try
            {*/
                job.Execute(options);
                view.Window.RefreshTaskList();
            /*}
            catch (Exception e)
            {
                view.Window.DisplayText(Helpers.Statut.ERROR, e.Message);
            }*/
        }

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

        /// <summary>
        /// Assign functions to the differents events.
        /// </summary>
        private void AssignEvents()
        {
            view.Window.QuickSaveEvent += new QuickSaveEventHandler(HandleQuickSave);
            view.Window.TaskEvent += new TaskEventHandler(HandleTask);
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