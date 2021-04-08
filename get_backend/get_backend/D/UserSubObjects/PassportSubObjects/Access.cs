using System;
using System.Collections.Generic;
using System.Text;
using get_backend.D.PrimitiveObjects;
using static get_backend.D.StaticObjects.Roles;

namespace get_backend.D.UserSubObjects.PassportSubObjects
{
    internal sealed class Access
    {
        private Property AnonymousUser;

        public Access()
        {
            AnonymousUser = new Property(true);
        }
    }
}
