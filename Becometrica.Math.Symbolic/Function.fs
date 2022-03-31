namespace Becometrica.Math.Symbolic

[<ReferenceEquality>]
type Function =
    { Category: string; Name: string; Aliases: string list; ArgumentCount: int; Description: string }
    override x.ToString() = x.Name

    static member Create category name aliases argumentCount description =
        { Category = category; Name = name; Aliases = aliases; ArgumentCount = argumentCount; Description = description }

    static member CreateNoAliases category name argumentCount description =
        Function.Create category name [] argumentCount description

    static member CreateUnary category name aliases description =
        Function.Create category name aliases 1 description

    static member CreateUnaryNoAliases category name description =
        Function.Create category name [] 1 description

    member x.GetNameAndAliases() =
        seq { x.Name; for alias in x.Aliases do alias }

    member x.TestArgumentCount args =
        if x.ArgumentCount <> (List.length args) then
            invalidArg (nameof args) $"Invalid argument count for '%O{x}' function or operator"
