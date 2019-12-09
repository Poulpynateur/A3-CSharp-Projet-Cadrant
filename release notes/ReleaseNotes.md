# Release Notes - V 1.0.0

First version of the EasySave software.

## New Features

- New commands :
	- help : show every commands (name, description and list of options)
	- save-differential : launch a differential save
	- save-mirror : launch a mirror save
	- add-task : add a task to the configuration file
	- remove-task : remove a task from the configuration file
	- execute-task : execute one specific task or every tasks
	- list-tasks : show every task saved to configuration

- Logs :
	- Task execution is save into a log file (json format) in the *_log* folder
	- Save commands (*save-mirror and save-differential*) progress is saved in real time in the file *progress.json* in the *_log* folder

### Tasks

- Task are saved in real time in the file *_config/tasks.json*

# Release Notes - V 1.0.1

Slight change to the save.

## Improvements

- Change mirror save :
	- The user must give a name to the folder where the files will be saved
	- A subfolder with the date is created inside this folder (the files will be written there)

- Change differential save :
	- The user must give a name to the folder where the files will be saved and where the configuration file will be write
	- A subfolder with the date is created inside this folder (the files will be written there)

# Release Notes - V 1.0.2

[Code](https://dev.azure.com/Groupe5/_git/Projet%20Cadrant%202019?version=GC83a00ada35391e64ca5eea4a0e4d66b1f3449dca)
Prepare the migration to WPF interface.

## New Features

- Add a Output class that gather :
	- Logger management
	- Config management
	- Display (will be implemented later to send data in real time from model to view)

## Improvements

- Change the name "command" to more general "job"
- Helpers :
	- Change Helpers name
	- Modify Helpers to static classes

- Slightly update the job (simplification and optimization)
- Add a class specially for option (add a description)

# Release Notes - V 2.0.0

[Code](https://dev.azure.com/Groupe5/_git/Projet%20Cadrant%202019?version=GC7698ba3dc59a4e184e9f2153a067201b3270a6f8)
New modern WPF interface.

## New Features

- WPF interface :
	- Quick save :
		- User firendly interface for commands "save-mirror" and "save-differential"
	- Task manager :
		- User firendly interface for command "add-task", "remove-task", "list-tasks" and "execute-task"
	- Display :
		- Outputs of the jobs are displayed at the bottom of the window (with colors)
	- The user can choose to crypt a quick save or a task with CryptoSoft
- Add a class Encrypt to start CryptoSoft

## Improvements

- Ilimited number of tasks
- Modfify job Progress log : add time of the encryp in progress.json
- "remove-task" and "execute-task" can accept a list of task names