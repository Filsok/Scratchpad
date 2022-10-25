using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratchpad
{
    public static class AbstractVsInterface
    {
        public static void TestSet()
        {
            var implement = new ImplementInterface();
            var inherit = new InheritClass();

            implement.Run();
            implement.Fast = true;
            //implement.IsFastRun();              //not possible
            TakeMethod(implement);                  //kaboom?           //wow it works      //ok, C#8.0 - explained.

            IMyRunnable implement2 = new ImplementInterface();
            implement2.IsFastRun();
        }

        private static void TakeMethod(IMyRunnable runnable)
        {
            if (runnable.IsFastRun())                   //what will happened?
                Console.WriteLine("IsFastRun returns true!");       //why it works?         //ok, C#8.0 - explained.
        }
    }

    internal interface IMyRunnable
    {
        bool Fast { get; set; }
        public string Route { get; set; }

        //public float length;                    //not possible. Canno't use fields
        public void Run();

        public bool IsFastRun()                         //should be not possible. why compiler let me do this??         ////ok, C#8.0 - explained.
        {
            Console.WriteLine("Method body directly from interface MyRunnable IsFastRun()");
            if (Fast)
                return true;
            return false;
        }
    }

    internal abstract class Run
    {
        public bool Fast = true;
        protected float _length;
        internal string _route;
        public bool InNature { get; set; }

        public Run()
        {
            Fast = false;
            _length = 0;
            _route = "default";
        }

        protected abstract void GetClothes();

        private void Prepare()
        {
            Console.WriteLine("abstract class Run. Prepare()");
        }
    }

    internal class InheritClass : Run
    {
        protected override void GetClothes()
        {
            Console.WriteLine("InheritClass.GetClothes()");
        }
    }

    public class ImplementInterface : IMyRunnable
    {
        public bool Fast { get; set; }
        public string Route { get; set; }

        public void Run()
        {
            Console.WriteLine("ImplementInterface.Run()");
        }

        //public bool IsFastRun()
        //{
        //    Console.WriteLine("Override method IsFastRun()");
        //    return Fast;
        //}
    }
}