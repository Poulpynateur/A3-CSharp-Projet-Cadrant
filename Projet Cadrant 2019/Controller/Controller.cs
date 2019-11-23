using EasySave.Model;
using EasySave.View;
using System;
using System.Collections.Generic;
using static EasySave.Model.Job.Job;

namespace EasySave.Controller
{
    class Controller
    {
        private IModel model;
        private IView view;

        private Parser parser;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;

            this.parser = new Parser();

            this.AssignEvents();
        }

        private void HandleInputs(string input)
        {
            string jobName = parser.ParseName(input);
            if (model.Jobs.isJobName(jobName))
            {
                Dictionary<string, string> options = parser.ParseOptions(input);
                model.Jobs.ExecuteJob(jobName, options);
            }
            else
            {
                view.DisplayError("Command not found : " + jobName);
            }
                
        }

        private void HandleJobState(State state, string msg)
        {
            switch(state)
            {
                case State.Error:
                    view.DisplayError(msg);
                    break;
                case State.Warning:
                    view.DisplayWarning(msg);
                    break;
                case State.Processing:
                    view.DisplayInfo(msg);
                    break;
                case State.Success:
                    view.DisplaySuccess(msg);
                    break;
            }
        }

        private void AssignEvents()
        {
            view.InputEvent += delegate (string input)
            {
                HandleInputs(input);
            };

            // TODO change state to a more complete type
            model.Jobs.JobState += delegate (State state, string msg)
            {
                HandleJobState(state, msg);
            };
        }

        /// <summary>
        /// Start the main programm..
        /// </summary>
        public void Start()
        {
            view.Start();
        }
    }
}
