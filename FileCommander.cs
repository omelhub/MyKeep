namespace MyKeep;

internal class FileCommander
{
    private readonly string PATH;

    public FileCommander(string path)
    {
        PATH = path;
    }

    public BindingList<Task> LoadData()
    {
        bool existence = File.Exists(PATH);
        if (!existence)
        {
            File.CreateText(PATH).Dispose();
            return new BindingList<Task>();
        }
        using (var reader = File.OpenText(PATH))
        {
            var fileText = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<BindingList<Task>>(fileText);
        }
    }

    public void SaveData(object? _tasks) //BindingList<Task>
    {
        using(StreamWriter writer = File.CreateText(PATH))
        {
            string output = JsonConvert.SerializeObject(_tasks);
            writer.Write(output);
        }
    }
}
