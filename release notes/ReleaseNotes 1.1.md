# Release Notes - V 1.0

First version of the EasySave software.

## New Features

### New commands

- **help** : show every commands (name, description and list of options)
- **save-differential** : launch a differential save
- **save-mirror** : launch a mirror save
- **add-task** : add a task to the configuration file
- **remove-task** : remove a task from the configuration file
- **execute-task** : execute one specific task or every tasks
- **list-tasks** : show every task saved to configuration

### Logs

- Task execution is save into a log file (json format) in the *_log* folder
- Save commands (*save-mirror and save-differential*) progress is saved in real time in the file *progress.json* in the *_log* folder

### Tasks

- Task are saved in real time in the file *_config/tasks.json*