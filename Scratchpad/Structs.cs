namespace Scratchpad
{
    public struct TestStruct
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public void Metoda(string message)
        {
            Console.WriteLine($"Metoda() called with argument {message}");
        }

        public TestStruct(string name, string value)
        {
            Name = name;
            Value = value;
            _drugiStruct = new TestStruct2("dummy", 5);
            Metoda("Constructor");
        }

        //TestStruct rekurencja;
        private TestStruct2 _drugiStruct;
    }

    internal struct TestStruct2
    {
        public string Name { get; set; }
        private float _cost;

        public TestStruct2(string name, float cost)
        {
            Name = name;
            _cost = cost;
        }
    }
}