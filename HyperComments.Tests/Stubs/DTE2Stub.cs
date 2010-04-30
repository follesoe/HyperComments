using System;
using EnvDTE;
using EnvDTE80;

namespace HyperComments.Tests.Stubs
{
    public class DTE2Stub : DTE2
    {
        private readonly DocumentStub _activeDocument;
        private readonly Solution2Stub _solution;

        Document DTE2.ActiveDocument
        {
            get { return _activeDocument; }
        }

        public DTE2Stub()
        {
            
        }
        public DTE2Stub(string documentName, string solutionFile)
        {
            _activeDocument = new DocumentStub();
            _activeDocument.Name = documentName;

            _solution = new Solution2Stub(solutionFile);
        }

        void _DTE.Quit()
        {
            throw new NotImplementedException();
        }

        object DTE2.GetObject(string Name)
        {
            throw new NotImplementedException();
        }

        Window DTE2.OpenFile(string ViewKind, string FileName)
        {
            throw new NotImplementedException();
        }

        void DTE2.ExecuteCommand(string CommandName, string CommandArgs)
        {
            throw new NotImplementedException();
        }

        wizardResult DTE2.LaunchWizard(string VSZFile, ref object[] ContextParams)
        {
            throw new NotImplementedException();
        }

        string DTE2.SatelliteDllPath(string Path, string Name)
        {
            throw new NotImplementedException();
        }

        string DTE2.Name
        {
            get { throw new NotImplementedException(); }
        }

        string DTE2.FileName
        {
            get { throw new NotImplementedException(); }
        }

        string DTE2.Version
        {
            get { throw new NotImplementedException(); }
        }

        object DTE2.CommandBars
        {
            get { throw new NotImplementedException(); }
        }

        Windows DTE2.Windows
        {
            get { throw new NotImplementedException(); }
        }

        Events DTE2.Events
        {
            get { throw new NotImplementedException(); }
        }

        AddIns DTE2.AddIns
        {
            get { throw new NotImplementedException(); }
        }

        Window DTE2.MainWindow
        {
            get { throw new NotImplementedException(); }
        }

        Window DTE2.ActiveWindow
        {
            get { throw new NotImplementedException(); }
        }

        vsDisplay DTE2.DisplayMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public uint GetThemeColor(vsThemeColors Element)
        {
            throw new NotImplementedException();
        }

        void DTE2.Quit()
        {
            throw new NotImplementedException();
        }

        object _DTE.GetObject(string Name)
        {
            throw new NotImplementedException();
        }

        Window _DTE.OpenFile(string ViewKind, string FileName)
        {
            throw new NotImplementedException();
        }

        void _DTE.ExecuteCommand(string CommandName, string CommandArgs)
        {
            throw new NotImplementedException();
        }

        wizardResult _DTE.LaunchWizard(string VSZFile, ref object[] ContextParams)
        {
            throw new NotImplementedException();
        }

        string _DTE.SatelliteDllPath(string Path, string Name)
        {
            throw new NotImplementedException();
        }

        string _DTE.Name
        {
            get { throw new NotImplementedException(); }
        }

        string _DTE.FileName
        {
            get { throw new NotImplementedException(); }
        }

        string _DTE.Version
        {
            get { throw new NotImplementedException(); }
        }

        object _DTE.CommandBars
        {
            get { throw new NotImplementedException(); }
        }

        Windows _DTE.Windows
        {
            get { throw new NotImplementedException(); }
        }

        Events _DTE.Events
        {
            get { throw new NotImplementedException(); }
        }

        AddIns _DTE.AddIns
        {
            get { throw new NotImplementedException(); }
        }

        Window _DTE.MainWindow
        {
            get { throw new NotImplementedException(); }
        }

        Window _DTE.ActiveWindow
        {
            get { throw new NotImplementedException(); }
        }

        vsDisplay _DTE.DisplayMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        Solution _DTE.Solution
        {
            get { throw new NotImplementedException(); }
        }

        Commands DTE2.Commands
        {
            get { throw new NotImplementedException(); }
        }

        Solution DTE2.Solution
        {
            get { return _solution; }
        }

        Commands _DTE.Commands
        {
            get { throw new NotImplementedException(); }
        }

        Properties _DTE.get_Properties(string Category, string Page)
        {
            throw new NotImplementedException();
        }

        SelectedItems DTE2.SelectedItems
        {
            get { throw new NotImplementedException(); ; }
        }

        string DTE2.CommandLineArguments
        {
            get { throw new NotImplementedException(); }
        }

        Properties DTE2.get_Properties(string Category, string Page)
        {
            throw new NotImplementedException();
        }

        SelectedItems _DTE.SelectedItems
        {
            get { throw new NotImplementedException(); }
        }

        string _DTE.CommandLineArguments
        {
            get { throw new NotImplementedException(); }
        }

        bool _DTE.get_IsOpenFile(string ViewKind, string FileName)
        {
            throw new NotImplementedException();
        }

        DTE DTE2.DTE
        {
            get { throw new NotImplementedException(); }
        }

        int DTE2.LocaleID
        {
            get { throw new NotImplementedException(); }
        }

        WindowConfigurations DTE2.WindowConfigurations
        {
            get { throw new NotImplementedException(); }
        }

        Documents DTE2.Documents
        {
            get { throw new NotImplementedException(); }
        }

        Globals DTE2.Globals
        {
            get { throw new NotImplementedException(); }
        }

        StatusBar DTE2.StatusBar
        {
            get { throw new NotImplementedException(); }
        }

        string DTE2.FullName
        {
            get { throw new NotImplementedException(); }
        }

        bool DTE2.UserControl
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        bool DTE2.get_IsOpenFile(string ViewKind, string FileName)
        {
            throw new NotImplementedException();
        }

        DTE _DTE.DTE
        {
            get { throw new NotImplementedException(); }
        }

        int _DTE.LocaleID
        {
            get { throw new NotImplementedException(); }
        }

        WindowConfigurations _DTE.WindowConfigurations
        {
            get { throw new NotImplementedException(); }
        }

        Documents _DTE.Documents
        {
            get { throw new NotImplementedException(); ; }
        }

        Document _DTE.ActiveDocument
        {
            get { throw new NotImplementedException(); }
        }

        Globals _DTE.Globals
        {
            get { throw new NotImplementedException(); }
        }

        StatusBar _DTE.StatusBar
        {
            get { throw new NotImplementedException(); }
        }

        string _DTE.FullName
        {
            get { throw new NotImplementedException(); }
        }

        bool _DTE.UserControl
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        ObjectExtenders _DTE.ObjectExtenders
        {
            get { throw new NotImplementedException(); }
        }

        Find DTE2.Find
        {
            get { throw new NotImplementedException(); }
        }

        vsIDEMode DTE2.Mode
        {
            get { throw new NotImplementedException(); }
        }

        ItemOperations DTE2.ItemOperations
        {
            get { throw new NotImplementedException(); }
        }

        UndoContext DTE2.UndoContext
        {
            get { throw new NotImplementedException(); }
        }

        Macros DTE2.Macros
        {
            get { throw new NotImplementedException(); }
        }

        object DTE2.ActiveSolutionProjects
        {
            get { throw new NotImplementedException(); }
        }

        DTE DTE2.MacrosIDE
        {
            get { throw new NotImplementedException(); }
        }

        string DTE2.RegistryRoot
        {
            get { throw new NotImplementedException(); }
        }

        DTE DTE2.Application
        {
            get { throw new NotImplementedException(); }
        }

        ContextAttributes DTE2.ContextAttributes
        {
            get { throw new NotImplementedException(); }
        }

        SourceControl DTE2.SourceControl
        {
            get { throw new NotImplementedException(); }
        }

        bool DTE2.SuppressUI
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        ObjectExtenders DTE2.ObjectExtenders
        {
            get { throw new NotImplementedException(); }
        }

        Find _DTE.Find
        {
            get { throw new NotImplementedException(); }
        }

        vsIDEMode _DTE.Mode
        {
            get { throw new NotImplementedException(); }
        }

        ItemOperations _DTE.ItemOperations
        {
            get { throw new NotImplementedException(); }
        }

        UndoContext _DTE.UndoContext
        {
            get { throw new NotImplementedException(); }
        }

        Macros _DTE.Macros
        {
            get { throw new NotImplementedException(); }
        }

        object _DTE.ActiveSolutionProjects
        {
            get { throw new NotImplementedException(); }
        }

        DTE _DTE.MacrosIDE
        {
            get { throw new NotImplementedException(); }
        }

        string _DTE.RegistryRoot
        {
            get { throw new NotImplementedException(); }
        }

        DTE _DTE.Application
        {
            get { throw new NotImplementedException(); }
        }

        ContextAttributes _DTE.ContextAttributes
        {
            get { throw new NotImplementedException(); }
        }

        SourceControl _DTE.SourceControl
        {
            get { throw new NotImplementedException(); }
        }

        bool _DTE.SuppressUI
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        Debugger _DTE.Debugger
        {
            get { throw new NotImplementedException(); }
        }

        string DTE2.Edition
        {
            get { throw new NotImplementedException(); }
        }

        public ToolWindows ToolWindows { get; private set; }

        Debugger DTE2.Debugger
        {
            get { throw new NotImplementedException(); }
        }

        string _DTE.Edition
        {
            get { throw new NotImplementedException(); }
        }
    }
}
