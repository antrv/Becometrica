namespace Becometrica.Math.Symbolic

[<ReferenceEquality>]
type Constant =
    { Name: string; UnicodeName: string; ApproximateValue: float option; Description: string }
    override x.ToString() = x.Name
    static member Create name unicodeName value description =
        { Name = name; UnicodeName = unicodeName; ApproximateValue = value; Description = description }
