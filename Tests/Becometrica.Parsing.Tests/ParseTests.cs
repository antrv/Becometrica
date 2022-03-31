using System.Globalization;
using FluentAssertions;
using Xunit;

namespace Becometrica.Parsing.Tests;

public class ParseTests
{
    [Fact]
    public void Char_Success()
    {
        // arrange
        const char c = 'a';

        // act & assert
        ParseSuccessCheck("a", Parse.Char(c)).Should().Be(c);
    }

    [Fact]
    public void Char_Failure()
    {
        // act & assert
        ParseFailureCheck("b", Parse.Char('a'));
    }

    [Fact]
    public void Ident_Success()
    {
        // arrange
        const string str = "Iden123_tifier_01";

        // act & assert
        ParseSuccessCheck(str, Parse.Ident).Should().Be(str);
    }

    [Fact]
    public void Ident_Failure()
    {
        // act & assert
        ParseFailureCheck("12345", Parse.Ident);
    }

    [Fact]
    public void Int32_Success()
    {
        // act & assert
        ParseSuccessCheck("0", Parse.Int32).Should().Be(0);
        ParseSuccessCheck("-0", Parse.Int32).Should().Be(0);
        ParseSuccessCheck("+0", Parse.Int32).Should().Be(0);
        ParseSuccessCheck("+1", Parse.Int32).Should().Be(1);
        ParseSuccessCheck("-98756", Parse.Int32).Should().Be(-98756);
        ParseSuccessCheck("123456789", Parse.Int32).Should().Be(123456789);
        ParseSuccessCheck("000000000001", Parse.Int32).Should().Be(1);
        ParseSuccessCheck(int.MinValue.ToString(CultureInfo.InvariantCulture), Parse.Int32).Should().Be(int.MinValue);
        ParseSuccessCheck(int.MaxValue.ToString(CultureInfo.InvariantCulture), Parse.Int32).Should().Be(int.MaxValue);
    }

    [Fact]
    public void Int32_Failure()
    {
        // act & assert
        ParseFailureCheck("a", Parse.Int32);
        ParseFailureCheck("-9999999999", Parse.Int32);
        ParseFailureCheck("9999999999", Parse.Int32);
        ParseFailureCheck((int.MinValue - 1L).ToString(CultureInfo.InvariantCulture), Parse.Int32);
        ParseFailureCheck((int.MaxValue + 1L).ToString(CultureInfo.InvariantCulture), Parse.Int32);
    }

    [Fact]
    public void Double_Success()
    {
        // act & assert
        ParseSuccessCheck("1.23", Parse.Double).Should().Be(1.23);
        ParseSuccessCheck("-1.23e-5", Parse.Double).Should().Be(-1.23e-5);
        ParseSuccessCheck("+1.23e+5", Parse.Double).Should().Be(1.23e5);
    }

    [Fact]
    public void Double_Failure()
    {
        // act & assert
        ParseFailureCheck("abcde", Parse.Double);
    }

    private static TResult ParseSuccessCheck<TResult>(string input, Parser<char, TResult> parser)
    {
        ParserInput<char> parserInput = ParserInput.FromString(input);
        ParsingResult<char, TResult> result = parser(parserInput);
        result.Success.Should().BeTrue();
        result.Input.Position.Should().Be(input.Length);
        return result.Value;
    }


    private static void ParseFailureCheck<TResult>(string input, Parser<char, TResult> parser)
    {
        ParserInput<char> parserInput = ParserInput.FromString(input);
        ParsingResult<char, TResult> result = parser(parserInput);
        result.Success.Should().BeFalse();
        result.Input.Position.Should().Be(0);
    }
}
