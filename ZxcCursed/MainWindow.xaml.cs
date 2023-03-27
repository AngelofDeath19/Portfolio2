using System;
using System.ComponentModel;
using System.Windows;
using ZxcCursed.Models;
using ZxcCursed.Services;

namespace ZxcCursed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string Path = $"{Environment.CurrentDirectory}\\toDoDataList.json";
        private BindingList<ToDoModel?> _todoData;
        private FileSaveLoadService _fslService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fslService = new FileSaveLoadService(Path);
            try
            {
                _todoData = _fslService.Load();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();    
            }
            dgToDoList.ItemsSource = _todoData;
            _todoData.ListChanged += _todoData_ListChanged;
        }

        private void _todoData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted
                || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fslService.Save(sender);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    } 
}
