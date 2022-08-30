# Inspection

## Defining reflection
- Assemblies, modules, types, members

## Reading metadata
- MethodInfo and its specialized forms
- Early binding, late binding, and BindingFlags

- Assembly : A collection of types and resources that are built to work together and form a logical unit of functionality

- Module : A portable executable file, such as type.dll or application.exe, consisting of one or more classes and interfaces

- System.Reflection.MethodInfo => System.Reflection.MethodBase => System.Reflection
.MemberInfo (System.Reflection.ParameterInfo )

# Binding

The process of locating the declaration (that is, the implementation)  that corresponds to a uniquely specified type

## Early and Late Binding

Early : Looks for methods and properties and checks whether they exist and match at compile time
You won’t be able to compile a mismatch

Late binding : 

- The objects are dynamic, so the compiler cannot give a warning
- The actual type is only decided upon at runtime

## BindingFlags enumeration

Used to control binding and to control how reflection searches

- Control how reflection searches
    - BindingFlags.Public,
    - BindingFlags.Instance
- Control the binding itself
    - BindingFlags.GetProperty
    - BindingFlags.SetField
- Can be combined bitwise
    - BindingFlags.Instance | BindingFlags.NonPublic

Reflection is the process by which a computer program can observe and modify its own structure and behavior

- Dynamic instance creation
- Binding a type to an existing object
- Getting the type from an existing object
