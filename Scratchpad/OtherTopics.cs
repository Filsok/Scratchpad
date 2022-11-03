using System;
using System.Collections.Generic;
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
            using (var readFileStream = new FileStream("abc", FileMode.Open))
            {
                readFileStream.Position = 0;
            }
        }
    }
}

//using{} statement - the same as try{} finally{o.Dispose()}