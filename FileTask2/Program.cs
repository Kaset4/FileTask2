class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к директории:");
        string folderPath = Console.ReadLine();

        try
        {
            if (Directory.Exists(folderPath))
            {
                long folderSize = GetFolderSize(folderPath);
                Console.WriteLine($"Размер папки {folderPath}: {folderSize} байт");
            }
            else
            {
                Console.WriteLine("Указанная директория не существует.");
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Ошибка доступа: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static long GetFolderSize(string folderPath)
    {
        long size = 0;

        foreach (string file in Directory.GetFiles(folderPath))
        {
            size += new FileInfo(file).Length;
        }

        foreach (string subDirectory in Directory.GetDirectories(folderPath))
        {
            size += GetFolderSize(subDirectory);
        }

        return size;
    }
}