namespace Scratchpad
{
    public static class Records
    {
        public static void TestSet()
        {
            var testRecord1 = new TestRecord(1, "Tom Riddle");
            var testRecord2a = new TestRecord2("Asus UX425", 1000, "USD");
            var testRecord2b = new TestRecord2("Asus UX425", 1000, "USD");
            var testRecord3 = new TestRecord3("Asus UX425", 1000, "USD");
            var testRecordStruct = new TestRecordStruct("Asus UX425", 1000, "USD");
            var testRecordStruct2 = new TestRecordStruct("Asus UX425", 1000, "USD");

            testRecord1.Id = 1111;
            testRecord1.Name = "Zmienione! Zwykle pole!";

            Console.WriteLine($"testRecord1: {testRecord1}");
            Console.WriteLine($"testRecord2a: {testRecord2a}");
            Console.WriteLine($"testRecord2b: {testRecord2b}");
            Console.WriteLine($"testRecord3: {testRecord3}");
            Console.WriteLine($"testRecordStruct: {testRecordStruct}");
            Console.WriteLine($"testRecordStruct2: {testRecordStruct2}");
            //Console.WriteLine($".2 and .3 AreEqual?: {testRecord2 == testRecord3}");                  //not possible. Different types.
            Console.WriteLine($"testRecord2a and testRecord2b are equal?: {testRecord2a == testRecord2b}");
            Console.WriteLine($"testRecord2a and testRecord2b are the same object(references)?: {object.ReferenceEquals(testRecord2a, testRecord2b)}");
            Console.WriteLine($"testRecordStruct and testRecordStruct2 are equal?: {testRecordStruct == testRecordStruct2}");
            Console.WriteLine($"testRecordStruct and testRecordStruct2 are the same object(references)?: {object.ReferenceEquals(testRecordStruct, testRecordStruct2)}");       //not possible - value types - will be always false
            Console.WriteLine("\n\n");

            //testRecord2a.Cost = 15;                       //not possible - init
            testRecordStruct.Cost = 850;
            testRecordStruct.Name = "Zmienione! record struct ma seta zamiast inita";
            testRecordStruct.Currency = "CHF";

            Console.WriteLine(testRecordStruct + "\n\n");

            var (name, price, currency) = testRecord3;
            testRecordStruct2.Cost = 900;
            testRecordStruct2.Currency = "GPB";
            var (name2, price2, currency2) = testRecordStruct2;
            Console.WriteLine($"name = {name}; price = {price}; currency = {currency}.");
            Console.WriteLine($"name2 = {name2}; price2 = {price2}; currency2 = {currency2}.");
            (name, price, currency) = testRecordStruct2;
            Console.WriteLine($"Changed: name = {name}; price = {price}; currency = {currency}.\n\n");

            var klonStruct = testRecordStruct2 with { Name = "Clone" };
            var klonClass = testRecord3 with { Name = "Clone" };
            Console.WriteLine($"Klon structa: {klonStruct}");
            Console.WriteLine($"Klon classy:  {klonClass}");

            Console.WriteLine("\nTheEnd\n");
        }
    }

    public record TestRecord
    {
        public int Id { get; set; }
        private string _realName;
        public string Name;
        public TestRecord(int id, string realName)
        {
            Id = id;
            _realName = realName;
            Name = "Lord Voldemort";
        }
    }

    public record TestRecord2(string Name, float Cost, string Currency);

    public record TestRecord3(string Name, float Cost, string Currency);
    public record struct TestRecordStruct(string Name, float Cost, string Currency);

    //public record struct TestRecordStructInheritance : TestRecordStruct                 //not possible - cannot inherit from struct
    public record struct TestRecordStructInheritance : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    public record class TestRecordInheritance(string SomeValue, string Name, float Cost, string Currency) : TestRecord3(Name, Cost, Currency), IComparable
    {
        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }
    }

    public class TestujemyInitAccessor
    {
        public string Name { get; init; }
        public string Description { get; }

        public TestujemyInitAccessor(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Metoda(string a, string b)
        {
            //Name = a;                     //not possible
            //Description = b;              //not possible
        }

        public class DrugiTest : TestujemyInitAccessor
        {
            public DrugiTest(string name, string description) : base(name, description)
            {
                base.Name = name;
                //base.Description = description;           //not possible
            }
        }
    }
}