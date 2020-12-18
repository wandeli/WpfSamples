using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WpfSamples
{
    /// <summary>
    /// ListViewPage.xaml 的交互逻辑
    /// </summary>
    /// 
    public class ListViewItemData
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
    }

    public partial class ListViewPage : Page
    {
        public ListViewPage()
        {
            InitializeComponent();
            List<ListViewItemData> items = new List<ListViewItemData>();
            items.Add(new ListViewItemData() { Name = "John Doe", Age = 42, Mail = "john@doe-family.com" });
            items.Add(new ListViewItemData() { Name = "Jane Doe", Age = 39, Mail = "jane@doe-family.com" });
            items.Add(new ListViewItemData() { Name = "Sammy Doe", Age = 7, Mail = "sammy.doe@gmail.com" });
            DataContext = items;
           // SaveDefaultTemplate();
        }

        public static void SaveDefaultTemplate()
        {
            var control = Application.Current.FindResource(typeof(ProgressBar));
                using (XmlTextWriter writer = new XmlTextWriter(@"defaultTemplate.xml", System.Text.Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XamlWriter.Save(control, writer);
                }
            }
        }
}
