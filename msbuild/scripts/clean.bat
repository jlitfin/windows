@ECHO OFF
PUSHD %PAYSPANROOT%

REM This section is directories we want to delete.
ECHO FakesAssemblies>deleteMe.txt
ECHO Bin>>deleteMe.txt
ECHO Obj>>deleteMe.txt
ECHO AR2>>deleteMe.txt
ECHO AR3>>deleteMe.txt
ECHO .sass-cache>>deleteMe.txt
ECHO TestResults>>deleteMe.txt
FOR /f "delims=" %%x in (deleteMe.txt) DO (
	DIR /AD /D /S /B /Q %%x >dirlist.txt 2>&1
	FOR /f "delims=" %%i in (dirlist.txt) DO (
		IF EXIST "%%i" (
			ECHO Removing Directory "%%i%"
			RD /s /q "%%i"
		)
	)
)

REM This section is files we want to delete.
ECHO *.dbmdl>deleteMe.txt
ECHO dataCacheClient.xml>>deleteMe.txt
ECHO CacheClient.xml>>deleteMe.txt
FOR /f "delims=" %%x in (deleteMe.txt) DO (
	DIR /D /S /B /Q %%x >dirlist.txt 2>&1
	FOR /f "delims=" %%i in (dirlist.txt) DO (
		IF EXIST "%%i" (
			ECHO Deleting "%%i%"
			DEL /F /Q "%%i"
		)
	)
)

DEL /F /Q dirlist.txt
DEL /F /Q deleteMe.txt

IF EXIST "Solutions\Packages" (
	PUSHD "Solutions"
	PUSHD "Packages"
	dir /B /AD>deleteMe.txt
	FINDSTR /V Microsoft\.Bcl.* deleteMe.txt>dirlist.Txt
	FINDSTR /V Microsoft\.Net\.Http.* dirlist.Txt>deleteMe.txt
	FOR /f "delims=" %%x in (deleteMe.txt) DO (
		IF EXIST "%%x" (
			ECHO Removing Package "%%x"
			RD /s /q "%%x"
		)
	)
	DEL /F /Q dirlist.txt
	DEL /F /Q deleteMe.txt
	POPD
	POPD
)
POPD

ECHO Work Complete.