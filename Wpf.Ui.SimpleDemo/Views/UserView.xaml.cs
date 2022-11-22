using System;
using System.Collections.Generic;
using System.Data;
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

namespace Wpf.Ui.SimpleDemo.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void select(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            var dataRowView = (User)dataGrid.SelectedItem;
            if (dataRowView != null)
            {
                idtxt.Text = dataRowView.id.ToString();
                nametxt.Text = dataRowView.email.ToString();
                phonetxt.Text = dataRowView.phone.ToString();
                addresstxt.Text = dataRowView.address.ToString();
            }
        }

        private void load(object sender, RoutedEventArgs e)
        {
            idtxt.Text = "";
            nametxt.Text = "";
            phonetxt.Text = "";
            addresstxt.Text = "";
        }
    }
}
