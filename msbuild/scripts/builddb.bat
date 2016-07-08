@ECHO OFF
IF "%BuildHasRun%"=="" CALL "C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\vcvarsall.bat" amd64
SET BuildHasRun=Yes
SET conf="%1"
SET verb="%2"
SET para="%3"
IF %conf%=="" (
	SET conf=Debug
)
IF %verb%=="" (
	SET verb=m
)
if %para%=="" (
	set para=1
)
PUSHD %payspanroot%
PUSHD solutions

msbuild /v:%verb% /m:%para% /p:Platform="Any CPU" /p:Configuration=%conf% /nr:false /ds HPXDatabases.sln

POPD

SET srcDir=HPX
SET artDir=%srcDir%-SQL-Artifacts
IF EXIST %artDir% RD /s /q %artDir%
MKDIR %artDir%
PUSHD %srcDir%
FOR /f "delims=" %%i in ('dir /D /S /B /Q *.dacpac') DO COPY "%%i" ..\%artDir%
FOR /f "delims=" %%i in ('dir /D /S /B /Q *.publish.xml') DO COPY "%%i" ..\%artDir%
POPD

SET srcDir=PCI
SET artDir=%srcDir%-SQL-Artifacts
IF EXIST %artDir% RD /s /q %artDir%
MKDIR %artDir%
PUSHD %srcDir%
FOR /f "delims=" %%i in ('dir /D /S /B /Q *.dacpac') DO COPY "%%i" ..\%artDir%
FOR /f "delims=" %%i in ('dir /D /S /B /Q *.publish.xml') DO COPY "%%i" ..\%artDir%
POPD

POPD
ECHO Work Complete.