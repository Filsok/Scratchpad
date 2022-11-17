using System.Globalization;

namespace DotNet7.NewFeatures;

public class StringsImprovement
{
    public static void TestSet()
    {
        string filename1 = "c:\\docume\"nts\\" +
            "files\\filename.txt";
        string filename2 = @"c:\docume""nts\
                            files\filename.txt";
        string filename3 = """
                            c:\docume"nts\
                            files\
                            filename.txt
                            """;

        Console.WriteLine(filename1);
        Console.WriteLine(filename2);
        Console.WriteLine(filename3);

        var jsonString = """
            {
            "name": "FirstName",
            "label": "First Name",
            "type": "Text",
            "required": true
            }
            """;

        Console.WriteLine($"\njsonString = \n{jsonString}");

        var threeQuotationMarks = """"
            sometextwith"""3quotationmarks
            """";                                           //in that case use 4 quotation marks at the begin and the end.

        var life = "COOL";
        var placeholderCase = $$"""
            Life is {{life}}
            {
            "name": "FirstName",
            "label": "First Name",
            "type": "Text",
            "required": true
            }
            """;
        Console.WriteLine($"\n\n{placeholderCase}");
    }
}

//String Literals """"