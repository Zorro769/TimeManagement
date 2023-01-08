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
        private TodoModel tmp,tmp2;
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
            TxtBlochjara.Text = "Today " + DateTime.Now.ToString("dddd,MMMM dd");

            if (i < _todoDateList.Count())
                tmp = _todoDateList[i];
            
            if (tmp._finishDate.ToString() == DateTime.Now.ToString())
                {
                if(i + 1 == _todoDateList.Count())
                {
                    new ToastContentBuilder()
                     .AddText("Good job,bye")
                      .AddInlineImage(new Uri("https://picsum.photos/360/202?image=883"))

    // Profile (app logo override) image
    .AddAppLogoOverride(new Uri("ms-appdata:///local/Andrew.jpg"), ToastGenericAppLogoCrop.Circle)
                     .Show();
                    i++;
                }
                else {
                    tmp2 = _todoDateList[i + 1];
                    new ToastContentBuilder()
                    .AddText("Time for " + tmp._text + " is over")
                    .AddText("Move to " + tmp2._text)
                     .AddInlineImage(new Uri("https://picsum.photos/360/202?image=883"))

    // Profile (app logo override) image
    .AddAppLogoOverride(new Uri("ms-appdata:///local/Andrew.jpg"), ToastGenericAppLogoCrop.Circle)
                    .Show();
                    i++;
                }
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
