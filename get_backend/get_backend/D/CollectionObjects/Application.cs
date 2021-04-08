using System;
using System.Collections.Generic;
using get_backend.D.AbstractObjects;
using get_backend.D.Enums;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.CollectionObjects
{
    internal class Application : AMuteable<Application>
    {
        private readonly Guid ID;
        private readonly EApplicationType ApplicationType;
        private readonly Label Experience;
        private readonly Label Reference;
        private readonly Label Questions; 
        private readonly List<Submission> Submissions; 

        private Property Approved { get; set; }
        private Property Contacted { get; set; }
        private Property Confirmed { get; set; }

        internal Application(Guid G, EApplicationType e)
        {
            ID = G;
            ApplicationType = e;
            Experience = new Label();
            Reference = new Label();
            Questions = new Label();
            Submissions = new List<Submission>();
        }

        internal Application(Application A)
        {
            ID = A.ID;
            Experience = A.Experience;
            Reference = A.Reference;
            Questions = A.Questions;
            Submissions = A.Submissions;
        }

        //internal void AddS(Submission S) => Submissions.Add(S);
        //internal void ChangeS(Submission S) => QueryS(S).Change(S);

        internal override Application Clone => this;
        internal override void Change(Application a)
        {
            throw new NotImplementedException();
        }


        //internal override void Change(Application A) => ChangeApplication(A.Experience, A.Reference, A.Questions);
        //private void ChangeExperience(Label e) => Experience.Change(e.Value);
        //private void ChangeReference(Label r) => Reference.Change(r.Value);
        //private void ChangeQuestions(Label q) => Questions.Change(q.Value);

        //private Submission QueryS(Submission S) => Submissions.Find(ListS => ListS.Id == S.Id);
        //private void ChangeApplication(Label e, Label r, Label q) { ChangeExperience(e); ChangeReference(r); ChangeQuestions(q); }
    }
}
