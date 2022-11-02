using System.Collections.Specialized;
using System.Linq.Expressions;

namespace Scratchpad
{
    public class GenericTypes
    {
        public static void TestSet()
        {
            var restaurants = new List<Restaurant>();
            var result = new PaginetedResults<Restaurant, int>();
            result.Results = restaurants;

            var stringRepository = new Repository<string>();
            stringRepository.AddElement("some value");
            var firstElement = stringRepository.GetElement(0);
            Console.WriteLine($"first element: {firstElement}");

            var userRepository = new Repository<string, User>();
            userRepository.AddElement("Bill", new User() { Name = "Bill Smith" });
            var userName = userRepository.GetElement("Bill");
            Console.WriteLine($"Bill name: {userName}");
        }
    }

    public class PaginetedResults<T, R>
        where T : class
        where R : struct
    {
        public List<T> Results { get; set; }
        public int ResultsFrom { get; set; }
        public int ResultsTo { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
        public List<R> Rs { get; set; }
    }

    public class Restaurant
    { }

    public class User
    {
        public string Name { get; set; }
    }

    public class Repository<T>
        where T : ICloneable, IComparable
    {
        private List<T> data = new List<T>();

        public void AddElement(T element)
        {
            if (element != null)
                data.Add(element);
        }

        public T GetElement(int index)
        {
            if (index < data.Count)
                return data[index];
            else
            {
                //throw new IndexOutOfRangeException();
                //return default(T);
                return default;                         //implicit the same as return default(T);
            }
        }
    }

    public class Repository<TKey, TValue>
    {
        private Dictionary<TKey, TValue> data = new Dictionary<TKey, TValue>();

        public void AddElement(TKey key, TValue value)
        {
            if (value != null)
                data.Add(key, value);
        }

        public TValue GetElement(TKey key)
        {
            if (data.TryGetValue(key, out TValue result))
                return result;
            else
            {
                //throw new IndexOutOfRangeException();
                //return default(T);
                return default;                         //implicit the same as return default(T);
            }
        }
    }
}