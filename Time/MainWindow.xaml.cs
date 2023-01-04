using System;
using System.ComponentModel;
using System.Windows;
using Time.Model;
using Time.Services;
using System.Windows.Threading;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Linq;

namespace Time
{
    public partial class MainWindow : Window
    {
        private TodoModel tmp;
        private int i = 0;
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<TodoModel> _todoDateList;
        private FileIOService _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer disTmr = new DispatcherTimer();
            disTmr.Tick += new EventHandler(disTmr_Tick);
            disTmr.Interval = new TimeSpan(0, 0, 1);
            disTmr.Start();

        }

        private void disTmr_Tick(object sender, EventArgs e)
        {
            TxtBlochjara.Text = DateTime.Now.ToString();

            if(i < _todoDateList.Count())
                tmp = _todoDateList[i];
                if (tmp._finishDate.ToString() == DateTime.Now.ToString())
                {
                new ToastContentBuilder()
                    .AddText("Time for this business is over")
                    .AddText("Move to the next task!!!")
                    .Show();
                    i++;
            }
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
           }
    }
}
