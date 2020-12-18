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
    /// TreeViewPage.xaml 的交互逻辑
    /// </summary>
    
    public class TreeViewRoot
    {
        public string Name { get; set; }
        public ObservableCollection<TreeView1> Child { get; set; }
    }

    public class TreeView1
    {
        public string Name { get; set; }
        public ObservableCollection<TreeView2> Child { get; set; }
    }

    public class TreeView2
    {
        public string Name { get; set; }
        public ObservableCollection<TreeView3> Child { get; set; }
    }

    public class TreeView3
    {
        public string Name { get; set; }
    }


    public partial class TreeViewPage : Page
    {
        public TreeViewPage()
        {
            InitializeComponent();

            TreeViewRoot data = new TreeViewRoot
            {
                Name = "Root",
                Child = new ObservableCollection<TreeView1>()
            };
            TreeView1 t1 = new TreeView1
            {
                Name = "1",
                Child = new ObservableCollection<TreeView2>()
            };
            TreeView1 t2 = new TreeView1
            {
                Name = "2",
                Child = new ObservableCollection<TreeView2>()
            };
            data.Child.Add(t1);
            data.Child.Add(t2);
            TreeView2 t11 = new TreeView2
            {
                Name = "11",
                Child = new ObservableCollection<TreeView3>()
            };
            TreeView2 t12 = new TreeView2
            {
                Name = "12",
                Child = new ObservableCollection<TreeView3>()
            };
            t1.Child.Add(t11);
            t1.Child.Add(t12);

            TreeView3 t111 = new TreeView3
            {
                Name = "111",
            };
            TreeView3 t112 = new TreeView3
            {
                Name = "112",
            };
            t11.Child.Add(t111);
            t11.Child.Add(t112);
            DataContext = data;
        }
    }
}
