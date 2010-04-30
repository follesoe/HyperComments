using System;
using System.Collections;
using EnvDTE;
using EnvDTE80;

namespace HyperComments.Tests.Stubs
{
    public class Solution2Stub : Solution2, Solution
    {
        private readonly string _filename;

        public Solution2Stub(string filename)
        {
            _filename = filename;    
        }

        Project _Solution.Item(object index)
        {
            throw new NotImplementedException();
        }

        IEnumerator Solution2.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        void Solution2.SaveAs(string FileName)
        {
            throw new NotImplementedException();
        }

        Project Solution2.AddFromTemplate(string FileName, string Destination, string ProjectName, bool Exclusive)
        {
            throw new NotImplementedException();
        }

        Project Solution2.AddFromFile(string FileName, bool Exclusive)
        {
            throw new NotImplementedException();
        }

        void Solution2.Open(string FileName)
        {
            throw new NotImplementedException();
        }

        void Solution2.Close(bool SaveFirst)
        {
            throw new NotImplementedException();
        }

        void Solution2.Remove(Project proj)
        {
            throw new NotImplementedException();
        }

        void Solution2.Create(string Destination, string Name)
        {
            throw new NotImplementedException();
        }

        ProjectItem Solution2.FindProjectItem(string FileName)
        {
            throw new NotImplementedException();
        }

        string Solution2.ProjectItemsTemplatePath(string ProjectKind)
        {
            throw new NotImplementedException();
        }

        DTE Solution2.DTE
        {
            get { throw new NotImplementedException(); }
        }

        DTE Solution2.Parent
        {
            get { throw new NotImplementedException(); }
        }

        int Solution2.Count
        {
            get { throw new NotImplementedException(); }
        }

        string Solution2.FileName
        {
            get { return _filename; }
        }

        Properties Solution2.Properties
        {
            get { throw new NotImplementedException(); }
        }

        bool Solution2.IsDirty
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Project AddSolutionFolder(string Name)
        {
            throw new NotImplementedException();
        }

        public string GetProjectTemplate(string TemplateName, string Language)
        {
            throw new NotImplementedException();
        }

        public string GetProjectItemTemplate(string TemplateName, string Language)
        {
            throw new NotImplementedException();
        }

        Project Solution2.Item(object index)
        {
            throw new NotImplementedException();
        }

        IEnumerator _Solution.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        void _Solution.SaveAs(string FileName)
        {
            throw new NotImplementedException();
        }

        Project _Solution.AddFromTemplate(string FileName, string Destination, string ProjectName, bool Exclusive)
        {
            throw new NotImplementedException();
        }

        Project _Solution.AddFromFile(string FileName, bool Exclusive)
        {
            throw new NotImplementedException();
        }

        void _Solution.Open(string FileName)
        {
            throw new NotImplementedException();
        }

        void _Solution.Close(bool SaveFirst)
        {
            throw new NotImplementedException();
        }

        void _Solution.Remove(Project proj)
        {
            throw new NotImplementedException();
        }

        void _Solution.Create(string Destination, string Name)
        {
            throw new NotImplementedException();
        }

        ProjectItem _Solution.FindProjectItem(string FileName)
        {
            throw new NotImplementedException();
        }

        string _Solution.ProjectItemsTemplatePath(string ProjectKind)
        {
            throw new NotImplementedException();
        }

        DTE _Solution.DTE
        {
            get { throw new NotImplementedException(); }
        }

        DTE _Solution.Parent
        {
            get { throw new NotImplementedException(); }
        }

        int _Solution.Count
        {
            get { throw new NotImplementedException(); }
        }

        string _Solution.FileName
        {
            get { throw new NotImplementedException(); }
        }

        Properties _Solution.Properties
        {
            get { throw new NotImplementedException(); }
        }

        bool _Solution.IsDirty
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        string _Solution.get_TemplatePath(string ProjectType)
        {
            throw new NotImplementedException();
        }

        string Solution2.FullName
        {
            get { throw new NotImplementedException(); }
        }

        bool Solution2.Saved
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        string Solution2.get_TemplatePath(string ProjectType)
        {
            throw new NotImplementedException();
        }

        string _Solution.FullName
        {
            get { throw new NotImplementedException(); }
        }

        bool _Solution.Saved
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        Globals _Solution.Globals
        {
            get { throw new NotImplementedException(); }
        }

        AddIns Solution2.AddIns
        {
            get { throw new NotImplementedException(); }
        }

        Globals Solution2.Globals
        {
            get { throw new NotImplementedException(); }
        }

        AddIns _Solution.AddIns
        {
            get { throw new NotImplementedException(); }
        }

        object _Solution.get_Extender(string ExtenderName)
        {
            throw new NotImplementedException();
        }

        object Solution2.ExtenderNames
        {
            get { throw new NotImplementedException(); }
        }

        string Solution2.ExtenderCATID
        {
            get { throw new NotImplementedException(); }
        }

        bool Solution2.IsOpen
        {
            get { throw new NotImplementedException(); }
        }

        SolutionBuild Solution2.SolutionBuild
        {
            get { throw new NotImplementedException(); }
        }

        Projects Solution2.Projects
        {
            get { throw new NotImplementedException(); }
        }

        object Solution2.get_Extender(string ExtenderName)
        {
            throw new NotImplementedException();
        }

        object _Solution.ExtenderNames
        {
            get { throw new NotImplementedException(); }
        }

        string _Solution.ExtenderCATID
        {
            get { throw new NotImplementedException(); }
        }

        bool _Solution.IsOpen
        {
            get { throw new NotImplementedException(); }
        }

        SolutionBuild _Solution.SolutionBuild
        {
            get { throw new NotImplementedException(); }
        }

        Projects _Solution.Projects
        {
            get { throw new NotImplementedException(); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
