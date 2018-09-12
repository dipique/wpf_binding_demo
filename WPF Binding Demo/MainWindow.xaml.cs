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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Binding_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<InventoryItem> db = Enumerable.Range(1, 100).Select(i => new InventoryItem()).ToList();

        public MainWindow()
        {
            InitializeComponent();

            //ignore the details of the query, it's just so I have a data source
            var query = (from a in db
                         where a.Conway_Tag != null
                         select a).ToList();

            //set the form data context
            DataContext = query;
        }

        private void dgInventory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgInventory.SelectedItem is InventoryItem i)
            {
                var sw = new Modify_Form();
                sw.DataContext = i;
                sw.Show();
            }
            //if (sender is DataGridRow dg) //make sure we really are dealing with a DataGridRow
            //    if (dg.IsSelected) //make sure the item is selected
            //        if (dg.Item is InventoryItem i) //make sure the item is an inventoryitem
            //        {
            //            var sw = new SecondaryWindow();
            //            sw.DataContext = i;
            //            sw.Show();
            //        }
        }
    }
}
