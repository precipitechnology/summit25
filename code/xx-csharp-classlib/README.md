# SampleLibrary Demo

This is a simple class library that forms the basis of our reusability demos

## Requirements

- .NET 9
- PowerShell 7+

If you are running Windows, the default load script will invoke a windows only capability, else a simple process dump will be generated

## Usage

Assuming you have cloned this locally:

```pwsh
./LoadLibrary.ps1
```

### Step-by-step

```pwsh
dotnet build
```

```pwsh
$dllPath = <PATH to SampleLibrary.dll>
[System.Reflection.Assembly::LoadFile($dllPath)]
```
On Windows Domain member
```pwsh
[SampleLibrary.ADHealthCheckBuilder]::new()
```

or
```pwsh
[SampleLibrary.ProcessLister]::ListProcesses()
```