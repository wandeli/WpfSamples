﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WpfSamples
{
    /// <summary>
    /// Test.xaml 的交互逻辑
    /// </summary>
    public partial class Test : Page
    {
        private string TestData = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
        private List<string> words;
        private int maxword;
        private int index;

        public ObservableCollection<LogEntry> LogEntries { get; set; }

        public Test()
        {
            InitializeComponent();

            random = new Random();
            words = TestData.Split(' ').ToList();
            maxword = words.Count - 1;

            DataContext = LogEntries = new ObservableCollection<LogEntry>();
            Console.WriteLine("1111");
            Enumerable.Range(0, 20)
                      .ToList()
                      .ForEach(x => LogEntries.Add(GetRandomEntry()));
            Console.WriteLine("2222");
            Timer = new Timer(x => AddRandomEntry(), null, 1000, 10);
        }

        private System.Threading.Timer Timer;
        private System.Random random;
        private void AddRandomEntry()
        {
            Dispatcher.BeginInvoke((Action)(() => LogEntries.Add(GetRandomEntry())));
        }

        private LogEntry GetRandomEntry()
        {
            if (random.Next(1, 10) > 1)
            {
                return new LogEntry()
                {
                    Index = index++,
                    DateTime = DateTime.Now,
                    Message = string.Join(" ", Enumerable.Range(5, random.Next(10, 50))
                                                         .Select(x => words[random.Next(0, maxword)])),
                };
            }

            return new CollapsibleLogEntry()
            {
                Index = index++,
                DateTime = DateTime.Now,
                Message = string.Join(" ", Enumerable.Range(5, random.Next(10, 50))
                                                        .Select(x => words[random.Next(0, maxword)])),
                Contents = Enumerable.Range(5, random.Next(5, 10))
                                                .Select(i => GetRandomEntry())
                                                .ToList()
            };

        }
    }

    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }));
        }
    }

    public class LogEntry : PropertyChangedBase
    {
        public DateTime DateTime { get; set; }

        public int Index { get; set; }

        public string Message { get; set; }
    }

    public class CollapsibleLogEntry : LogEntry
    {
        public List<LogEntry> Contents { get; set; }
    }
}
