using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public MainWindow()
        {
            InitializeComponent();
            PValue = 20;
            DispatcherTimer time = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)

            };
            time.Tick += Time_Tick;
            time.Start();

            DataContext = this;
            CopyDir("source", @"F:\dest\dest");
        }

        public static void CopyDir(string source, string dest)
        {
            DirectoryInfo dir = new DirectoryInfo(source);
            if (!dir.Exists)
            {
                return;
            }
  
            Directory.CreateDirectory(dest);

            foreach (FileInfo file in dir.GetFiles())
            {
                string tempPath = Path.Combine(dest, file.Name);
                if (!File.Exists(tempPath))
                {
                    file.CopyTo(tempPath, false);
                    Console.WriteLine("copy to {0}", tempPath);
                }
            }
            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                string tempPath = Path.Combine(dest, subdir.Name);
                CopyDir(subdir.FullName, tempPath);
            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            RunInUi(() => {
                int v = PValue + 1;
                if (v > 100)
                {
                    v = 0;
                }
                PValue = v;
                //circle.Value = v;
            });
        }

        public static void RunInUi(Action action)
        {
            ThreadPool.QueueUserWorkItem(delegate {
                if (Application.Current == null)
                    return;
                SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Application.Current.Dispatcher));
                SynchronizationContext.Current.Post(p => {
                    action();
                }, null);
            });
        }
        private int pvalue;
        public int PValue
        {
            get { return pvalue; }
            set
            {
                pvalue = value;
                OnPropertyChanged("PValue");
            }
        }
    }
}
