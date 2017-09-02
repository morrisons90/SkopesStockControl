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
    public partial class ResultList : Window
    {
        public ResultList()
        {
            InitializeComponent();
            var results = GetDBTables.Get();

            ResultListBox.ItemsSource = results;
        }
    }
}
