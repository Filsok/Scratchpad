using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratchpad
{
    public class OtherTopics
    {
        public static void TestSet()
        {
            UsingStatement();
        }

        private static void UsingStatement()
        {
            //using (var readFileStream = new FileStream("abc", FileMode.Open))
            //{
            //    readFileStream.Position = 0;
            //}

            using (var useClass = new UsedClass())
            {
                useClass.Say("Hi");
            }
        }
    }

    internal class UsedClass : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("UsedClass.Dispose()");
        }

        public void Say(string say)
        {
            Console.WriteLine($"UsedClass says {say}");
        }
    }
}

//using{} statement - the same as try{} finally{o.Dispose()}
//can be used only for objects IDisposable