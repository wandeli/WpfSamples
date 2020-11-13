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
    /// Page1.xaml 的交互逻辑
    /// </summary>
    /// 
    public class MenuItemData
    {
        public MenuItemData()
        {
            Items = new ObservableCollection<MenuItemData>();
        }
        public string Name { get; set; }
        public int Type { get; set; }
        public ObservableCollection<MenuItemData> Items { get; set; }
    }

    public partial class Page1 : Page
    {

        public ObservableCollection<MenuItemData> MenuItems { get; set; }

        public Page1()
        {
            InitializeComponent();
            MenuItems = new ObservableCollection<MenuItemData>();
            MenuItemData child1 = new MenuItemData()
            {
                Name = "child1"
            };
            MenuItemData child11 = new MenuItemData()
            {
                Name = "child11"
            };
            MenuItemData child12 = new MenuItemData()
            {
                Name = "child12"
            };
            child1.Items.Add(child11);
            child1.Items.Add(child12);
            MenuItemData child2 = new MenuItemData()
            {
                Name = "child2"
            };
            
            MenuItems.Add(child1);
            MenuItems.Add(child2);
            DataContext = this;
        }
    }
}
