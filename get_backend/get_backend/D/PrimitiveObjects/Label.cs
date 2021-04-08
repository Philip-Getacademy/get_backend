
/*
 * Label is used to store string related data
 */

using System.Text.RegularExpressions;
using get_backend.D.AbstractObjects;

namespace get_backend.D.PrimitiveObjects
{
    internal sealed class Label : AMuteable<string>
    {
        internal string Value { get; private set; }

        internal Label() => Value = string.Empty;
        internal Label(string name) => Value = TrimWhiteSpace(name);
        internal Label(Label l) : this(l.Value) { }

        internal override string Clone => Value;
        internal override void Change(string value) => Value = value;

        private static string TrimWhiteSpace(string name)
            => Regex.Replace(name, @"\s+", " ");
    }
}
