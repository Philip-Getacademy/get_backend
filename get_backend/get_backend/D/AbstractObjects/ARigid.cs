using System;
using System.Collections.Generic;
using System.Text;

namespace get_backend.D.AbstractObjects
{
    internal abstract class ARigid<T> : AMuteable<T>
    {
        protected abstract bool InspectFormat(string s);
    }
}
