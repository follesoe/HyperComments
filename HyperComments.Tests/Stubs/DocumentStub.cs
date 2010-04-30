using System;
using EnvDTE;

namespace HyperComments.Tests.Stubs
{
    public class DocumentStub : Document
    {
        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void Close(vsSaveChanges Save)
        {
            throw new NotImplementedException();
        }

        public Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public bool Redo()
        {
            throw new NotImplementedException();
        }

        public bool Undo()
        {
            throw new NotImplementedException();
        }

        public vsSaveStatus Save(string FileName)
        {
            throw new NotImplementedException();
        }

        public object Object(string ModelKind)
        {
            throw new NotImplementedException();
        }

        public void PrintOut()
        {
            throw new NotImplementedException();
        }

        public void ClearBookmarks()
        {
            throw new NotImplementedException();
        }

        public bool MarkText(string Pattern, int Flags)
        {
            throw new NotImplementedException();
        }

        public bool ReplaceText(string FindText, string ReplaceText, int Flags)
        {
            throw new NotImplementedException();
        }

        public DTE DTE
        {
            get { throw new NotImplementedException(); }
        }

        public string Kind
        {
            get { throw new NotImplementedException(); }
        }

        public Documents Collection
        {
            get { throw new NotImplementedException(); }
        }

        public Window ActiveWindow
        {
            get { throw new NotImplementedException(); }
        }

        public string FullName
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get; set;
        }

        public string Path
        {
            get { throw new NotImplementedException(); }
        }

        public bool ReadOnly
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool Saved
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Windows Windows
        {
            get { throw new NotImplementedException(); }
        }

        public ProjectItem ProjectItem
        {
            get { throw new NotImplementedException(); }
        }

        public object Selection
        {
            get { throw new NotImplementedException(); }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new NotImplementedException();
        }

        public object ExtenderNames
        {
            get { throw new NotImplementedException(); }
        }

        public string ExtenderCATID
        {
            get { throw new NotImplementedException(); }
        }

        public int IndentSize
        {
            get { throw new NotImplementedException(); }
        }

        public string Language
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int TabSize
        {
            get { throw new NotImplementedException(); }
        }

        public string Type
        {
            get { throw new NotImplementedException(); }
        }
    }
}
