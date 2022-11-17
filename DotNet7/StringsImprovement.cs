using System.Globalization;
using System.Text;

namespace DotNet7.NewFeatures;

public class StringsImprovement
{
    public static void TestSet()
    {
        StringLiterals();
        StringMultilineInterpolation();
        StringUTF8();
    }

    private static void StringUTF8()
    {
        var someString = "blabla";
        var oldEncoding = Encoding.UTF8.GetBytes("some string");
        var newEncoding = "some string"u8.ToArray();

        //var wrong = (someString)u8;                 //not supported
    }

    private static void StringMultilineInterpolation()
    {
        var rating = 2.9;
        var message = $"This course has rating of {rating}, which means it {rating switch
        {
            < 3 => "sucks",
            _ => "not bad"
        }}";

        Console.WriteLine(message);
    }

    private static void StringLiterals()
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

//String Literals """
//Multiline string interpolation
//UTF8 encoding