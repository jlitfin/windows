REM @ECHO OFF
IF "%BuildHasRun%"=="" (
ECHO Running vcvarsall
CALL "C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\vcvarsall.bat" amd64
)
SET BuildHasRun=Yes
@ECHO ON
SET solDir=%1
SET solFname=%2
SET conf="%3"
IF %conf%=="" (
	SET conf=Debug
)
PUSHD %solDir%
IF EXIST nuget.exe (
	nuget.exe restore %solFname%
)
msbuild /v:n /m /p:Platform="Any CPU" /p:Configuration=%conf:"=% /nr:false /p:WarningLevel=0 %solFname%
POPD
ECHO Build Complete