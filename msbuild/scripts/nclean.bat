@ECHO OFF

REM This section is directories we want to delete.
ECHO node_modules>deleteMe.txt
FOR /f "delims=" %%x in (deleteMe.txt) DO (
	DIR /AD /D /S /B /Q %%x >dirlist.txt 2>&1
	FOR /f "delims=" %%i in (dirlist.txt) DO (
		IF EXIST "%%i" (
			ECHO Removing Directory "%%i%"
			RD /s /q "%%i"
		)
	)
)

DEL /F /Q dirlist.txt
DEL /F /Q deleteMe.txt
ECHO Work Complete.