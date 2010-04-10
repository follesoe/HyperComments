using System.IO;

namespace HyperComments
{
    public class FileSystemAdapter : IAccessFiles
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
