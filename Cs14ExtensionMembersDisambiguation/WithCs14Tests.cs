using Shouldly;

namespace Cs14ExtensionMembersDisambiguation.After;

public static class FirstExtensions
{
    extension(string? receiver)
    {
        public string? Prefix()
        {
            return $"First: {receiver}";
        }

        public string WithPrefix
        {
            get => $"First: {receiver}";
        }

        public static string Create()
        {
            return "First";
        }

        public static string ExtensionId
        {
            get => "First";
        }

        public static string operator !(string? value)
        {
            return $"First: {value}";
        }
    }

    extension<TItem>(IEnumerable<TItem> receiver)
    {
        public TResult Choose<TResult>(TResult first, TResult second)
        {
            return first;
        }
    }
}

public static class SecondExtensions
{
    extension(string? receiver)
    {
        public string? Prefix()
        {
            return $"Second: {receiver}";
        }

        public string WithPrefix
        {
            get => $"Second: {receiver}";
        }

        public static string Create()
        {
            return "Second";
        }

        public static string ExtensionId
        {
            get => "Second";
        }

        public static string operator !(string? value)
        {
            return $"Second: {value}";
        }
    }

    extension<TItem>(IEnumerable<TItem> receiver)
    {
        public TResult Choose<TResult>(TResult first, TResult second)
        {
            return second;
        }
    }
}

public class WithCs14Tests
{
    [Test]
    public void InvokesFirstInstance()
    {
        FirstExtensions.Prefix("foo").ShouldBe("First: foo");
    }

    [Test]
    public void InvokesSecondInstance()
    {
        SecondExtensions.Prefix("foo").ShouldBe("Second: foo");
    }

    [Test]
    public void GetsFirstInstance()
    {
        FirstExtensions.get_WithPrefix("foo").ShouldBe("First: foo");
    }

    [Test]
    public void GetsSecondInstance()
    {
        SecondExtensions.get_WithPrefix("foo").ShouldBe("Second: foo");
    }

    [Test]
    public void InvokesFirstStatic()
    {
        FirstExtensions.Create().ShouldBe("First");
    }

    [Test]
    public void InvokesSecondStatic()
    {
        SecondExtensions.Create().ShouldBe("Second");
    }

    [Test]
    public void GetsFirstStatic()
    {
        FirstExtensions.get_ExtensionId().ShouldBe("First");
    }

    [Test]
    public void GetsSecondStatic()
    {
        SecondExtensions.get_ExtensionId().ShouldBe("Second");
    }

    [Test]
    public void InvokesFirstOperator()
    {
        FirstExtensions.op_LogicalNot("foo").ShouldBe("First: foo");
    }

    [Test]
    public void InvokesSecondOperator()
    {
        SecondExtensions.op_LogicalNot("foo").ShouldBe("Second: foo");
    }

    [Test]
    public void InvokesFirstGeneric()
    {
        FirstExtensions.Choose<int, string>(Enumerable.Range(1, 5), "First", "Second").ShouldBe("First");
    }

    [Test]
    public void InvokesSecondGeneric()
    {
        SecondExtensions.Choose<int, string>(Enumerable.Range(1, 5), "First", "Second").ShouldBe("Second");
    }
}
