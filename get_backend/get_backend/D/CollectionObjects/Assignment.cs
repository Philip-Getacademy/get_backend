using System;
using System.Collections.Generic;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.CollectionObjects
{
    internal sealed class Assignment
    {
        private readonly Guid ID;
        private readonly Label Answers;
        private readonly Label Questions;
        private readonly List<Submission> Submissions;

        private Property Approved { get; set; }
        private Property Contacted { get; set; }
        private Property Confirmed { get; set; }

        internal Assignment(Guid G)
        {
            ID = G;
            Answers = new Label();
            Questions = new Label();
            Submissions = new List<Submission>();
        }

        internal Assignment(Assignment A)
        {
            ID = A.ID;
            Answers = A.Answers;
            Questions = A.Questions;
            Submissions = A.Submissions;
        }

        internal Assignment Clone => this;

    }
}
