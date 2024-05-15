using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Object
{
    public class Password : ValueObject
    {
        const int MAX_PASS_LENGTH = 10;
        const int MIN_PASS_LENGTH = 4;

        public Password() { }

        public Password(string value)
        {
            if (value.Length > MAX_PASS_LENGTH) throw new ArgumentException($"password is longer ({value.Length}) than max length value ({MAX_PASS_LENGTH})");
            if (value.Length < MIN_PASS_LENGTH) throw new ArgumentException($"password is shorter ({value.Length}) than min length value ({MIN_PASS_LENGTH})");

            Value = value;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
