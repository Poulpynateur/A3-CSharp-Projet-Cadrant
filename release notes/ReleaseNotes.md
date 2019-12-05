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