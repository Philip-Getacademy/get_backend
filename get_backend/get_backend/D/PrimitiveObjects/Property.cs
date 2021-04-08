
/*
 * Property is used to store bool related data
 */

using get_backend.D.AbstractObjects;

namespace get_backend.D.PrimitiveObjects
{
    internal sealed class Property : AMuteable<bool>
    {
        internal bool Value { get; private set; }

        internal Property() { }
        internal Property(bool value) => Value = value;

        internal override bool Clone => Value;
        internal override void Change(bool value) => Value = !Value;
    }
}
