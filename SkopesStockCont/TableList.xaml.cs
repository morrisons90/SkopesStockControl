using SkopesStockCont.buttonFunc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace SkopesStockCont
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TableList : Window
    {
        public List<String> results = new List<String>();
        public TableList()
        {
            InitializeComponent();
            UpdateResults();
        }
        public void UpdateResults()
        {
            var sql = new NewSQLConn();
            ResultListBox.ItemsSource = sql.Select("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo'", 2);
        }

        private void AddNewTableButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddTable();
            addWindow.Show();
            addWindow.Closed += (a, b) =>
            {
                UpdateResults();
            };
        }

        private void DeleteTableButton_Click(object sender, RoutedEventArgs e)
        {
            var conf = MessageBox.Show("Are you sure you want to remove this table and all its records?", "Confirm Opperation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (conf == MessageBoxResult.Yes)
            {
                var sql = new NewSQLConn();

                sql.NonQuery("DROP TABLE " + ResultListBox.SelectedItem.ToString());
                UpdateResults();
            }
        }

        private void ViewTableButton_Click(object sender, RoutedEventArgs e)
        {
            
            var sql = new NewSQLConn();
            string q = ResultListBox.SelectedItem.ToString();
            
            var addWindow = new AddTable() { Columns = sql.SelectCols(q) };
            
            addWindow.TableNameBox.Text = ResultListBox.SelectedItem.ToString();
            addWindow.ColumnsDataGrid.ItemsSource = addWindow.Columns;
            addWindow.ConfButton.Content = "Update";

            addWindow.Show();
        }
    }
}
