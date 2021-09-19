using CoreDomain.Tests.Models;
using System;
using System.Linq;

namespace CoreDomain.Tests.Common
{
    public static class Generator
    {
        public static int GetRandomInt()
        {
            return new Random().Next();
        }

        public static long GetRandomLong()
        {
            return new Random().Next() * new Random().Next();
        }

        public static string GetRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static Guid GetRandomGuid()
        {
            return Guid.NewGuid();
        }

        public static MyCustomAggregate<T> GetAggregateInstace<T>()
        {
            MyCustomValueObject customValueObject = new MyCustomValueObject(GetRandomInt(), GetRandomString(10));
            MyCustomEntity<T> customEntity = new MyCustomEntity<T>();
            MyCustomAggregate<T> customAggregate = new MyCustomAggregate<T>(customEntity, customValueObject);

            return customAggregate;
        }
    }

    public static class Generator<T>
    {
        static readonly Type type = typeof(T);

        public static MyCustomEntity<T> GetCustomEntityInstance(params object[] args)
        {
            if (type.Equals(typeof(int))
                || type.Equals(typeof(long))
                || type.Equals(typeof(string))
                || type.Equals(typeof(Guid)))
                return (MyCustomEntity<T>)Activator.CreateInstance(typeof(MyCustomEntity<T>), args);

            throw new InvalidCastException($"Type {typeof(T).Name} is not supported");
        }
    }
}
