using Shouldly;

namespace Cs14ExtensionMembersDisambiguation.Before;

public static class FirstExtensions
{
    public static string Prefix(this string receiver)
    {
        return $"First: {receiver}";
    }

    public static TResult Choose<TResult, TItem>(
        this IEnumerable<TItem> receiver,
        TResult first,
        TResult second
    )
    {
        return first;
    }
}

public static class SecondExtensions
{
    public static string Prefix(this string receiver)
    {
        return $"Second: {receiver}";
    }

    public static TResult Choose<TResult, TItem>(
        this IEnumerable<TItem> receiver,
        TResult first,
        TResult second
    )
    {
        return second;
    }
}

public class BeforeCs14Tests
{
    [Test]
    public void InvokesFirst()
    {
        FirstExtensions.Prefix("foo").ShouldBe("First: foo");
    }

    [Test]
    public void InvokesSecond()
    {
        SecondExtensions.Prefix("foo").ShouldBe("Second: foo");
    }

    [Test]
    public void InvokesFirstGeneric()
    {
        FirstExtensions
            .Choose<string, int>(Enumerable.Range(1, 5), "First", "Second")
            .ShouldBe("First");
    }

    [Test]
    public void InvokesSecondGeneric()
    {
        SecondExtensions
            .Choose<string, int>(Enumerable.Range(1, 5), "First", "Second")
            .ShouldBe("Second");
    }
}
