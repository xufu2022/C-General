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

## Instantiating and Manipulating Objects

## Reflection Behind the Scenes

    System.Reflection.RuntimeMethodInfo.Invoke, which **calls** into System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal

    System.RuntimeMethodHandle.PerformSecurityCheck, which calls into System.GC.KeepAlive

    System.RuntimeMethodHandle.InvokeMethod

-   Getting the info object 
    - Type metadata parsing
-   Actual method invocation 
    - Argument validity checks
    - Error handling
-   Security checks
    - Restricted methods
    - Dynamic code access security permissions

-   Dynamic activation and invocation at runtime is reasonably common

    - Relationships between the different components are determined at runtime 
    - Decreases the amount of tight coupling

<unwrap> unwrap the object

## Using Reflection with Generics

### Advantages of Generics

- Type safety: compiler will throw an error on unsafe cast
- Reusability: one generic class can be used on a variety of types
- Improved performance

## Advanced

-   Security implications from past to present
-   Working towards cleaner code with **ReflectionMagic**

Reflection was influenced by CAS
- SecurityCritical attribute
- ReflectionPermissionFlag enumeration
- The reflection-only context allowed loading assemblies for inspection but not execution
**.NET 6 no longer supports or honors these**

        var person = new Person("Kevin");
        var privateField = person.GetType().GetField("_aPrivateField",BindingFlags.Instance | BindingFlags.NonPublic);
        privateField.SetValue(person, "New private field value");

## Working Towards Cleaner Code with ReflectionMagic

ReflectionMagic is a library that helps with writing cleaner code
- Uses a custom DynamicObject underneath the covers

        var person = new Person("Kevin");
        person.AsDynamic()._aPrivateField = "Updated value via ReflectionMagic";
