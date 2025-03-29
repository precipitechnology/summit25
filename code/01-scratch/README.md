# By HAND or by C(sharp)!

Make a new directory and enter into it

```pwsh
New-Item -type Directory "lab-fromscratch"
Set-Location "./lab-fromscratch"
```

Create a file called `Program.cs` and place the following content in the file

```csharp
Console.WriteLine("Hello, Summit25");
```

Create a file called `FromScratch.csproj` and place the following content in the file

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

and now invoke the following command
```pwsh
dotnet run
```
Congrats! you now have an incredibly long winded way of 

```bash
echo "Hello Summit25"
```

But a lot more went into that, you created from scratch, a .NET Cli application, which allowed your single `Console.WriteLine` statement to be transformed into Intermediate Language (IL), compiled by the .NET SDK into a platform-independent binary, and then just-in-time (JIT) compiled by the runtime into native machine code — all so it could light up your terminal with `"Hello, Summit25"` when executed. With a few build arguments, we could make that a giant file that runs on systems without .Net even being present, on any number of operating systems and processor architectures! who needs `txt` files when we can do that?