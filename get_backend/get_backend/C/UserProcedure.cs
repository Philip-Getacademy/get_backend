using System;
using System.Collections.Generic;
using System.Text;
using get_backend.D;

namespace get_backend.C
{
    static class UserProcedure
    {

        public static string Read(User u)
        {
            return $@"
                Select {u.NameOf.FullName}
                Where {u.PersonId} == {u.PersonId} 
                

            ";
        }
    }
}
