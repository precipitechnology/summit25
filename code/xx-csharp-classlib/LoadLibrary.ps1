. ./Import-Assembly.ps1

Invoke-Command {dotnet build}

Import-Assembly -Path "./bin/Debug/net9.0/SampleLibrary.dll"

if ($isWindows)
{
    [SampleLibrary.ADHealthCheckBuilder]::new()
} else {
    [SampleLibrary.ProcessLister]::ListProcesses()
}