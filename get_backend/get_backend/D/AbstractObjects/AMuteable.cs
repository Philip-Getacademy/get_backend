using System;
using System.Collections.Generic;
using System.Text;

namespace get_backend.D.AbstractObjects
{
    /// <summary> AMuteable also needs a ctor with a T input
    /// </summary>
    internal abstract class AMuteable<T>
    {
        internal abstract T Clone { get; }
        internal abstract void Change(T a);
    }
}
