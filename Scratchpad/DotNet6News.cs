namespace Scratchpad.DotNet6News; //file scoped namespaces. instead of {} can be used only ";" after namespace name.

public static class DotNet6News
{
    public static void TestSet()
    {
        Console.WriteLine("DotNet6News.TestSet() started.");
        InterpolatedConstStrings();
        StructuresImprovement();
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
        var money = new Money() { }
    }
}

public struct Money
{
    public Money()
    {
        Currency = "";
        Value = 0;
    }

    public string Currency { get; set; }
    public decimal Value { get; set; }
}

//New features in .NET6 and C#10:
//File scoped namespaces
//Global usings       - 2 methods. File with usings "global using ..." or tag in .csproj
//implicit usings - tag ImplicitUsings>enable</ImplicitUsings> - generate file with global usings
//interpolated const string
//structures improvement - ctor without parameters
//records improvement
//anonymous types improvement
//Property patterns improvement
//lambda improvement
//deconstruction improvement