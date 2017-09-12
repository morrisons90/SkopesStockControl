using SkopesStockCont.buttonFunc;
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
using System.Windows.Shapes;

namespace SkopesStockCont
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddTable : Window
    {
        public List<ColumnType> Columns = new List<ColumnType>();
        public AddTable()
        {
            InitializeComponent();
            ColumnsDataGrid.ItemsSource = Columns;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newColumn = new ColumnType();
            newColumn.Name = NewColumnName.Text;
            NewColumnName.Text = "";
            newColumn.Type = NewColumnType.Text;
            NewColumnType.SelectedItem = "";
            Columns.Add(newColumn);
            ColumnsDataGrid.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selected = ColumnsDataGrid.SelectedIndex;
            Columns.RemoveAt(selected);
            ColumnsDataGrid.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var sql = new NewSQLConn();

            //Make col string
            string query = ("CREATE TABLE " + TableNameBox.Text + " (");
            foreach (ColumnType col in Columns)
            {
                if (col != Columns[0])
                {

                    query += ", " + col.Name + " " + col.Type;

                }
                else
                {
                    query += col.Name + " " + col.Type;
                }

            }
            query += ")";
            MessageBox.Show(query);
            sql.NonQuery(query);
            this.Close();
        }
    }
}
