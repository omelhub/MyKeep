namespace MyKeep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<Task> _tasks;

        private FileCommander _filecommander;
        private readonly string PATH = $"{Environment.CurrentDirectory}\\tasks.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToDoList_Loaded(object sender, RoutedEventArgs e)
        {
            _filecommander = new FileCommander(PATH);
            
            try
            {
                _tasks = _filecommander.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            ToDoList.ItemsSource = _tasks;
            _tasks.ListChanged += _tasks_ListChanged;

        }

        private void _tasks_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _filecommander.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void ToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
