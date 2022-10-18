# Working with System.Object

All types inherit (directly or indirectly) from System.Object

Even primitive types like **int or bool** do so

This means all types you create get some useful features out of the box

Take advantage of System.Object
- Make your types easier to debug
    - Provide string representations of them
- Equality support
    - Allow comparing by value or reference

Showing what System.Object gives you

```csharp
    static Equals()
    virtual Equals()
    static ReferenceEquals()
    virtual ToString()
    virtual GetHashCode ()
    protected MemberwiseClone()
    GetType()
```

System.Object Methods

>   Equality support 
-   virtual Equals()
-   static Equals()
-   static ReferenceEquals()

> Support for dictionaries 
> String representation
-   virtual GetHashCode ()
-   protected MemberwiseClone()
-   GetType()

## System.Object Equality Support

```csharp
    virtual bool Equals(Object? obj) { /* etc. */ } 

    static bool Equals(Object? objA, Object? objB){/* etc.*/} 

    static bool ReferenceEquals(Object? objA, Object? objB) {/* etc.*/ }
```

### Types of equality

> virtual bool Equals(Object? obj) : Implemented to check reference equality
> override bool Equals(Object? obj) : Can override to check value equality

> Applying Equality to Value Types

**For both structs and classes**, if you want to be able to **compare values** for a type, consider declaring that type as a **record**

> Value Equality :
What if you don’t want to declare a type as a record? Then you must override Object.Equals() yourself
