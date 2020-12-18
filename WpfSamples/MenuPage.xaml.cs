using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// MenuPage.xaml 的交互逻辑
    /// </summary>

    public class MenuPageItemData
    {
       public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            ObservableCollection<MenuPageItemData> data = new ObservableCollection<MenuPageItemData>();
            data.Add(new MenuPageItemData { Name = "444444" });
            data.Add(new MenuPageItemData { Name = "555555" });
            DataContext = data;
        }
    }
}
