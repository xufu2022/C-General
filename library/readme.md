# Class Library

> Class Library Project Naming

- Assembly .dll files default to project name
- “choose names for your assembly DLLs that suggest large chunks of functionality, such as System.Data.” [MS docs]
- Microsoft suggests to consider the format: <Company>.<Component>.dll

## Configuring and Building Class Libraries

- Building a class library project
    - Globomantics.Math.AssemblyInfo.cs
    - Globomantics.Math.GlobalUsings.g.cs
- Understanding the ImplicitUsings property
    - <ImplicitUsings>
- Understanding the TargetFramework property <TargetFramework>
- Understanding the Nullable property   <Nullable>
- How to add assembly level attributes  <AssemblyAttribute>
- Assembly level attributes for non-string values   [assembly: NUnit.Framework.Timeout(1000)]
- Assembly level attributes across multiple projects    Directory.Build.props
- Adding NuGet package references   Adding NuGet package references
- Adding DLL references 

## An Overview of Multi-targeting

- Output multiple DLL files from a single project
- Each DLL supports (“targets”) a different .NET version
- Makes class library more widely consumable
- Compile different C# code for different targets (.dll)
- Support different targets for different apps 
- inside your organization
- Support different targets for open source 
- libraries on NuGet.org
- Access version/target-specific APIs
  
## Target Framework Moniker (TFM)

A standardized “code” that represents a target framework.

| **Framework & version**                                                                                               | **TFM** |
|:------------------------------------------------------------------------------------------------------------------|------------|
|.NET Framework 4.8      |   net48   |
|.NET Core 3.1       |   netcoreapp3.1   |
|.NET Standard 2.1       |   netstandard2.1  |
|.NET 5      |   net5.0  |
|.NET 6      |   net6.0  |


> OS-specific TFMs
- Allow APIs from a specified operating system 
- to be available
- Introduced from .NET 5 and onwards
- Examples:
  - net6.0-windows
  - net6.0-ios
  - net6.0-ios15.1

> Conditional Compilation Preprocessor Directives

Allow you to include or exclude source code from the compilation process based on whether or not specific preprocessor symbols have been defined

Preprocessor Symbol: a named text “flag” that can either exist (“defined”) or not exist (“undefined”), i.e. a Boolean value.

Conditional Compilation Preprocessor Directives

| **Preprocessor**                                                                                               | **Description** |
|:---------------------------------------------------|------------|
| #if | Starts a conditional compilation block |
| #elif  | “else if” Alternate conditional block |
| #else  | Alternate block if other blocks not matched |
| #endif | Ends a conditional compilation block |

```csharp
    #if DEBUG
        Console.WriteLine("DEBUG is defined");
    #else
        Console.WriteLine("DEBUG is not defined");
    #endif
    // The DEBUG preprocessor symbol is automatically defined during debug builds
```

> #error : Generates a compiler error with a custom message.

Auto-defined Symbols for TFMs

 <a href="https://learn.microsoft.com/en-us/dotnet/standard/frameworks" target="_blank">TFM / Symbol Documentation</a> 

##  Versioning, Packaging, and Distributing Class Libraries

### An Overview of Version Numbering

- .NET assembly version number (.dll file)
- NuGet package version number

    -   Part of an assembly’s “identity”
        - Assembly name
        - Any culture information
        - Strong naming public key
    -   “Strong-naming an assembly creates a unique identity for the assembly, and can prevent assembly conflicts.” [MS]
    -   “For .NET Core and .NET 5+, strong-named assemblies do not provide material benefits. The runtime never validates the strong-name signature, nor does it use    the  strong-name for assembly binding.” [MS]
    -   This version number is embedded in the assembly DLL file

> Sematic Versioning (2.0.0)

-   “SemVer” for short
-   Specific rules for version numbering
-   NuGet packages
    - NuGet 4.3.0+
    - Visual Studio 2017 v15.3+
-   Increment major version number when making any breaking changes to the API
-   Increment minor version number when adding backwards-compatible new functionality
-   Increment patch version number when making backwards-compatible bug fixes

Example:

    Initial version - 1.0.0
  
    Fixed a bug - 1.0.1

    Fixed another bug - 1.0.2

    New backwards-compatible feature - 1.1.0 (patch reset to zero)

    Fixed a bug - 1.1.1

    New non backwards-compatible change - 2.0.0 (minor and patch reset to zero)

Optional Labels :

    Denote pre-release versions
        - Maybe be unstable / incompatible
        - Add hyphen after patch number
        - One or more dot-separated alphanumeric (and hyphen) strings
        - 1.0.0-beta1
  

    Add build metadata
        - Add plus sign after patch or pre-release
        - One or more dot-separated alphanumeric (and hyphen) strings
        - 1.0.0+d241853866f20fc3e536cb3bca86c86c54b723ce
        1.0.0-beta2+36843

Semantic versioning allows you to communicate changes in your class library project NuGet package to its consumers

### An Overview of NuGet Packages

- ZIP file that has a “.nupkg” extension
- May contain one or many .NET assemblies
  - E.g. a class library project DLL
- May contain other files
    - Images
    - Text files
    - Powershell scripts, etc.
- Contains a manifest file
    - Describes package contents
    - Package version number (SemVer)
    - Package ID, description, author, etc.
- Host on public (e.g. NuGet.org) or private host (“gallery”)


<AssemblyVersion>2.2.2.2</AssemblyVersion>
dotnet build /p:Version=4.0.0.1
