using System;


namespace get_backend.D.StaticObjects
{
    internal static class Id
    {
        private static Guid UserId { get; set; }
        private static Guid PersonId { get; set; }
        private static Guid FileId { get; set; }
        private static Guid PassportId { get; set; }

        internal static Guid newUserId()
        {
            UserId = Guid.NewGuid();
            return UserId;
        }

        internal static Guid newPersonId()
        {
            PersonId = Guid.NewGuid();
            return PersonId;
        }

        internal static Guid newFileId()
        {
            FileId = Guid.NewGuid();
            return FileId;
        }
        
        internal static Guid newPassportId()
        {
            PassportId = Guid.NewGuid();
            return PassportId;
        }
    }
}