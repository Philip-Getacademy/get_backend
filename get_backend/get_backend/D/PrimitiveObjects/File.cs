
/*
 * File is used to store file related data
 */

using System;
using get_backend.D.AbstractObjects;
using static get_backend.D.StaticObjects.Id;

namespace get_backend.D.PrimitiveObjects
{
    internal sealed class File : AMuteable<File>
    {
        private readonly Guid ID;
        private readonly Label Type;
        private readonly Label Name;
        private readonly Label Content;

        private File(Guid id) => ID = id;
        private File(Guid id, Label t) : this(id) => Type = t;
        private File(Guid id, Label t, Label n) : this(id, t) => Name = n;
        private File(Guid id, Label t, Label n, Label c) : this(id, t, n) => Content = c;
        
        internal File() : this(newFileId(), new Label(), new Label(), new Label()) { }
        internal File(File F) : this(F.ID, new Label(F.Type), new Label(F.Name), new Label(F.Content)) { }

        internal override File Clone => this;
        internal override void Change(File F) => ChangeFile(F.Type, F.Name, F.Content);

        private void ChangeFile(Label t, Label n, Label c) { ChangeT(t); ChangeN(n); ChangeC(c); }
        private void ChangeT(Label t) => Type   .Change(t.Value);
        private void ChangeN(Label n) => Name   .Change(n.Value);
        private void ChangeC(Label c) => Content.Change(c.Value);
    }
}
