using System.IO;

namespace HyperComments
{
    public interface IAccessFiles
    {
        bool FileExists(string path);
        bool DirectoryExists(string path);
        DirectoryInfo CreateDirectory(string path);
    }
}
