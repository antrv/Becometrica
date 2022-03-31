using System.Runtime.CompilerServices;
using Becometrica.Math.Interop;

namespace Becometrica.Math;

partial struct MpFloat
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpFloat value) => Mpir.mpf_set(ref (_f ??= new()).Value, value.F);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int value) => Mpir.mpf_set_si(ref (_f ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(uint value) => Mpir.mpf_set_ui(ref (_f ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(nint value) => Mpir.mpf_set_si(ref (_f ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(nuint value) => Mpir.mpf_set_ui(ref (_f ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(long value)
    {
        if (IntPtr.Size == 8)
            Mpir.mpf_set_si(ref (_f ??= new()).Value, (nint)value);
        else
        {
            Mpz z = default;
            Mpir.mpz_init_set_sx(ref z, value);
            try
            {
                Mpir.mpf_set_z(ref (_f ??= new()).Value, z);
            }
            finally
            {
                Mpir.mpz_clear(ref z);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(ulong value)
    {
        if (IntPtr.Size == 8)
            Mpir.mpf_set_ui(ref (_f ??= new()).Value, (nuint)value);
        else
        {
            Mpz z = default;
            Mpir.mpz_init_set_ux(ref z, value);
            try
            {
                Mpir.mpf_set_z(ref (_f ??= new()).Value, z);
            }
            finally
            {
                Mpir.mpz_clear(ref z);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(double value) => Mpir.mpf_set_d(ref (_f ??= new()).Value, value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpRational value) => Mpir.mpf_set_q(ref (_f ??= new()).Value, value.Q);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(MpInteger value) => Mpir.mpf_set_z(ref (_f ??= new()).Value, value.Z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(string value, int @base = 0)
    {
        if ((@base < -62 || @base > -2) && (@base < 2 || @base > 62))
            throw new ArgumentOutOfRangeException(nameof(@base));

        if (Mpir.mpf_set_str(ref (_f ??= new()).Value, value, @base) != 0)
            throw new FormatException();
    }
}
