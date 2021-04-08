using System;
using System.Collections.Generic;
using System.Reflection;

namespace get_backend.D.Interfaces
{
    /// <summary> IDatabaseObject requires that reflection is implemented for DB automation
    /// </summary>
    internal interface IDatabaseObject<out T>
    {
        Type NameOf { get; }
        List<FieldInfo> FieldsOf { get; }
        List<PropertyInfo> PropertiesOf { get; }
    }
}
