using System;
using System.Collections.Generic;

namespace CoreDomain.Tests.Models
{
    public class MyCustomValueObject : ValueObject
    {
        public MyCustomValueObject(int foo, string bar)
        {
            Foo = foo;
            Bar = bar ?? throw new ArgumentNullException(nameof(bar));
        }

        public int Foo { get; set; }

        public string Bar { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Foo;
            yield return Bar;
        }
    }
}
