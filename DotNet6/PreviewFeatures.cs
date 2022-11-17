namespace DotNet6;

public class PreviewFeatures
{
    public static void TestSet()
    {
    }
}

//public interface IExample<T> where T : IExample<T>
//{
//    static abstract void M();
//    static abstract T P { get; set; }
//    static abstract event Action E;
//    static abstract T operator +(T l, T r);
//}

//public class TypeAttribute : Attribute                    //old way
//{
//    public TypeAttribute(Type t) => ParamType = t;
//    public Type ParamType { get; }
//}

//public class GenericAttribute<T> : Attribute where T : class      //C#10 preview
//{
//}

//static abstract in interfaces
//generic attributes