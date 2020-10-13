using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfSamples
{
    /// <summary>
    /// ComboBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ComboBoxDemo : Page,INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public ObservableCollection<BoxItem> Items { get; set; }
        public ObservableCollection<BoxItem> Lists { get; set; }

        public ComboBoxDemo()
        {
            InitializeComponent();

            Items = new ObservableCollection<BoxItem>()
            {
                new BoxItem { Id="0", Name="q"},
                new BoxItem { Id="1", Name="qw"},
                new BoxItem { Id="2", Name="qe"},
            };

            Lists = new ObservableCollection<BoxItem>()
            {
                new BoxItem { Id="10", Name="q"},
                new BoxItem { Id="11", Name="qw"},
                new BoxItem { Id="12", Name="qe"},
            };

            DataContext = this;
        }
    }

    public class BoxItem
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Id;
        }
    }
}
