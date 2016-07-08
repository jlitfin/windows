SET conf="%1"
SET verb="%2"
SET para="%3"
SET outfolder="%4"
IF %conf%=="" (
	SET conf=Debug
)
IF %verb%=="" (
	SET verb=n
)
if %para%=="" (
	set para=16
)
if %outfolder%=="" (
	set outfolder=C:\Packages
)
PUSHD %PAYSPANROOT%
PUSHD Solutions
IF EXIST nuget.exe (
nuget.exe restore Everything.sln
)
msbuild /v:%verb%  /m:%para% Everything.sln /p:Platform="Any CPU" /p:Configuration=%CONF% /ds /nr:false /p:TreatWarningsAsErrors=False /p:DeployOnBuild=True /p:DeployTarget=Package /p:PublishProfile=./Properties/PublishProfiles/%CONF%.Package.pubxml /p:DeployTarget=Package /p:DesktopBuildPackageLocation=%outfolder%
POPD
POPD
ECHO Work Complete.