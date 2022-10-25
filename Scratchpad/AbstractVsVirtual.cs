using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Scratchpad
{
    public static class AbstractVsVirtual
    {
        public static void TestSet()
        {
        }

        public static void TestSetOverrideVsNew()
        {
            BaseClass someClass = new SomeClass();
            //SomeClass someClass = new SomeClass();
            someClass.FooVirtual();
            someClass.Foo();
        }
    }

    internal abstract class Pralka
    {
    }

    internal class BaseClass
    {
        public virtual void FooVirtual()
        {
            Console.WriteLine("FooVirtual() base");
        }

        public void Foo()
        {
            Console.WriteLine("Foo() base");
        }
    }

    internal class SomeClass : BaseClass
    {
        public override void FooVirtual()
        {
            Console.WriteLine("FooVirtual() SomeClass");
        }

        public new void Foo()
        {
            Console.WriteLine("Foo() SomeClass");
        }
    }
}