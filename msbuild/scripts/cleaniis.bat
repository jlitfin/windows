IISRESET /STOP
FOR /f "delims=" %%i in ('dir /AD /D /B /Q "C:\Windows\Microsoft.NET\Framework\v2.0.50727\Temporary ASP.NET Files"') DO RD /s /q "C:\Windows\Microsoft.NET\Framework\v2.0.50727\Temporary ASP.NET Files\%%i" 
FOR /f "delims=" %%i in ('dir /AD /D /B /Q "C:\Windows\Microsoft.NET\Framework64\v2.0.50727\Temporary ASP.NET Files"') DO RD /s /q "C:\Windows\Microsoft.NET\Framework64\v2.0.50727\Temporary ASP.NET Files\%%i" 
FOR /f "delims=" %%i in ('dir /AD /D /B /Q "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Temporary ASP.NET Files"') DO RD /s /q "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Temporary ASP.NET Files\%%i" 
FOR /f "delims=" %%i in ('dir /AD /D /B /Q "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET Files"') DO RD /s /q "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET Files\%%i" 
IISRESET /START

ECHO Work Complete.