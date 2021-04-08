
/*
 * Passport is used to store siteaccess related infomation 
 */

using System;
using get_backend.D.PrimitiveObjects;
using get_backend.D.StaticObjects;
using get_backend.D.UserSubObjects.PassportSubObjects;
using static get_backend.D.StaticObjects.Id;

namespace get_backend.D.UserSubObjects
{
    internal sealed class Passport
    {
        private readonly Access Access;
        private readonly Verification Verification;
        private readonly DateTime ValidFrom;
        private readonly DateTime ValidTo;
        private readonly Label Token;
        private readonly Guid PassportId;
        private readonly Guid PassportOwner;

        public Passport(Guid userId)
        {
            Token = new Label();
            Access = new Access();
            Verification = new Verification();
            ValidFrom = DateTime.Now;
            ValidTo = DateTime.Now + new TimeSpan(7, 0, 0, 0);
            PassportOwner = userId;
            PassportId = newPassportId();
        }

        internal Passport(Passport p, Guid userId)
        {
            //Token = new Label(p.Token.Value);
            //Access = new Access(p.Access);
            //Verification = new Verification(p.Verification);
            ValidFrom = p.ValidFrom;
            ValidTo = p.ValidTo;
            PassportOwner = userId;
            PassportId = p.PassportId;
        }

        internal string Key()
        {
            if (Verification.Status == null) return Roles.anonymous;
            if (Verification.Status == "Applicant") return Roles.applicant;

            return Roles.anonymous;
        }
    }
}
