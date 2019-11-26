using EasySave.Model;
using EasySave.Model.Command;
using EasySave.View;
using System;
using System.Collections.Generic;

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
            string name = parser.ParseName(input);
            ICommand cmd = model.getCmdByName(name);

            try
            {
                if (cmd == null)
                    throw new Exception("Command not found : " + name);

                Dictionary<string, string> options = parser.ParseOptions(input);

                view.DisplayInfo("Starting command " + name + " ...");
                string result = cmd.Execute(options);

                view.DisplaySuccess(result);
            }
            catch (Exception e)
            {
                view.DisplayError(e.Message);
            }
        }

        private void AssignEvents()
        {
            view.InputEvent += delegate (string input)
            {
                HandleInputs(input);
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
