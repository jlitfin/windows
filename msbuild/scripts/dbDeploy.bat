SET SrcDir=C:\git\all-apps\HPX-SQL-Artifacts\
PUSHD %SrcDir%
ECHO fe^|OnlineSearchProvider_Template > DeploymentOrder.txt
ECHO fe^|OnlineSearchPayer_Template >> DeploymentOrder.txt
ECHO mart^|OnlineSearchProvider_Template >> DeploymentOrder.txt
ECHO mart^|OnlineSearchPayer_Template >> DeploymentOrder.txt
ECHO fe^|OnlineSearchDelegatedPartner >> DeploymentOrder.txt
ECHO fe^|OnlineSearchAdmin >> DeploymentOrder.txt
ECHO billing^|PaySpanHealth_Billing >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_Transmission >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_Tracking >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_Storage >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_Logging >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_CareFirst >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_Caching >> DeploymentOrder.txt
//ECHO be^|PaySpanConfig >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_Security >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_Work >> DeploymentOrder.txt
ECHO be^|HPXDenialDetector >> DeploymentOrder.txt
ECHO be^|PaySpanHealth_JobSystem >> DeploymentOrder.txt
ECHO //be^|PaySpan.Bpa.Db >> DeploymentOrder.txt
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