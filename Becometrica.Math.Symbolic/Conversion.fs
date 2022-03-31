module private Becometrica.Math.Symbolic.Conversion

open System
open Becometrica

let decimalToMantissaAndScale value =
        let parts = Decimal.GetBits value
        let sign = (parts.[3] &&& 0x80000000) <> 0
        let scale = (parts.[3] >>> 16) &&& 0x7F
        let mutable mantissa = bigint (uint parts.[0])
        if parts.[1] <> 0 then
            mantissa <- mantissa + ((bigint (uint parts.[1])) <<< 32)
        if parts.[2] <> 0 then
            mantissa <- mantissa + ((bigint (uint parts.[2])) <<< 64)
        if sign then
            mantissa <- -mantissa
        if mantissa.IsZero then
            struct (bigint.Zero, 0)
        else
            struct (mantissa, scale)

module Grizu2 =
    let cachedPowersMantissa = [|
        0xfa8fd5a0081c0288uL; 0xbaaee17fa23ebf76uL; 0x8b16fb203055ac76uL; 0xcf42894a5dce35eauL; 0x9a6bb0aa55653b2duL
        0xe61acf033d1a45dfuL; 0xab70fe17c79ac6cauL; 0xff77b1fcbebcdc4fuL; 0xbe5691ef416bd60cuL; 0x8dd01fad907ffc3cuL
        0xd3515c2831559a83uL; 0x9d71ac8fada6c9b5uL; 0xea9c227723ee8bcbuL; 0xaecc49914078536duL; 0x823c12795db6ce57uL
        0xc21094364dfb5637uL; 0x9096ea6f3848984fuL; 0xd77485cb25823ac7uL; 0xa086cfcd97bf97f4uL; 0xef340a98172aace5uL
        0xb23867fb2a35b28euL; 0x84c8d4dfd2c63f3buL; 0xc5dd44271ad3cdbauL; 0x936b9fcebb25c996uL; 0xdbac6c247d62a584uL
        0xa3ab66580d5fdaf6uL; 0xf3e2f893dec3f126uL; 0xb5b5ada8aaff80b8uL; 0x87625f056c7c4a8buL; 0xc9bcff6034c13053uL
        0x964e858c91ba2655uL; 0xdff9772470297ebduL; 0xa6dfbd9fb8e5b88fuL; 0xf8a95fcf88747d94uL; 0xb94470938fa89bcfuL
        0x8a08f0f8bf0f156buL; 0xcdb02555653131b6uL; 0x993fe2c6d07b7facuL; 0xe45c10c42a2b3b06uL; 0xaa242499697392d3uL
        0xfd87b5f28300ca0euL; 0xbce5086492111aebuL; 0x8cbccc096f5088ccuL; 0xd1b71758e219652cuL; 0x9c40000000000000uL
        0xe8d4a51000000000uL; 0xad78ebc5ac620000uL; 0x813f3978f8940984uL; 0xc097ce7bc90715b3uL; 0x8f7e32ce7bea5c70uL
        0xd5d238a4abe98068uL; 0x9f4f2726179a2245uL; 0xed63a231d4c4fb27uL; 0xb0de65388cc8ada8uL; 0x83c7088e1aab65dbuL
        0xc45d1df942711d9auL; 0x924d692ca61be758uL; 0xda01ee641a708deauL; 0xa26da3999aef774auL; 0xf209787bb47d6b85uL
        0xb454e4a179dd1877uL; 0x865b86925b9bc5c2uL; 0xc83553c5c8965d3duL; 0x952ab45cfa97a0b3uL; 0xde469fbd99a05fe3uL
        0xa59bc234db398c25uL; 0xf6c69a72a3989f5cuL; 0xb7dcbf5354e9beceuL; 0x88fcf317f22241e2uL; 0xcc20ce9bd35c78a5uL
        0x98165af37b2153dfuL; 0xe2a0b5dc971f303auL; 0xa8d9d1535ce3b396uL; 0xfb9b7cd9a4a7443cuL; 0xbb764c4ca7a44410uL
        0x8bab8eefb6409c1auL; 0xd01fef10a657842cuL; 0x9b10a4e5e9913129uL; 0xe7109bfba19c0c9duL; 0xac2820d9623bf429uL
        0x80444b5e7aa7cf85uL; 0xbf21e44003acdd2duL; 0x8e679c2f5e44ff8fuL; 0xd433179d9c8cb841uL; 0x9e19db92b4e31ba9uL
        0xeb96bf6ebadf77d9uL; 0xaf87023b9bf0ee6buL |]

    let cachedPowersExponent = [|
        -1220s; -1193s; -1166s; -1140s; -1113s; -1087s; -1060s; -1034s; -1007s; -980s; -954s; -927s; -901s; -874s
        -847s; -821s; -794s; -768s; -741s; -715s; -688s; -661s; -635s; -608s; -582s; -555s; -529s; -502s; -475s; -449s
        -422s; -396s; -369s; -343s; -316s; -289s; -263s; -236s; -210s; -183s; -157s; -130s; -103s; -77s; -50s; -24s
        3s; 30s; 56s; 83s; 109s; 136s; 162s; 189s; 216s; 242s; 269s; 295s; 322s; 348s; 375s; 402s; 428s; 455s; 481s
        508s; 534s; 561s; 588s; 614s; 641s; 667s; 694s; 720s; 747s; 774s; 800s; 827s; 853s; 880s; 907s; 933s; 960s
        986s; 1013s; 1039s; 1066s
    |]

    let powersOf10 = [|
        1uL; 10uL; 100uL; 1000uL; 10000uL; 100000uL; 1000000uL; 10000000uL; 100000000uL; 1000000000uL; 10000000000uL
        100000000000uL; 1000000000000uL; 10000000000000uL; 100000000000000uL; 1000000000000000uL; 10000000000000000uL
        100000000000000000uL; 1000000000000000000uL; 10000000000000000000uL
    |]

    [<Literal>]
    let uint32Max = 0xFFFFFFFFuL

    let multiply left right =
        let leftHigh = left >>> 32;
        let leftLow = left &&& uint32Max;
        let rightHigh = right >>> 32;
        let rightLow = right &&& uint32Max;

        let high = leftHigh * rightHigh;
        let middle1 = leftLow * rightHigh;
        let middle2 = leftHigh * rightLow;
        let low = leftLow * rightLow;

        let tmp = (low >>> 32) + (middle2 &&& uint32Max) + (middle1 &&& uint32Max) + (1uL <<< 31);
        high + (middle2 >>> 32) + (middle1 >>> 32) + (tmp >>> 32);

    [<Literal>]
    let diySignificandSize = 64

    [<Literal>]
    let significandSize = 52

    [<Literal>]
    let exponentBias = 1075 // 0x3FF + significandSize

    [<Literal>]
    let minExponent = -1075 // -exponentBias

    [<Literal>]
    let exponentMask = 0x7FF0000000000000uL

    [<Literal>]
    let significandMask = 0x000FFFFFFFFFFFFFuL

    [<Literal>]
    let hiddenBit = 0x0010000000000000uL

    let grizu2 value =
        let u = value |> BitConverter.DoubleToInt64Bits |> uint64
        let biasedExponent = int ((u &&& exponentMask) >>> significandSize)
        let significand = u &&& significandMask
        let vMantissa, vExponent =
            if biasedExponent <> 0 then
                significand + hiddenBit, biasedExponent - exponentBias
            else
                significand, minExponent + 1

        // NormalizedBoundaries
        let mutable plusMantissa = (vMantissa <<< 1) + 1uL
        let mutable plusExponent = vExponent - 1

        // NormalizeBoundary
        while 0uL = (plusMantissa &&& (hiddenBit <<< 1)) do
            plusMantissa <- plusMantissa <<< 1
            plusExponent <- plusExponent - 1

        plusMantissa <- plusMantissa <<< (diySignificandSize - significandSize - 2)
        plusExponent <- plusExponent - (diySignificandSize - significandSize - 2)

        let minusMantissa =
            if vMantissa = hiddenBit then
                ((vMantissa <<< 2) - 1uL) <<< (vExponent - 2 - plusExponent)
            else
                ((vMantissa <<< 1) - 1uL) <<< (vExponent - 1 - plusExponent)

        // Normalized v
        let mutable resMantissa = vMantissa
        let mutable resExponent = vExponent
        while 0uL = (resMantissa &&& hiddenBit) do
            resMantissa <- resMantissa <<< 1
            resExponent <- resExponent - 1

        resMantissa <- resMantissa <<< (diySignificandSize - significandSize - 1)
        resExponent <- resExponent - (diySignificandSize - significandSize - 1)

        // GetCachedPower
        let dk = (float (-61 - plusExponent)) * 0.30102999566398114 + 347.0 // dk must be positive, so can do ceiling in positive
        let mutable k1 = int dk
        if (float k1) < dk then
            k1 <- k1 + 1

        let index = (k1 >>> 3) + 1
        let cmkMantissa = cachedPowersMantissa.[index]
        let cmkExponentPlus64 = (int cachedPowersExponent.[index]) + 64

        // continuation
        let wMantissa = multiply resMantissa cmkMantissa
        let mutable wpMantissa = multiply plusMantissa cmkMantissa
        let wpExponentNegative = -(plusExponent + cmkExponentPlus64)
        let mutable wmMantissa = multiply minusMantissa cmkMantissa
        wmMantissa <- wmMantissa + 1uL
        wpMantissa <- wpMantissa - 1uL

        // assertions
        assert (plusExponent = resExponent)
        assert (wpMantissa >= wMantissa)

        let mutable delta = wpMantissa - wmMantissa

        // DigitGen
        let oneMantissa = 1uL <<< wpExponentNegative

        // wpW = wp - w
        let mutable wpWMantissa = wpMantissa - wMantissa

        let mutable p1 = uint (wpMantissa >>> wpExponentNegative)
        let mutable p2 = wpMantissa &&& (oneMantissa - 1uL)
        let mutable kappa = (p1 |> float |> Math.Log10 |> int) + 1

        let mutable result = 0uL
        let mutable exponent = -(-348 + (index <<< 3)) // decimal exponent no need lookup table
        let mutable continueLoop = true
        while continueLoop && kappa > 0 do
            let powerOf10 = uint powersOf10.[kappa - 1]
            let d = p1 / powerOf10
            p1 <- p1 % powerOf10
            if d <> 0u || result <> 0uL then
                result <- result * 10uL + (uint64 d)

            kappa <- kappa - 1
            let mutable tmp = ((uint64 p1) <<< wpExponentNegative) + p2
            if tmp <= delta then
                exponent <- exponent + kappa
                let tenKappa = powersOf10.[kappa] <<< wpExponentNegative

                // GrisuRound
                while (tmp < wpWMantissa && delta - tmp >= tenKappa
                    && (tmp + tenKappa < wpWMantissa || wpWMantissa - tmp > tmp + tenKappa - wpWMantissa)) do
                    result <- result - 1uL
                    tmp <- tmp + tenKappa

                continueLoop <- false

        if continueLoop then
            // kappa = 0
            p2 <- p2 * 10uL
            delta <- delta * 10uL
            let d = p2 >>> wpExponentNegative
            if d <> 0uL || result <> 0uL then
                result <- result * 10uL + d
            p2 <- p2 &&& (oneMantissa - 1uL)
            kappa <- kappa - 1
            while p2 >= delta do
                p2 <- p2 * 10uL
                delta <- delta * 10uL
                let d = p2 >>> wpExponentNegative
                if d <> 0uL || result <> 0uL then
                    result <- result * 10uL + d
                p2 <- p2 &&& (oneMantissa - 1uL)
                kappa <- kappa - 1

            exponent <- exponent + kappa
            wpWMantissa <- wpWMantissa * powersOf10.[-kappa]

            // GrisuRound
            while (p2 < wpWMantissa && delta - p2 >= oneMantissa
                && (p2 + oneMantissa < wpWMantissa || wpWMantissa - p2 > p2 + oneMantissa - wpWMantissa)) do
                result <- result - 1uL
                p2 <- p2 + oneMantissa

        struct (result, exponent)
