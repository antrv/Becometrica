using System.Runtime.CompilerServices;

namespace Becometrica;

public static class Conversion
{
    /// <summary>
    /// The function converts a boolean value to 32-bit integer in a branchless way
    /// (which is often much faster than the code <code>value ? 1 : 0</code> with branches).
    /// The function perfectly inlines and generates 2 cpu instructions.
    /// </summary>
    /// <param name="value">The boolean value.</param>
    /// <returns>0 if <paramref name="value"/> is false, 1 if <paramref name="value"/> is true.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static unsafe int BooleanToInt32(bool value) => 1 & *(byte*)&value;

    /// <summary>
    /// The function converts a boolean value to 64-bit integer in a branchless way
    /// (which is often much faster than the code <code>value ? 1 : 0</code> with branches).
    /// The function perfectly inlines and generates 2 cpu instructions.
    /// </summary>
    /// <param name="value">The boolean value.</param>
    /// <returns>0 if <paramref name="value"/> is false, 1 if <paramref name="value"/> is true.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static unsafe long BooleanToInt64(bool value) => 1L & *(byte*)&value;

    /// <summary>
    /// The function converts a boolean value to 32-bit integer in a branchless way
    /// (which is often much faster than the code <code>value ? 1 : 0</code> with branches).
    /// The function is unsafe because it returns binary representation of
    /// <paramref name="value"/> which can be different from 0 or 1.
    /// The function perfectly inlines and generates one cpu instruction.
    /// </summary>
    /// <param name="value">The boolean value.</param>
    /// <returns>0 if <paramref name="value"/> is false, 1 if <paramref name="value"/> is true.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static unsafe int UnsafeBooleanToInt32(bool value) => *(byte*)&value;

    /// <summary>
    /// The function converts a boolean value to 64-bit integer in a branchless way
    /// (which is often much faster than the code <code>value ? 1 : 0</code> with branches).
    /// The function is unsafe because it returns binary representation of
    /// <paramref name="value"/> which can be different from 0 or 1.
    /// The function perfectly inlines and generates one cpu instruction.
    /// </summary>
    /// <param name="value">The boolean value.</param>
    /// <returns>0 if <paramref name="value"/> is false, 1 if <paramref name="value"/> is true.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static unsafe long UnsafeBooleanToInt64(bool value) => *(byte*)&value;
}
