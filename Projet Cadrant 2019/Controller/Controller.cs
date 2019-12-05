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

        private Parser parser;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;

            this.model.GetDisplayable().DisplayUpdateEvent += this.view.DisplayText;

            this.parser = new Parser();

            this.AssignEvents();
        }

        /// <summary>
        /// Handle the inputs event register from the view.
        /// </summary>
        /// <param name="input">Input from the view</param>
        private void HandleInputs(string input)
        {
            string name = parser.ParseName(input);
            BaseJob job = model.GetJobByName(name);

            // Catch exception that can append during commands executions.
            /*try
            {*/
                if (job == null)
                    throw new Exception("Command not found : " + name);

                job.Execute(parser.ParseOptions(input));
            /*}
            catch (Exception e)
            {
                view.DisplayText(Helpers.Statut.ERROR, e.Message);
            }
            finally
            {*/
            view.ReadConsoleLine();
            //}
 
        }

        /// <summary>
        /// Assign functions to the differents events.
        /// </summary>
        private void AssignEvents()
        {
            view.InputEvent += delegate (string input)
            {
                HandleInputs(input);
            };
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