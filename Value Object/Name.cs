using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Object
{
    public class Name : ValueObject
    {
        const int MAX_NAME_LENGTH = 10;
        const int MIN_NAME_LENGTH = 2;

        public Name() { }

        public Name (string value)
        {
            if (value.Length > MAX_NAME_LENGTH) throw new ArgumentException($"name is longer ({value.Length}) than max length value ({MAX_NAME_LENGTH})");
            if (value.Length < MIN_NAME_LENGTH) throw new ArgumentException($"name is shorter ({value.Length}) than min length value ({MIN_NAME_LENGTH})");

            Value = value;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
