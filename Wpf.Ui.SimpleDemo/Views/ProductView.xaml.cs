using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using Wpf.Ui.SimpleDemo.Data.Dao;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wpf.Ui.SimpleDemo.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public static int temp;
        public ProductView()
        {
            InitializeComponent();
            nametxt.Focus();
        }

        private void TaskbarStateComboBox_OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (sender is not System.Windows.Controls.ComboBox comboBox)
                return;

            var parentWindow = System.Windows.Window.GetWindow(this);

            if (parentWindow == null)
                return;
            temp = comboBox.SelectedIndex;
            Console.WriteLine(comboBox.SelectedIndex);


        }



        private void AutoSuggestBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void select(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            var dataRowView = (Product)dataGrid.SelectedItem;
            if (dataRowView != null)
            {
                idtxt.Text = dataRowView.id.ToString();
                nametxt.Text = dataRowView.name.ToString();
                quanlitytxt.Text = dataRowView.quantity.ToString();
                pricetxt.Text = dataRowView.price.ToString();
                desctxt.Text = dataRowView.description.ToString();
                cbx.SelectedIndex = 3;
            }
        }

        private void load(object sender, RoutedEventArgs e)
        {
            idtxt.Text = "";
            nametxt.Text = "";
            quanlitytxt.Text = "";
            pricetxt.Text = "";
            desctxt.Text = "";
            cbx.SelectedIndex = 0;
            searchtxt.Text = "";
            table.Items.Refresh();
        }
    }
}
