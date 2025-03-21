function Import-Assembly {
    param(
        [Parameter(Mandatory)]
        [string]$Path
    )
    [System.Reflection.Assembly]::LoadFrom((Resolve-Path $Path))
}

Invoke-Command {dotnet build}

Import-Assembly -Path "./bin/Debug/net9.0/SampleLibrary.dll"

[SampleLibrary.ADHealthCheckBuilder]::new()