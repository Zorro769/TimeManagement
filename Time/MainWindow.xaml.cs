using System;
using System.ComponentModel;
using System.Windows;
using Time.Model;
using Time.Services;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Linq;

namespace Time
{
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<TodoModel> _todoDateList;
        private FileIOService _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _todoDateList = new BindingList<TodoModel>();
            _fileIOService = new FileIOService(PATH);

            try
            {
                _todoDateList = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }
           

            dgTodoList.ItemsSource = _todoDateList;

            _todoDateList.ListChanged += _todoDateList_ListChanged;

            
        }
        
        private void _todoDateList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
                
            }
            CheckTime();
        }
        private void CheckTime()
        {
            
            TodoModel todoModelTmp = new TodoModel();
            for(int i=0;i<_todoDateList.Count();i++)
            {
                todoModelTmp = _todoDateList[i];
                if (todoModelTmp._finishDate == DateTime.Now)
                {
                    new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("Andrew sent you a picture")
                    .AddText("Check this out, The Enchantments in Washington!")
                    .Show();
                    break;
                }
                if (i == _todoDateList.Count() - 1)
                    i = 0;
            }
            
        }
    }
}
