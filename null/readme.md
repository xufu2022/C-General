# Null-value-type and strings

Reference and Value Types Overview

| Value  | Reference |
|---------------------|----------------|
|C# struct|C# class|
|Independent instances/copies|Single shared instance|
|Value change doesn’t affect other copies|Value change affects people (references) pointing to it|
|The value is the information|The reference points to the information|
|No reference, cannot be null|Reference may point to “nothing” (null)|
|No need to check for nulls|Null checking code may be required|

Examples of NullReferenceException Causes

- Get / set property 
- Call a method 
- Get / set field

A value type may sometimes need to represent a null value
“Magic numbers”: **Nullable<T>**

> Nullable Value Types

A nullable value type is an instance of the System.Nullable<T> struct. A nullable value type can 
represent all the values of the value type T, plus an additional null value.

> Undefined / missing value

### Introduction to Nullable Value Types with Nullable<T>

# Accessing and Checking for Null Values

> More on Nullable<T>

- .HasValue // false if null, otherwise true
- .Value // gets underlying value
- .GetValueOrDefault() // underlying value or default
- .GetValueOrDefault(default) // value or specified default

> Comparing Nullable<T> Instances

    int? i = null;
    int? j = null;
    bool areEqual = i == j; // true

> Nullable<T> Conversions

    // Implicit conversion from T --> Nullable<T>
    int i = 42;
    int? j = i; // no explicit casting/conversion required

    // Explicit conversion required from Nullable<T> to T
    int? i = 42;
    int j = i; // Compiler error, no implicit conversion
    int j = (int)i; // explicit cast
    int? i = null;
    int j = (int)i; // Runtime InvalidOperationException    

> Default Values for Nullable Value Types

    int? i;
    Console.WriteLine(i); // Use of unassigned local variable
    int? i = default; // i == null
    int? i = default(int); // i == 0
    bool? b = default; // b == null
    bool? b = default(bool); // b == false

> Overview of C# Null-related Operators

- Conditional operator ?:
- Null-coalescing operator ??
- Null-coalescing assignment operator ??=
- Null-conditional operator ?. ?[]
- Null-forgiving operator !

    > The Null-coalescing Assignment Operator

        string name = Console.ReadLine();
        if (name is null) // name == null
        {
        name = "No name entered";
        }
        Console.WriteLine(name);        

    > The Null-coalescing Assignment Operator

        string name = Console.ReadLine();
        name ??= "No name entered"; // from C# 8
        Console.WriteLine(name);

    > The Null-coalescing Assignment Operator

        string name = Console.ReadLine();
        name ??= "No name entered"; // from C# 8
        Console.WriteLine(name);

    > Thread-Safe Null Delegate Invocation

        public event EventHandler NameChanged;
        ...
        EventHandler eventHandler = NameChanged;
        if (eventHandler != null) 
        { 
        eventHandler(this, EventArgs.Empty); 
        }

    > Thread-Safe Null Delegate Invocation

        public event EventHandler NameChanged;
        ...
        EventHandler eventHandler = NameChanged;
        if (eventHandler != null) 
        { 
        eventHandler(this, EventArgs.Empty); 
        }

    > Thread-Safe Null Delegate Invocation

        public event EventHandler NameChanged;
        ...
        NameChanged?.Invoke(this, EventArgs.Empty);

    > Thread-Safe Null Delegate Invocation

        public event EventHandler NameChanged;
        ...
        NameChanged?.Invoke(this, EventArgs.Empty);

# Eliminating Null Reference Exceptions with the Null Object Pattern

> Null Object Pattern

A software design pattern that uses object-orientation to remove or reduce the amount of null reference exceptions. 

By implementing the pattern, the burden of repetitive null checking code can also be reduced in the codebase.

# Understanding Nullable and Non-Nullable Reference Types

