
using System.Diagnostics;


namespace Adress_Book.Services;


public interface IFileManager 
{
    bool SaveJson(string content);

    string LoadJson();

}

// FileManager är min filhanteringsclass, med Streamwriter och StreamReader laddar jag och sparar jag min json fil. Sökvägen till filen anges i AdressService
public class FileManager(string filePath) : IFileManager
{
        private readonly string _filePath = filePath;

    public bool SaveJson(string content)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public string LoadJson()
    {
        try
        {
            if (File.Exists(_filePath)) 
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

  
}
