These scripts are intended to speed-up and simplify development in Visual Studio.

They depend on you having the following:
1) Visual Studio 2015
2) An Environment Variable named "payspanroot" (without the quotes) that 
	evaluates to the directory where you cloned the All-Apps repository
	(	ssh://git@jaxscm1.payformance.net:7999/pspan/all-apps.git)
	In my case, that is C:\Git\All-Apps\

Setup Instructions:
1) Clone this repository
2) Add the folder that you cloned it into to your system PATH

To integrate the build and clean in Visial Studio:
1) Click Tools -> External Tools
2) Add ->
	a) Build.bat
		i)		Title: &Build
		ii)		Command: Build.bat
				(include the full path if you did not add the scripts repository
				to your path, or if you have multiple build.bat files)
		iii)	Arguments: $(SolutionDir) $(SolutionFileName) $(Configuration)
		iv)		Check the 'Use Output Window' option
	b) Clean.bat
		i)		Title: &Clean
		ii)		Command: Clean.bat
				(include the full path if you did not add the scripts repository
				to your path, or if you have multiple Clean.bat files)
		iii)	Check the 'Use Output Window' option
3) Move '&Build' to the top of the list
4) Move '&Clean' up just below that
	this makes these items correspond to Tools.ExternalCommand1 & Tools.ExternalCommand2
5) OK
6) Tools -> Options -> Environment -> Keyboard
7) Show commands containing "Tools.ExternalCommand"
8) Bind Tools.ExternalCommand1 & Tools.ExternalCommand2 to your 
	preferred keys (I've used F6 and F7)

Be sure to Suspend R# before cleaning or building. 
To make that easy, bind Resharper_ToggleSuspended to something nice
	I like CTRL+SHIFT+ALT+Q

