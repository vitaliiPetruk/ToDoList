using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string Path = $@"{Environment.CurrentDirectory}\ToDoList.json";
        private BindingList<Model> _toDoDataList;
        private FileWriteAndSave _fileWriteAndSave;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileWriteAndSave = new FileWriteAndSave(Path);
            try
            {
                _toDoDataList = _fileWriteAndSave.LoadData(); // Load the data into ToDoList
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }
            

            dgToDoList.ItemsSource = _toDoDataList; // Data binding to DataGrid
            _toDoDataList.ListChanged += _toDoDataList_ListChanged; // Subscription to a BindingList event
        }

        private void _toDoDataList_ListChanged(object sender, ListChangedEventArgs e) // Checked List change
        {
            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                   _fileWriteAndSave.SaveData(sender); // Save new data if there have been changes
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

//switch (e.ListChangedType)
//{
//    case ListChangedType.Reset:
//        break;
//    case ListChangedType.ItemAdded:
//        break;
//    case ListChangedType.ItemDeleted:
//        break;
//    case ListChangedType.ItemMoved:
//        break;
//    case ListChangedType.ItemChanged:
//        break;
//    case ListChangedType.PropertyDescriptorAdded:
//        break;
//    case ListChangedType.PropertyDescriptorDeleted:
//        break;
//    case ListChangedType.PropertyDescriptorChanged:
//        break;
//    default:
//        break;
//}