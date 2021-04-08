using System;
using get_backend.D.AbstractObjects;
using get_backend.D.PrimitiveObjects;

using static get_backend.D.StaticObjects.SNewClassFactory;

namespace get_backend.D.CollectionObjects
{
    internal class Submission : AMuteable<Submission>
    {
        private readonly Guid     UId;
        private readonly DateTime Time;
        private readonly Label    Header;
        private readonly Label    Content;
        private readonly File     File;

        private Submission()                                                 => Time    = DateTime.Now;
        private Submission(Label c)                          : this()        => Content = new Label(c);
        private Submission(Label c, Label h)                 : this(c)       => Header  = new Label(h);
        private Submission(Label c, Label h, File f)         : this(c, h)    => File    = new File(f);
        private Submission(Label c, Label h, File f, Guid i) : this(c, h, f) => UId     = i;

        internal Submission(Guid I)       : this(NewLabel, NewLabel, new File(), I) { }
        internal Submission(Submission s) : this(s.Content, s.Header, s.File, s.UId) { }

        internal string id        => UId.ToString();
        internal string timeStamp => Time.ToString(@"dd\/MM\/yyyy");
        internal string header    => Header.Value;
        internal string content   => Content.Value;

        internal override Submission Clone => this;

        internal override void Change(Submission a)
        {
            throw new NotImplementedException();
        }
        //internal override void Change(Submission S) => ChangeS(S.Header, S.Content, S.File);

        //private void ChangeS(Label h, Label c, File f) { ChangeH(h); ChangeC(c); ChangeF(f); T.Add(DateTime.Now); }
        //private void ChangeH(Label h) => Header.Change(h.Value);
        //private void ChangeC(Label c) => Content.Change(c.Value);
        //private void ChangeF(File f) => File.Change(f);
    }
}
