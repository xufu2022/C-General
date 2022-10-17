# Null values

## Summary

| **Nullable structs**                                                                                               | **nullable classes** |
|:------------------------------------------------------------------------------------------------------------------|------------|
|MyStruct? and MyStruct and different types|MyClass? and MyClass are the same type|
|(MyStruct)?, under the hood becomes System.Nullable<MyStruct>)|All classes are intrinsically nullable under the hood|

