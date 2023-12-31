

namespace Adress_Book.Services;


public interface IFileManager 
{
    
    
    bool SaveAdress(string content);

    string GetAdress();
}


public class FileManager(string filePath) : IFileManager
{
        private readonly string _filePath = filePath;

    public string GetAdress()
    {
        throw new NotImplementedException();
    }

    public bool SaveAdress(string content)
    {
        throw new NotImplementedException();
    }
}
