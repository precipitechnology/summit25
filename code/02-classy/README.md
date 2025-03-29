# Stay Classy

First, we will create a class library project

```pwsh
dotnet new classlib -o ./lib -n Classy
```

Open that up in your favorite editor and adjust the default `Class1.cs` accordingly

```csharp
public class Greeting
{
}
```

Notice the lack of `()` at the end there? the Class itself does not have those as it is not invoked,
the keyword `public` refers to its accesibilty and the keyword `class` tells the compiler that this is a class

Classes are the heart and soul of any OOP based language, and even though powershell is OOP, it does a lot of magic to obfuscate classes from you on a day to day basis

in C# classes are everything and everything is a class

Classes have a combination of `properties`, and `methods`, you should be familiar with these from all the powershell you have written

Lets add some properties

```csharp
public string Salutation {get; set;} = "Hello";
public string Audience {get; set;}
```

so lets break that down a bit

We declare two seperate properties, giving them types and names with the `public string PropertyName` text
in this instance, both properties are of type `string` one called `Salutation` and one called `Audience`
`public` like at the class level is an access modifier

At the end of the line we have a getter and a setter `{ get; set; }` meaning the properties are able to be read and written to,
our first example also takes advange of a .Net feature allowing us to define a default value `= "Hello";`

We follow up by creating some methods on the class,

```csharp
public Greeting()
{
}

public Greeting(string aud)
{
    Audience = aud;
}

public Greeting(string sal, string aud)
{
    Salutation = sal;
    Audience = aud;
}
```

These special methods are called `Constructors` and are easy to spot because they have no return type (not even void) and have the same name as the class itself
We also demonstrate the concept of `overloading` here by having three constructors (same name) but with different signatures (arguments)
this allows us to have different behavior based on what is provided to our class when instantiated, our tooling can also pick up on this given we are using a strongly typed language like C#

Finally we add a method to the class that returns a type `string`

```csharp
public string Greet()
{
    if (!string.IsNullOrWhiteSpace(this.Audience))
    {
        return string.Format("{0}, {1}", this.Salutation, this.Audience);
    }
    return this.Salutation;
}
```

note the `()` at the end of the method, and the introduction of a type `string`, we also are not able to name the method the same as the encapsulating class (Greeting) even if we wanted to, and we can't call constructors anything other than the encapsulating class name, easy so far? 😁

## Cli Harness

Lets start to demonstrate the usefulness of a 'library' that by itself doesn't do anything, but wrapping it in a quick CLI and calling it

```pwsh
dotnet new console -o ./cli -n ClassyCli
Set-location ./cli
```

Lets now add a reference to the dll we generated in our library
the DLL should be located relative, there is not a cli command to do this to a raw DLL like this, so edit your `.csproj` file and add the `<ItemGroup>` so it looks like the below

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include="Classy">
      <HintPath>..\lib\bin\Debug\net9.0\Classy.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
```


Open it up in your favorite editor and lets adjust the Program.cs

```csharp
using Classy;

var output = new Classy.Greeting();

Console.WriteLine(output);
```

When you run that, you may notice that you dont get the expected output
Thas because you are asking to return the object itself

if we tweak that line to say

```csharp
Console.WriteLine(output.Greet());
```

and re-run `dotnet run` we should now see the text output, exactly how we defined it in the library

