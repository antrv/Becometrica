# Becometrica

A set of utility libraries for .NET.

## Becometrica.Unsafe

A set of helper types for interoperability with native code,
without the use of unsafe code. These are useful for defining 
structures with pointers or for cases where references cannot 
be used due to the possibility of a null value.

```csharp
// Using in structures
public struct SomeNativeStruct
{
    public Utf8StringPtr Name;
    ...
    public ConstPtr<OtherStructure> Records;
    public nuint RecordCount;
    ...
    public FuncPtr<Ptr<OtherStructure>, Ptr<OtherStructure>, int> Compare;
}

// Native function
[DllImport(DllName = "SomeNativeLibrary")]
public static bool GetStructure(out Ptr<SomeNativeStruct> data);
```
