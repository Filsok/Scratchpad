using System.Runtime.InteropServices;

namespace Scratchpad.DotNet6News; //file scoped namespaces. instead of {} can be used only ";" after namespace name.

public static class DotNet6News
{
    public static void TestSet()
    {
        Console.WriteLine("DotNet6News.TestSet() started.");
        InterpolatedConstStrings();
        StructuresImprovement();
        RecordsImprovement();
        AnonymousTypesImprovement();
        ExtendedPropertyPatterns();
        LambdaImprovement();
        DeconstructorsImprovement();
    }

    private static void DeconstructorsImprovement()
    {
        var point = new Point(1, 5);
        int a = 0;
        (a, int b) = point;
    }

    internal record Point(int x, int y);

    private static void LambdaImprovement()
    {
        Func<string, int> parseOld = (s) => int.Parse(s);       //C#9
        var parse = (string s) => int.Parse(s);                 //C#10

        var read = Console.Read();                      //Just one overload; (Func<int> inferred)
        //var write = Console.WriteLine();              //ERROR: more than one overloads.
        //Action<string> write2 = Console.WriteLine;

        var result = object (bool b) => b ? 1 : "0";        //lambda return types

        var someLambda = [Obsolete] (string s) => parse(s);     //lambda attributes
    }

    private static void ExtendedPropertyPatterns()
    {
        Console.WriteLine("ExtendedPropertyPatterns() start...");

        var person = new Person()
        {
            Name = "JohnSmith",
            Address = new Address()
            {
                Street = "Pileckiego",
                City = "Radom",
                HouseNumber = 10
            }
        };

        var locationInfo = person switch
        {
            //{ Address: { City: "Radom" } } and { Address: { HouseNumber: < 10 } } => "Radom below 10",            //old way - nesting necessary
            //{ Address: { City: "Radom" } } and { Address: { HouseNumber: >= 10 } } => "Radom atleast 10",
            //_ => "no info"
            { Address.City: "Radom" } and { Address.HouseNumber: < 10 } => "Radom below 10",                        //new way
            { Address.City: "Radom" } and { Address.HouseNumber: >= 10 } => "Radom atleast 10",
            _ => "no info"
        };

        Console.WriteLine(locationInfo.ToString());
    }

    private static void AnonymousTypesImprovement()
    {
        var someValue = new
        {
            Value = 10,
            Name = "Test"
        };
        Console.WriteLine(someValue);

        var someValue2 = someValue with { Value = 20 };     //copying anonymous types with keyword with
        Console.WriteLine(someValue2);
    }

    private static void RecordsImprovement()
    {
        var someValue = new DerivedRecord("a", "b");
        Console.WriteLine(someValue);
    }

    public static void InterpolatedConstStrings()
    {
        Console.WriteLine("InterpolatedConstStrings() started");
        const string basePath = "basePath/";

        const string path1 = $"{basePath}path1";
        const string path2 = $"{basePath}path2";

        Console.WriteLine(path1);
        Console.WriteLine(path2);
    }

    public static void StructuresImprovement()
    {
        var money = new Money() { Value = 10, Currency = "USD" };

        var money2 = money with { Value = 20 };                 //clone structures with keyword "with" - new feature
        Console.WriteLine($"money2: Value={money2.Value}, Currency={money2.Currency}");
    }
}

public struct Money
{
    public Money()              //ctor() in structures - new feature
    {
        Currency = "";
        Value = 0;
    }

    public string Currency { get; set; }
    public decimal Value { get; set; }
}

public record struct Wallet(string Currency, decimal Value);        //record struct - new feature

public record class BaseRecord(string BaseValue)       //implicit class/struct
{
    public sealed override string ToString()            //sealed override ToString() - new feature in records
    {
        return "Base ToString() implementation";
    }
}

public record class DerivedRecord(string Value, string BaseValue) : BaseRecord(BaseValue);

internal class Person
{
    public string Name { get; set; }
    public Address Address { get; set; }
}

internal class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public int HouseNumber { get; set; }
}

//New features in .NET6 and C#10:
//File scoped namespaces
//Global usings       - 2 methods. File with usings "global using ..." or tag in .csproj
//implicit usings - tag ImplicitUsings>enable</ImplicitUsings> - generate file with global usings
//interpolated const string
//structures improvement - ctor without parameters; copying with keyword with
//records improvement - record for structs; sealed override for ToString()
//anonymous types improvement - copying anonymous types with keyword with
//Property patterns improvement
//lambda improvement
//deconstruction improvement