SET SrcDir=C:\git\all-apps\PCI-SQL-Artifacts\
PUSHD %SrcDir%
ECHO be^|PCI_Encrypted> DeploymentOrder.txt
ECHO be^|PCI_Logging> DeploymentOrder.txt
IF EXIST sqlOutput RD /s /q sqlOutput
MKDIR sqlOutput
POPD

CALL PaySpan.DatabaseDeploy.exe^
 /sql=120^
 /fe=.\FRONTEND^
 /be=.\BACKEND^
 /billing=.\FRONTEND^
 /MaxPayers=10^
 /MaxProviders=10^
 /Action=Publish^
 /OutputPath=%SrcDir%sqlOutput^
 /directory=%SrcDir%^
 /environment=QA1^
 /BlockTableRebuilds=false
 
RD /s /q %SrcDir%
ECHO Work Complete.