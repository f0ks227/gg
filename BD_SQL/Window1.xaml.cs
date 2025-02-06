using Microsoft.Data.SqlClient;
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

namespace BD_SQL
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
         string conStr = @"Data Source=(localdb)\gg; Initial Catalog=fastcat; Integrated Security=true; Trusted_Connection=True; TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("delete from Customers where FullName = 'Иван Иванов'", connection);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("deleted");
                }
                else
                {
                    MessageBox.Show("not deleted");
                }

            }
        }

        private void NextWindow_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }
    }
}
