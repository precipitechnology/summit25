function Import-Assembly {
    param(
        [Parameter(Mandatory)]
        [string]$Path
    )
    [System.Reflection.Assembly]::LoadFrom((Resolve-Path $Path))
}